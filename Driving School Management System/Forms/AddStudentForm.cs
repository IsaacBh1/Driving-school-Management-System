using Driving_school_BusinessLayer;
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
          int nLeftRect,     
          int nTopRect,      
          int nRightRect,    
          int nBottomRect,   
          int nWidthEllipse, 
          int nHeightEllipse 
      );
    



        private StatusMessageForm statusMessageForm; 
        private bool InformationCorrect = true;
        private clsPerson person = new clsPerson();
        private clsAddress address = new clsAddress();
        private clsContact contact = new clsContact();
        private clsStudent student = new clsStudent();
        private clsNationalCard nationalCard = new clsNationalCard();
        public delegate void AddNewStudent();
        public event AddNewStudent OnStudentAddedEventHundler; 


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


        public AddStudentForm(int id)
        {
            InitializeComponent();
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            clsStudent student = clsStudent.Find(id);
            inetializeTextBoxesOnUpdateMode(student); 
        }

        private void inetializeTextBoxesOnUpdateMode(clsStudent student)
        {
            if (!(student is null)) {
                txtboxFirstName.Text = student.Person.FirstName;
                txtboxLastName.Text = student.Person.LastName;
                txtboxFirstName_Arabic.Text = student.Person.FirstName_Arabic;
                txtboxLastName_Arabic.Text = student.Person.LastName_Arabic;
                txtboxBirthPlace.Text = student.Person.Address.Country;
                CBoxState.Text = student.Person.Address.State;
                txtboxAddress.Text = student.Person.Address.LocalAddress;
                txtbxEmail.Text = student.Person.Contact.Email;
                txtbxPhone.Text = student.Person.Contact.Phone;
                txtbxAdditionalContact.Text = student.Person.Contact.AdditionalContact;
                CboxIdentityType.Text = student.NationalCard.Type;
                txtbxIdentityNumber.Text = student.NationalCard.CardNumber;
                dateEndIdentity.Value = student.NationalCard.EndDate; 
            }

            UpdateInformations(student); 
        }


        private void UpdateInformations(clsStudent studentObj)
        {
            person =  clsPerson.Find (studentObj.PersonID);
            address = clsAddress.Find(studentObj.Person.AddressID);
            contact = clsContact.Find (studentObj.Person.ContactID);
            student = clsStudent.Find (studentObj.StudentID); 
            nationalCard = clsNationalCard.Find(studentObj.NationalCardID);

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
            address.Country = txtboxBirthPlace.Text ?? "";
            address.State = CBoxState.Text ?? "";  
            address.LocalAddress = txtboxAddress.Text ?? "";
            address.Save();
            return address.AddressID;
        }
        private int _SaveContact()
        {
            contact.Email = txtbxEmail.Text ?? "";
            contact.Phone = txtbxPhone.Text ?? "";
            contact.AdditionalContact = txtbxAdditionalContact.Text ?? ""; 
            contact.Save();
            return contact.contactID;
        }
        private int _SavePerson()
        {
            person.FirstName = txtboxFirstName.Text ?? "";
            person.LastName = txtboxLastName.Text ?? "";
            person.FirstName_Arabic = txtboxFirstName_Arabic.Text ?? "";
            person.LastName_Arabic = txtboxLastName_Arabic.Text ?? "";
            person.ContactID = _SaveContact();
            person.AddressID = _SaveAddress();            
            person.Save();
            return person.PersonID;


        }
        private int _SaveNationalCard()
        {
            nationalCard.Type = CboxIdentityType.Text ?? "";
            nationalCard.CardNumber = txtbxIdentityNumber.Text ?? "";
            nationalCard.EndDate = Convert.ToDateTime(dateEndIdentity.Value); 
            nationalCard.Save();
            return nationalCard.NamtionalCardID;
        }
        private bool _SaveStudent()
        {

            student.PersonID = _SavePerson(); 
            student.BirthDate = Convert.ToDateTime(dTBirthDate.Value); 
            student.BirthPlace = txtboxBirthPlace.Text ?? ""; 
            student.Gender = _GetGender(); 
            student.NationalCardID = _SaveNationalCard(); 
            student.UserName = txtbxIdentityNumber.Text ?? ""; 
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
            CheckField(txtboxLastName_Arabic);
            CheckField(txtboxFirstName);
            CheckField(txtboxLastName);
            CheckField(txtboxBirthPlace);
            CheckField(txtbxPhone);
            CheckField(CboxIdentityType);
            CheckField(txtbxIdentityNumber);
            CheckField(txtbxEmail);
        }


        private void SaveStudent()
        {

            CheckPersonInformations();
            //CheckField( CBoxState,e)&&

            if (InformationCorrect)
            {
                //this is the code to save on DB 
                if (_SaveStudent())
                {
                    // MessageBox.Show("student is saved successfully with ID = " + student.StudentID);
                    statusMessageForm = new StatusMessageForm("Operation Done Successfully");
                    statusMessageForm.ShowSuccess();
                    OnStudentAddedEventHundler?.Invoke();
                    Close();
                }
                else
                {
                    statusMessageForm = new StatusMessageForm("Operation Failed");
                    statusMessageForm.ShowFailed();
                }
            }
            else
                MessageBox.Show("هناك معلومات مفقودة", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }


        private void btnSubmit_Click_1(object sender, EventArgs e)
        {
            SaveStudent(); 
        }

    }
}
