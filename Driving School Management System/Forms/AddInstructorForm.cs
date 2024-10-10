using System.Runtime.InteropServices;
using System;
using System.Windows.Forms;
using System.Drawing;
using DrivingSchool_BusinesseLayer;
using Driving_school_BusinessLayer;

namespace Driving_School_Management_System.Forms
{
    public partial class AddInstructorForm : Form
    {


        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
          (
              int nLeftRect,     
              int nTopRect,      
              int nRightRect,    
              int nBottomRect,   
              int nWidthEllipse, 
              int nHeightEllipse 
          );




        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }



        // this the classes that depends on Instructor form 
        clsPerson person = null;
        clsDrivingLicense drivingLicense = null;
        clsNationalCard nationalCard  = null ;
        StatusMessageForm statusMessageForm = null;
        clsAddress address = null;
        clsContact contact = null;
        clsInstructor instructor = null;
        public delegate void AddNewInstructor();
        public event AddNewInstructor OnInstructorAddedEventHundler; 
        public AddInstructorForm()
        {
            InitializeComponent();
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            FillDrivingLisenceTypeInput(); 
        }


        private bool _GetGender()
        {
            return true ? RbtnMale.Checked : false;
        }

        private bool InputRequiredValidation()
        {
            bool isNotExist =   string.IsNullOrEmpty(txtboxFirstName_Arabic.Text) ||
                                string.IsNullOrEmpty(txtboxLastName_Arabic.Text) ||
                                string.IsNullOrEmpty(txtboxFirstName.Text) ||
                                string.IsNullOrEmpty(txtboxLastName.Text) ||
                                string.IsNullOrEmpty(txtboxBirthPlace.Text) ||
                                string.IsNullOrEmpty(CboxIdentityType.Text) ||
                                string.IsNullOrEmpty(txtbxIdentityNumber.Text) ||
                                string.IsNullOrEmpty(txtbxEmail.Text) ||
                                string.IsNullOrEmpty(txtbxPhone.Text) ||
                                string.IsNullOrEmpty(txtBxDrivingLisenceNumber.Text) ||
                                string.IsNullOrEmpty(CBoxDrivingLisenceType.Text);


            return !isNotExist; 

        }

        
        private void FillDrivingLisenceTypeInput()
        {
            CBoxDrivingLisenceType.DataSource = clsDrivingLicenseType.GetAllNames().DefaultView;
            CBoxDrivingLisenceType.DisplayMember = "Name";
        }

        private int _SaveAddress()
        {
            address = new clsAddress() { Country = txtboxBirthPlace.Text ?? "", State = CBoxState.Text ?? "", LocalAddress = txtboxAddress.Text ?? "" };
            address.Save();
            return address.AddressID;
        }
        private int _SaveContact()
        {
            contact = new clsContact() { Email = txtbxEmail.Text ?? "", Phone = txtbxPhone.Text ?? "", AdditionalContact = txtbxAdditionalContact.Text ?? "" };
            contact.Save();
            return contact.contactID;
        }


        private int _SaveDrivingLisence()
        {
            drivingLicense = new clsDrivingLicense()
            {
                Number = txtBxDrivingLisenceNumber.Text , 
                Type = CBoxDrivingLisenceType.Text , 
                CAP = txtBoxCAP.Text
            };
            if (drivingLicense.Save())
                return drivingLicense.DrivingLicenseID;
            return -1; 
        }




        private int _SavePerson()
        {
            person = new clsPerson()
            {
                FirstName = txtboxFirstName.Text ?? "",
                LastName = txtboxLastName.Text ?? "",
                FirstName_Arabic = txtboxFirstName_Arabic.Text ?? "",
                LastName_Arabic = txtboxLastName_Arabic.Text ?? "",
                ContactID = _SaveContact(),
                AddressID = _SaveAddress()

            };

            if (person.Save())
                return person.PersonID;
            return -1; 
        }

        private int _SaveNationalCard()
        {
            nationalCard = new clsNationalCard()
            {
                Type = CboxIdentityType.Text ?? "",
                CardNumber = txtbxIdentityNumber.Text ?? "",
                EndDate = Convert.ToDateTime(dateEndIdentity.Value)
            };
            if (nationalCard.Save())
                return nationalCard.NamtionalCardID;

            return -1; 
        }




        private bool _SaveInstructor()
        {
            instructor = new clsInstructor()
            {

                PersonID = _SavePerson(),
                UserName = person?.FirstName + " " + person?.LastName , 
                Gender = _GetGender(),
                DrivingLicenseID = _SaveDrivingLisence()  , 
                NationalCardID  = _SaveNationalCard() 

            };

            if (instructor.Save())
                return true;
            return false; 

        }




        private void pictureBox1_Click(object sender, EventArgs e)
        => Close(); 
        private void guna2Button2_Click(object sender, EventArgs e)
        =>  Close();

        private void btnSubmit_Click(object sender, EventArgs e)
        {

            if (InputRequiredValidation())
            {
                //this is the code to save on DB 
                if (_SaveInstructor())
                {
                    // MessageBox.Show("student is saved successfully with ID = " + student.StudentID);
                    statusMessageForm = new StatusMessageForm("Instructor Saved Successfully .");
                    statusMessageForm.ShowSuccess();
                    OnInstructorAddedEventHundler?.Invoke(); 
                    Close();
                }
                else
                {
                    statusMessageForm = new StatusMessageForm("Instructor not Saved .");
                    statusMessageForm.ShowFailed();
                }
            }
            else
                MessageBox.Show("هناك معلومات مفقودة", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
    }
    
}
