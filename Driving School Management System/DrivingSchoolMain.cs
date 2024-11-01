using Driving_School_Management_System.Forms;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Driving_School_Management_System
{
    public partial class MainForm : Form
    {


        const float speedXPerSecond = 1000f / 30;
        const int bar_width = 40;

        float x_position = 0;
        TimeSpan _lastFrameTime = TimeSpan.Zero;
        Stopwatch _frameTimer = Stopwatch.StartNew();

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            TimeSpan currentFrameTime = _frameTimer.Elapsed;
            float distance = (float)(currentFrameTime - _lastFrameTime).TotalSeconds * speedXPerSecond;

            x_position += distance;
            while (x_position > this.Width) x_position -= this.Width;
            e.Graphics.FillRectangle(Brushes.Black, x_position, 0, bar_width, 500);
            _lastFrameTime = currentFrameTime;

            Invalidate();
        }





        int tabIndex = 1;
        int previousTabIndex = -1;
        MainWindow mainWindow = null;
        CondidatesWindow condidatesWindow = null;
        LessonsWindow lessonsForm = null;
        ExamsWindow examsWindow = null;
        CarsWindow carsWindow = null;
        InstructorsWindow instructorsWindow = null;
        PaymentWindow paymentWindow = null;
        BoxWindow boxWindow = null; 
        ExpencesWindow expencesWindow = null;
        CondidateFileWindow condidateFileWindow = null;
        public MainForm()
        {
            InitializeComponent();
            ShowWindow<MainWindow>(mainWindow);
            DoubleBuffered = true;

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
        bool SideBarExpand = true;
        private void btnMenu_Click(object sender, EventArgs e)
        {
            if (SideBarExpand)
            {
                UserNamePanel.Visible = false; 
                SideBar.Width =  52;             
                SideBarExpand = false;
            }
            else
            {
                UserNamePanel.Visible = true; 
                SideBar.Width = 237;
                SideBarExpand = true;
            }
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized; 
        }
       

        private void ShowWindow<FormType>(Form form) where FormType : Form , new()
        {
            if (form is null)
            {
                form = new FormType();
                form .MdiParent = this;
                form .Dock = DockStyle.Fill;
                form .Show();
            }
            else
            {
                form.Activate();
            }
            updateTabColor();

        }

        private void btnMain_Click(object sender, EventArgs e)
        {
            previousTabIndex = tabIndex; 
            tabIndex = 1;
            ShowWindow<MainWindow>(mainWindow);

        }



        private void btnCondidtes_Click(object sender, EventArgs e)
        {

            previousTabIndex = tabIndex;
            tabIndex = 2;
            //ShowCondidatesWindow(); 
            ShowWindow<CondidatesWindow>(condidatesWindow); 
        }



        private void updateTabColor()
        {
            ChangeTabPrevButtonColor();
            ChangeTabCurrentButtonColor(); 
        }

        private void ChangeTabCurrentButtonColor()
        {
            switch(tabIndex)
            {
                case 1:
                    btnMain.BackColor = ColorTranslator.FromHtml("#E5AF1D");
                    break;
                case 2:
                    btnCondidtes.BackColor = ColorTranslator.FromHtml("#E5AF1D");
                    break;
                case 3:
                    btnFiles.BackColor = ColorTranslator.FromHtml("#E5AF1D");
                    break;
                case 4:
                    btnLessons.BackColor = ColorTranslator.FromHtml("#E5AF1D");
                    break;
                case 5:
                    btnExams.BackColor = ColorTranslator.FromHtml("#E5AF1D");
                    break;
                case 6:
                    btnFinance.BackColor = ColorTranslator.FromHtml("#E5AF1D");
                    break;
                case 7:
                    btnBoxBank.BackColor = ColorTranslator.FromHtml("#E5AF1D");
                    break;
                case 8:
                    btnExpences.BackColor = ColorTranslator.FromHtml("#E5AF1D");
                    break;
                case 9:
                    btnCars.BackColor = ColorTranslator.FromHtml("#E5AF1D");
                    break;
                case 10:
                    btnInstructors.BackColor = ColorTranslator.FromHtml("#E5AF1D");
                    break;
            }
        }


        private void ChangeTabPrevButtonColor()
        {
            switch (previousTabIndex)
            {
                case 1:
                    btnMain.BackColor = Color.Transparent;
                    break;
                case 2:
                    btnCondidtes.BackColor = Color.Transparent;
                    break;
                case 3:
                    btnFiles.BackColor = Color.Transparent;
                    break;
                case 4:
                    btnLessons.BackColor = Color.Transparent;
                    break;
                case 5:
                    btnExams.BackColor = Color.Transparent;
                    break;

                case 6:
                    btnFinance.BackColor = Color.Transparent;
                    break;
                case 7:
                    btnBoxBank.BackColor = Color.Transparent;
                    break;
                case 8:
                    btnExpences.BackColor = Color.Transparent;
                    break;

                case 9:
                    btnCars.BackColor = Color.Transparent;
                    break;
                case 10:
                    btnInstructors.BackColor = Color.Transparent;
                    break;
            }
        }

        private void btnLessons_Click(object sender, EventArgs e)
        {
            previousTabIndex = tabIndex;
            tabIndex = 4;
            ShowWindow<LessonsWindow>(lessonsForm); 

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Lessons_Exams lessons_Exams = new Lessons_Exams();
            lessons_Exams.ShowDialog(); 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            previousTabIndex = tabIndex;
            tabIndex = 5;
            ShowWindow<ExamsWindow>(examsWindow); 
        }

        private void button8_Click(object sender, EventArgs e)
        {
            previousTabIndex = tabIndex;
            tabIndex = 9;
            ShowWindow<CarsWindow>(carsWindow); 
        }

        private void btnInstructors_Click(object sender, EventArgs e)
        {
            previousTabIndex = tabIndex;
            tabIndex = 10;
            ShowWindow<InstructorsWindow>(instructorsWindow); 
        }

        private void btnFinance_Click(object sender, EventArgs e)
        {
            previousTabIndex = tabIndex;
            tabIndex = 6;
            ShowWindow<PaymentWindow>(paymentWindow);  
        }

        private void btnBoxBank_Click(object sender, EventArgs e)
        {
            previousTabIndex = tabIndex;
            tabIndex = 7;
            ShowWindow<BoxWindow>(boxWindow); 
        }

        private void btnExpences_Click(object sender, EventArgs e)
        {
            previousTabIndex = tabIndex;
            tabIndex = 8;
            ShowWindow<ExpencesWindow>(expencesWindow);
        }

        private void btnFiles_Click(object sender, EventArgs e)
        {
            previousTabIndex = tabIndex;
            tabIndex = 3;
            ShowWindow<CondidateFileWindow>(condidateFileWindow);
        }
    }
}
