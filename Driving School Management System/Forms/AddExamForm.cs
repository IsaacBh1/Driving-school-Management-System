using Driving_school_BusinessLayer;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Driving_School_Management_System.Forms
{
    public partial class AddExamForm : Form
    {

        //lblNotFoundStudent

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

        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }



        clsExam exam = new clsExam();
        StatusMessageForm statusMessageForm = null;
        public delegate void AddNewExam();
        public event AddNewExam OnExamAddedEventHundler; 
        public AddExamForm()
        {
            InitializeComponent();
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

        }

        public AddExamForm(int conidateFileId)
        {
            InitializeComponent();
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            clsCondidateFile condidateFile = clsCondidateFile.Find(conidateFileId);
            if(!(condidateFile is null))
            {
                txtboxID.Text = condidateFile.CandidateFileID.ToString();
                txtboxID.Enabled = false; 
            }
        }


        public AddExamForm(int ExamId, bool IsUpdateMode)
        {
            InitializeComponent();
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            exam = clsExam.Find(ExamId);
            clsCondidateFile condidateFile = clsCondidateFile.Find(exam.CandidateFileID);
            if (!(condidateFile is null) && IsUpdateMode)
            {
                txtboxID.Text = condidateFile.CandidateFileID.ToString();
                txtboxID.Enabled = false;
                LoadExamInfosToForm(); 
            }
        }



        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private bool IsCondidateFileExists()
        {
            bool IsCondidateFileExists = false; 
            if (int.TryParse(txtboxID.Text , out int ID)) {

            IsCondidateFileExists = clsCondidateFile.IsCondidateFileExists(ID);
            if (!IsCondidateFileExists)
            {
                lblNotFoundStudent.Text = "ملف المرشح غير موجود"; 
            }

            }
            return IsCondidateFileExists;
        }


        private int GetExamType()
        {
            return rdobtnTheo.Checked ? 1 : 2;
        }

        private bool CheckExamInputs()
        {
            return !string.IsNullOrEmpty(txtboxID.Text) && !string.IsNullOrEmpty(CboxState.Text) && IsCondidateFileExists();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            SaveExam(); 
        }
        private bool StoreExam()
        {
            exam.ExamTypeID = GetExamType();
            exam.CandidateFileID = Convert.ToInt32(txtboxID.Text);
            exam.ExamDate = dateTimeExam.Value;
            exam.Result = Convert.ToInt32(numupdownResult.Text);
            exam.AdditionalNotes = txtboxAdditionalNotes.Text;
            exam.Situation = CboxState.Text;
            exam.timeOfExam = new TimeSpan(Convert.ToInt32(dateTimeExam.Value.Hour), Convert.ToInt32(dateTimeExam.Value.Minute), 0); 
            return exam.Save(); 
        }


        private void LoadExamInfosToForm()
        {
            dateTimeExam.Value = exam.ExamDate;
            numupdownResult.Text = exam.Result.ToString();
            txtboxAdditionalNotes.Text = exam.AdditionalNotes;
            CboxState.Text = exam.Situation;
            dateTimeExam.Value = new DateTime(exam.ExamDate.Year, exam.ExamDate.Month, exam.ExamDate.Day, Convert.ToInt16 (exam.timeOfExam.Hours),Convert.ToInt16(exam.timeOfExam.Minutes), 0);
        }

        private void SaveExam()
        {
            if (CheckExamInputs())
            {
                //this is the code to save on DB 
                if (StoreExam())
                {
                    // MessageBox.Show("student is saved successfully with ID = " + student.StudentID);
                    statusMessageForm = new StatusMessageForm("Exam Saved Successfully");
                    statusMessageForm.ShowSuccess();
                    OnExamAddedEventHundler?.Invoke();
                    Close();
                }
                else
                {
                    statusMessageForm = new StatusMessageForm("Exam not Saved");
                    statusMessageForm.ShowFailed();
                }
            }
            else
                MessageBox.Show("هناك معلومات مفقودة", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Close(); 
        }
    }
}
