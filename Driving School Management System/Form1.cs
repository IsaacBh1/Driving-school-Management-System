using Driving_School_Management_System.Forms;
using System;
using System.Windows.Forms;

namespace Driving_School_Management_System
{
    public partial class MainForm : Form
    {

        MainWindow mainWindow = null;
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
            this.Close(); 
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

        private void btnMain_Click(object sender, EventArgs e)
        {
            ShowMainWindow(); 
        }
    }
}
