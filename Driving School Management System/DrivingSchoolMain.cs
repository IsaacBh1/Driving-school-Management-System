using Driving_School_Management_System.Forms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Driving_School_Management_System
{
    public partial class MainForm : Form
    {
        int tabIndex = 1;
        int previousTabIndex = -1;
        MainWindow mainWindow = null;
        CondidatesWindow condidatesWindow = null;
        LessonsWindow lessonsForm = null;
        ExamsWindow examsWindow = null;
        CarsWindow carsWindow = null;
        InstructorsWindow instructorsWindow = null;
        PaymentWindow paymentWindow = null; 
        public MainForm()
        {
            InitializeComponent();
            ShowWindow<MainWindow>(mainWindow);
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
                    btnLessons.BackColor = ColorTranslator.FromHtml("#E5AF1D");
                    break;
                case 4:
                    btnExams.BackColor = ColorTranslator.FromHtml("#E5AF1D");
                    break;
                case 5:
                    btnFinance.BackColor = ColorTranslator.FromHtml("#E5AF1D");
                    break;
                case 8:
                    btnCars.BackColor = ColorTranslator.FromHtml("#E5AF1D");
                    break;
                case 9:
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
                    btnLessons.BackColor = Color.Transparent;
                    break;
                case 4:
                    btnExams.BackColor = Color.Transparent;
                    break;

                case 5:
                    btnFinance.BackColor = Color.Transparent;
                    break;

                case 8:
                    btnCars.BackColor = Color.Transparent;
                    break;
                case 9:
                    btnInstructors.BackColor = Color.Transparent;
                    break;
            }
        }

        private void btnLessons_Click(object sender, EventArgs e)
        {
            previousTabIndex = tabIndex;
            tabIndex = 3;
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
            tabIndex = 4;
            ShowWindow<ExamsWindow>(examsWindow); 
        }

        private void button8_Click(object sender, EventArgs e)
        {
            previousTabIndex = tabIndex;
            tabIndex = 8;
            ShowWindow<CarsWindow>(carsWindow); 
        }

        private void btnInstructors_Click(object sender, EventArgs e)
        {
            previousTabIndex = tabIndex;
            tabIndex = 9;
            ShowWindow<InstructorsWindow>(instructorsWindow); 
        }

        private void btnFinance_Click(object sender, EventArgs e)
        {
            previousTabIndex = tabIndex;
            tabIndex = 5;
            ShowWindow<PaymentWindow>(paymentWindow);  
        }
    }
}
