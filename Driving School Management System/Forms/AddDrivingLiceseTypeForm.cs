using Driving_school_BusinessLayer;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Driving_School_Management_System.Forms
{
    public partial class AddDrivingLiceseTypeForm : Form
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
        


        public delegate void AddNewDrivingLicenseType(); 
        public event AddNewDrivingLicenseType OnAddNewDrivingLicenseTypeEventHundler;
        StatusMessageForm statusMessageForm;
        clsDrivingLicenseType drivingLicenseType;

        public AddDrivingLiceseTypeForm()
        {
            InitializeComponent();
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            _initializeInstructorsCbox();
            drivingLicenseType = new clsDrivingLicenseType();
        }


        public AddDrivingLiceseTypeForm(int id)
        {
            InitializeComponent();
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            _initializeInstructorsCbox();
            drivingLicenseType = clsDrivingLicenseType.Find(id);
            _inetializeInputs(); 
        }

        private void _initializeInstructorsCbox()
        {
            CboxAppInsructor.DataSource = clsInstructor.GatAllInsructorsUserName().DefaultView;
            CboxAppInsructor.DisplayMember = "UserName";
            CboxTheoInsructor.DataSource = clsInstructor.GatAllInsructorsUserName().DefaultView;
            CboxTheoInsructor.DisplayMember = "UserName";
        }


        private bool _CheckInformations()
        {
            return !string.IsNullOrEmpty(txtbxLicenseName.Text) && txtboxPrice.Value > 0; 
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (_CheckInformations())
            {
                //this is the code to save on DB 
                if (_SaveDrivingLicenseType())
                {
                    // MessageBox.Show("student is saved successfully with ID = " + student.StudentID);
                    statusMessageForm = new StatusMessageForm("Operation Done Successfully");
                    OnAddNewDrivingLicenseTypeEventHundler?.Invoke(); 
                    statusMessageForm.ShowSuccess();
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


        private void _inetializeInputs()
        {
            txtbxLicenseName.Text = drivingLicenseType.Name;
            txtboxPrice.Value = drivingLicenseType.Price ;
            numNumberOfLessonsTheo.Value = drivingLicenseType.NumberOfLessons_Theo; 
            numNumberOfLessonsApp.Value = drivingLicenseType.NumberOfLessons_App;
            CboxTheoInsructor.Text = drivingLicenseType.InstructorTheo.UserName; 
            CboxAppInsructor.Text = drivingLicenseType.InstructorApp.UserName;
        }


        private bool _SaveDrivingLicenseType()
        {
             drivingLicenseType.Name = txtbxLicenseName.Text;
             drivingLicenseType.Price = txtboxPrice.Value;
             drivingLicenseType.Situation = clsDrivingLicenseType.GetSituation(cbxSituation.Text);
             drivingLicenseType.NumberOfLessons_Theo =Convert.ToByte(numNumberOfLessonsTheo.Value);
             drivingLicenseType.NumberOfLessons_App = Convert.ToByte(numNumberOfLessonsApp.Value);
             drivingLicenseType.Instructor_TheoID = clsInstructor.GetInstructorIDByUserName(CboxAppInsructor.Text);
             drivingLicenseType.Instructor_AppID = clsInstructor.GetInstructorIDByUserName(CboxTheoInsructor.Text);

            return drivingLicenseType.Save(); 

        }
    }
}
