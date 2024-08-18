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
        public MainForm()
        {
            InitializeComponent();
            ShowMainWindow();

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
            this.WindowState = FormWindowState.Minimized; 
        }

        private void ShowMainWindow()
        {

            if (mainWindow is null)
            {
                mainWindow = new MainWindow(); 
                mainWindow.MdiParent= this;
                mainWindow.Dock = DockStyle.Fill;
                mainWindow.Show();


            }
            else
            {
                mainWindow.Activate(); 
            }

        }

        private void ShowCondidatesWindow()
        {

            if (condidatesWindow is null)
            {
                condidatesWindow = new CondidatesWindow();
                condidatesWindow.MdiParent = this;
                condidatesWindow.Dock = DockStyle.Fill;
                condidatesWindow.Show();

            }
            else
            {
                condidatesWindow.Activate();
            }
        }

        private void btnMain_Click(object sender, EventArgs e)
        {
            previousTabIndex = tabIndex; 
            tabIndex = 1;
            updateTabColor(); 
            ShowMainWindow(); 
        }



        private void btnCondidtes_Click(object sender, EventArgs e)
        {

            previousTabIndex = tabIndex;
            tabIndex = 2;
            updateTabColor();
            ShowCondidatesWindow(); 

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
                    btnMain.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5AF1D");
                    break;

                case 2:
                    btnCondidtes.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5AF1D");
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
            }
        }




    }
}
