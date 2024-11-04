using Driving_school_BusinessLayer;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Driving_School_Management_System.ShowInformationsForms
{
    public partial class ShowFileInformations : Form
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


        //file obj 
        clsCondidateFile condidateFile = null; 


        public ShowFileInformations()
        {
            InitializeComponent();
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20)); 
        }

        public ShowFileInformations(int FileId)
        {
            InitializeComponent();
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            ShowFileInfosOnForm(FileId);
        }

        public void ShowFileInfosOnForm(int FileId)
        {
            condidateFile = clsCondidateFile.Find(FileId);
            if (condidateFile is null)
            {

                MessageBox.Show("حدث خطأ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            loadFileInfoOnWindow(condidateFile);

        }

        private void loadFileInfoOnWindow(clsCondidateFile condidateFile)
        {
            ID.Text = condidateFile.CandidateFileID.ToString();
            nameInAr.Text = condidateFile.Student.Person.FirstName_Arabic;
            appInstructor.Text = condidateFile.Student.Person.FirstName;
            LastNameInAr.Text = condidateFile.Student.Person.LastName_Arabic;
            LastNameinfr.Text = condidateFile.Student.Person.LastName;
            IdentifcationNumber.Text = condidateFile.Student.NationalCard.CardNumber;
            Gender.Text = condidateFile.Student.GetGender();
            birthPlace.Text = condidateFile.Student.BirthPlace;
            birthDate.Text = condidateFile.Student.BirthDate.ToString("d");
            address.Text = condidateFile.Student.Person.Address.GetFullAddress();
            phoneNumber.Text = condidateFile.Student.Person.Contact.Phone;
            Email.Text = condidateFile.Student.Person.Contact.Email;
            UserName.Text = condidateFile.Student.UserName.ToString();
            AdditionalContact.Text = condidateFile.Student.Person.Contact.AdditionalContact;
            drivingLicenceType.Text = condidateFile.drivingLicenseType.Name;
            Activation.Text = condidateFile.GetActivation();
            Archived.Text = condidateFile.GetArchived();
            Group.Text = condidateFile.Group.Name.ToString() ?? "";
            theoInstructor.Text = condidateFile.TheoreticalInstructor?.UserName ?? "";
            appInstructor.Text = condidateFile.ApplicationInstructor?.UserName ?? "";
            DateOfCreation.Text = condidateFile.CreatingFileDate.ToString();
            AdditionalNotes.Text = condidateFile.AdditionalNotes;
            

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close(); 
        }
    }
}
