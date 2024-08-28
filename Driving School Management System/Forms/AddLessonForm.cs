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


        clsLesson lesson ;  


        
        
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



        public AddLessonForm()
        {
            InitializeComponent();
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            _inetializeCboxes(); 


        }

        private void pictureBox1_Click(object sender, EventArgs e) => Close();

        private void guna2Button2_Click(object sender, EventArgs e) => Close(); 
    
    }
}
