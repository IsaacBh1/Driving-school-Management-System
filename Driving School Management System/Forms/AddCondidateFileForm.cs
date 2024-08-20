using DrivingSchool_BusinesseLayer;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Driving_school_BusinessLayer; 
namespace Driving_School_Management_System.Forms
{
    public partial class AddCondidateFileForm : Form
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

        private void Form_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private bool InformationCorrect = true;
        private StatusMessageForm statusMessageForm;
        private clsCondidateFile condidateFile;
        private clsStudent student;
        private clsDrivingLicenseType drivingLicenseType; 
        private clsGroup group;
        private clsPayment payment;
        private clsInstructor Theo_instructor;
        private clsInstructor App_instructor; 



        public AddCondidateFileForm()
        {
            InitializeComponent();
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

        }

        private void pictureBox1_Click(object sender, EventArgs e)=>Close();
        

        private void guna2Button2_Click(object sender, EventArgs e) => Close(); 
       

        public void CheckField(Control txtBoxField)
        {
            if (txtBoxField is Guna.UI2.WinForms.Guna2TextBox GunatextBox)
            {
                GunatextBox.BorderColor = string.IsNullOrEmpty(GunatextBox.Text) ? Color.IndianRed : Color.White;
                InformationCorrect = !string.IsNullOrEmpty(GunatextBox.Text) && InformationCorrect;

            }
            else if(txtBoxField is NumericUpDown NumInput)
            {
                NumInput.BackColor = string.IsNullOrEmpty(NumInput.Text) ? Color.Gray : Color.White;
                InformationCorrect = !string.IsNullOrEmpty(NumInput.Text) && InformationCorrect;
            }
            else if (txtBoxField is MetroFramework.Controls.MetroComboBox MetroInput)
            {
                MetroInput.BackColor = string.IsNullOrEmpty(MetroInput.Text) ? Color.Gray : Color.White;
                InformationCorrect = !string.IsNullOrEmpty(MetroInput.Text) && InformationCorrect;

            }
        }


        public void CheckCondidatesFileInformations()
        {
            InformationCorrect = true; 
            CheckField(txtbxCondidateID); 
            CheckField(txtbxIdentityNumber); 
            CheckField(txtbxPrice); 
            CheckField(CbxDrivingLicenseType); 
            CheckField(CbxGroup); 
            CheckField(CbxPaymentType); 
        }

        private bool _SaveCondidatesFile()
        {
            return true; 
        }


        private void btnSubmit_Click(object sender, EventArgs e)
        {
            CheckCondidatesFileInformations(); 
            if (InformationCorrect)
            {
                //this is the code to save on DB 
                if (_SaveCondidatesFile())
                {
                    // MessageBox.Show("student is saved successfully with ID = " + student.StudentID);
                    statusMessageForm = new StatusMessageForm("File Saved Successfully");
                    statusMessageForm.ShowSuccess();
                    Close();
                }
                else
                {
                    statusMessageForm = new StatusMessageForm("File not Saved");
                    statusMessageForm.ShowFailed();
                }
            }
            else
                MessageBox.Show("هناك معلومات مفقودة", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
    }
}
