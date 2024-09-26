using Driving_school_BusinessLayer;
using Driving_School_Management_System.UtilityClasses.Driving_School_Management_System;
using DrivingSchool_BusinesseLayer;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;



namespace Driving_School_Management_System.Forms
{

    public partial class AddStudentForm : Form
    {




    [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
      (
          int nLeftRect,     // x-coordinate of upper-left corner
          int nTopRect,      // y-coordinate of upper-left corner
          int nRightRect,    // x-coordinate of lower-right corner
          int nBottomRect,   // y-coordinate of lower-right corner
          int nWidthEllipse, // width of ellipse
          int nHeightEllipse // height of ellipse
      );
    



        private StatusMessageForm statusMessageForm; 
        private bool InformationCorrect = true;
        private clsPerson person;
        private clsAddress address;
        private clsContact contact;
        private clsStudent student;
        private clsNationalCard nationalCard;
        
        public EventHandler<AddStudentEventArgs> StudentAdded { get; set; }

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


        public AddStudentForm()
        {
            InitializeComponent();
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            //this.Size = Screen.PrimaryScreen.WorkingArea.Size;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Close();
        }
        //Guna.UI2.WinForms.Guna2TextBox
        //MetroFramework.Controls.MetroComboBox
        //TextBox
        public void CheckField(Control txtBoxField)
        {
            if (txtBoxField is TextBox textBox)
            {
                textBox.BackColor = string.IsNullOrEmpty(textBox.Text) ? Color.IndianRed : Color.White;

                InformationCorrect = !string.IsNullOrEmpty(textBox.Text) && InformationCorrect;
            }
        }
        private int _SaveAddress()
        {
            address = new clsAddress() { Country = txtboxBirthPlace.Text ?? "", State = CBoxState.Text ?? "", LocalAddress = txtboxAddress.Text ?? ""};
            address.Save();
            return address.AddressID;
        }
        private int _SaveContact()
        {
            contact = new clsContact() { Email = txtbxEmail.Text ?? "", Phone = txtbxPhone.Text ?? "", AdditionalContact = txtbxAdditionalContact.Text ?? "" };
            contact.Save();
            return contact.contactID;
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
            
            person.Save();
            return person.PersonID;


        }
        private int _SaveNationalCard()
        {
            nationalCard = new clsNationalCard()
            {
                Type = CboxIdentityType.Text ?? "",
                CardNumber = txtbxIdentityNumber.Text ?? "",
                EndDate = Convert.ToDateTime(dateEndIdentity.Value)
            };
            nationalCard.Save();
            return nationalCard.NamtionalCardID;
        }
        private bool _SaveStudent()
        {
           student = new clsStudent() {
                PersonID = _SavePerson(),
                BirthDate = Convert.ToDateTime(dTBirthDate.Value),
                BirthPlace = txtboxBirthPlace.Text ?? "",
                Gender = _GetGender() , 
                NationalCardID = _SaveNationalCard() , 
                UserName = txtbxIdentityNumber.Text ?? "" 
           };
            return student.Save(); 
        }
        private bool _GetGender()
        {
            return true ? RbtnMale.Checked : false; 
        }

        //Guna.UI2.WinForms.Guna2TextBox
        //MetroFramework.Controls.MetroComboBox
        //TextBox
        private void CheckPersonInformations()
        {
            InformationCorrect = true; 
            CheckField(txtboxFirstName_Arabic);
            CheckField ( txtboxLastName_Arabic);
            CheckField(txtboxFirstName);
            CheckField(txtboxLastName);
            CheckField(txtboxBirthPlace);
            CheckField(txtbxPhone); ;
            CheckField(CboxIdentityType);
            CheckField(txtbxIdentityNumber);
            CheckField(txtbxEmail);
        }



        private void btnSubmit_Click_1(object sender, EventArgs e)
        {

            CheckPersonInformations();
            //CheckField( CBoxState,e)&&

            if (InformationCorrect)
            {
                //this is the code to save on DB 
                if (_SaveStudent())
                {
                    // MessageBox.Show("student is saved successfully with ID = " + student.StudentID);
                    statusMessageForm = new StatusMessageForm("Student Saved Successfully .");
                    statusMessageForm.ShowSuccess(); 
                    Close();
                }
                else
                {
                    statusMessageForm = new StatusMessageForm("Student not Saved .");
                    statusMessageForm.ShowFailed(); 
                }
            }
            else
                MessageBox.Show("هناك معلومات مفقودة", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

    }
}
