using Driving_school_BusinessLayer;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Driving_School_Management_System.ShowInformationsForms
{
    public partial class ShowStudentInformationsForm : Form
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



        clsStudent student = null ; 

        public ShowStudentInformationsForm()
        {
            InitializeComponent();
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }


        public ShowStudentInformationsForm(int studentid)
        {
            InitializeComponent();
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            ShowStudentInfosOnForm(studentid); 

        }

        private void ShowStudentInfosOnForm(int studentid)
        {
            student = clsStudent.Find(studentid);
            if (student is null)
            {
                MessageBox.Show("حدث خطأ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
             loadStudentInfoOnWindow(student);
            
        }


        private void loadStudentInfoOnWindow(clsStudent student)
        {
            // this is the student infos writen
            ID.Text = student.StudentID.ToString();
            nameInAr.Text = student.Person.FirstName_Arabic;
            NameInfr.Text = student.Person.FirstName;
            LastNameInAr.Text = student.Person.LastName_Arabic;
            LastNameinfr.Text = student.Person.LastName;
            IdentifcationNumber.Text = student.NationalCard.CardNumber; 
            Gender.Text = student.GetGender();
            birthPlace.Text = student.BirthPlace;
            birthDate.Text = student.BirthDate.ToString();
            address.Text = student.Person.Address.GetFullAddress();
            phoneNumber.Text = student.Person.Contact.Phone;
            Email.Text = student.Person.Contact.Email;
            UserName.Text = student.UserName.ToString();
            AdditionalContact.Text = student.Person.Contact.AdditionalContact; 

        }



        private void pictureBox1_Click(object sender, EventArgs e)
        => Close(); 
        
    }
}
