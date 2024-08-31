using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing;

namespace Driving_School_Management_System.Forms
{
    public partial class Lessons_Exams : Form
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

        public Lessons_Exams()
        {
            InitializeComponent();
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        => Close(); 
    }
}
