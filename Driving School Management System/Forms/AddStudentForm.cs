using Driving_school_BusinessLayer;
using Driving_School_Management_System.UtilityClasses.Driving_School_Management_System;
using DrivingSchool_BusinesseLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Driving_School_Management_System.Forms
{

    public partial class AddStudentForm : Form
    {

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

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void Form_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
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
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Close();
        }
        public void CheckField(ref Guna.UI2.WinForms.Guna2TextBox txtBoxField)
        {

            if (txtBoxField.Text == string.Empty || txtBoxField is null)
            {

                txtBoxField.BorderColor = Color.IndianRed;
                InformationCorrect = false;
            } else
            {
                txtBoxField.BorderColor = Color.DarkGray;
            }
            InformationCorrect = true && InformationCorrect;
        }
        public void CheckField(ref MetroFramework.Controls.MetroComboBox txtBoxField)
        {
            if (txtBoxField.Text == string.Empty || txtBoxField is null)
            {

                txtBoxField.BackColor = Color.IndianRed;
                InformationCorrect = false;
            }
            txtBoxField.BackColor = Color.DarkGray;
            InformationCorrect = true && InformationCorrect;
        }
        public void CheckField(ref TextBox txtBoxField)
        {
            if (txtBoxField.Text == string.Empty || txtBoxField is null)
            {

                txtBoxField.BackColor = Color.IndianRed;
                InformationCorrect = false;
            }
            txtBoxField.BackColor = Color.DarkGray;
            InformationCorrect = true && InformationCorrect;
        }



        private int _SaveAddress()
        {
            address = new clsAddress() { Country = txtboxBirthPlace.Text ?? "", State = CBoxState.Text ?? "", LocalAddress = txtboxAddress.Text ?? ""};
            address.Save();
            return clsAddress.Find(address.Country, address.State, address.LocalAddress);
        }
        private int _SaveContact()
        {
            contact = new clsContact() { Email = txtbxEmail.Text ?? "", Phone = txtbxPhone.Text ?? "", AdditionalContact = txtbxAdditionalContact.Text ?? "" };
            contact.Save();
            return clsContact.Find(contact.Email, contact.Phone, contact.AdditionalContact);
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
            return clsPerson.Find(person.FirstName, person.LastName, person.FirstName_Arabic, person.LastName_Arabic, person.ContactID, person.AddressID);


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
            return clsNationalCard.Find(nationalCard.Type, nationalCard.CardNumber, nationalCard.EndDate);
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
        private void CheckPersonInformations()
        {
            InformationCorrect = true; 
            CheckField(ref txtboxFirstName_Arabic);
            CheckField(ref txtboxLastName_Arabic);
            CheckField(ref txtboxFirstName);
            CheckField(ref txtboxLastName);
            CheckField(ref txtboxBirthPlace);
            CheckField(ref txtbxPhone); ;
            CheckField(ref CboxIdentityType);
            CheckField(ref txtbxIdentityNumber);
            CheckField(ref txtbxEmail);
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
