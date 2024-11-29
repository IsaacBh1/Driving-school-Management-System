using Driving_school_BusinessLayer;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Driving_School_Management_System.Forms
{
    public partial class AddExpenceTypeForm : Form
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


        StatusMessageForm statusMessageForm;
        public delegate void AddnewExpenceType();
        public AddnewExpenceType OnAddingExpenceType; 
        public AddExpenceTypeForm()
        {
            InitializeComponent();
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

        }



        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Close(); 
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (_SaveExpenceType())
            {
                // MessageBox.Show("student is saved successfully with ID = " + student.StudentID);
                statusMessageForm = new StatusMessageForm("Expense type savedSuccessfully");
                statusMessageForm.ShowSuccess();
                OnAddingExpenceType?.Invoke(); 
                Close();
            }
            else
            {
                statusMessageForm = new StatusMessageForm("Operation Failed");
                statusMessageForm.ShowFailed();
            }
        }

        private bool _SaveExpenceType()
        {
            if (string.IsNullOrEmpty(txtboxName.Text)) return false;
            return clsExpense.AddNewExpenceType(txtboxName.Text, txtboxDiscription.Text); 
        }
    }
}
