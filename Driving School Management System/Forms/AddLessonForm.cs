using Driving_school_BusinessLayer;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Driving_School_Management_System.Forms
{
    public partial class AddLessonForm : Form
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

        //private bool InformationCorrect = true;
        clsLesson lesson ;
        StatusMessageForm statusMessageForm; 
        public delegate void AddNewLesson();
        public event AddNewLesson OnLessonsAddedEventHundler; 


        private void _initializeGroupsCbox()
        {
            CbxGroup.DataSource = clsGroup.GetAllGroupsNames().DefaultView;
            CbxGroup.DisplayMember = "Name";
        }

        private void _initializeInstructorsCbox()
        {
            CboxInsructor.DataSource = clsInstructor.GatAllInsructorsUserName().DefaultView;
            CboxInsructor.DisplayMember = "UserName";
           
        }

        private void _inetializeCboxes()
        {
            _initializeGroupsCbox();
            _initializeInstructorsCbox(); 
        }

        private string _getLessonType() => rdobtnTheo.Checked ? "نظرية" : "تطبيقية"; 



        public AddLessonForm()
        {
            InitializeComponent();
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            _inetializeCboxes(); 
    
        }

        private void pictureBox1_Click(object sender, EventArgs e) => Close();

        private void guna2Button2_Click(object sender, EventArgs e) => Close();

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            lesson = new clsLesson()
            {
                GroupID = clsGroup.GetGroupIDbyName(CbxGroup.Text),
                InstructorID = clsInstructor.GetInstructorIDByUserName(CboxInsructor.Text),
                Duration_hours = Convert.ToInt32(numUpDwHours.Value),
                Duration_minutes = Convert.ToInt32(numUpDwMins.Value),
                timeSpan = new TimeSpan(Convert.ToInt32(numUpDwTimeHours.Value), Convert.ToInt32(numUpDwTimeMins.Value), 0),
                type = _getLessonType(),
                LessonDate = dateTimeLessaon.Value

            };
            if (lesson.Save())
            {
                statusMessageForm = new StatusMessageForm("Lesson Saved Successfully");
                statusMessageForm.ShowSuccess();
                OnLessonsAddedEventHundler?.Invoke(); 
                Close();
            }
            else
            {
                statusMessageForm = new StatusMessageForm("Lesson not Saved");
                statusMessageForm.ShowFailed();
            }; 
        }
    }
}
