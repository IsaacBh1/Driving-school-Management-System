using Driving_school_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Driving_School_Management_System.Forms
{
    public partial class AddExamForm : Form
    {


        //----------------------------------------------------------------------------------
        //---------------------------this is for window properties ------------------------------
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

        private void Form_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }



        clsExam exam = null;
        public AddExamForm()
        {
            InitializeComponent();
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private bool IsIDExists()
        {
            return clsCondidateFile.IsCondidateFileExists(Convert.ToInt32(txtboxID.Text));
        }



        private int GetExamType()
        {
            return rdobtnTheo.Checked ? 1 : 2;
        }

        private bool CheckExamInputs()
        {
            return string.IsNullOrEmpty(txtboxID.Text) && string.IsNullOrEmpty(CboxState.Text) && IsIDExists();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            StoreExam();
        }
        private void StoreExam()
        {
            if (!CheckExamInputs())
            {

                exam = new clsExam()
                {

                    ExamTypeID = GetExamType(),
                    CandidateFileID = Convert.ToInt32(txtboxID.Text),
                    ExamDate = dateTimeExam.Value,
                    Result = numupdownResult.Text
                };
            };
        }

    }
}
