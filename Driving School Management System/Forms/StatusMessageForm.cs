using Driving_School_Management_System.UserControls;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Driving_School_Management_System.Forms
{
    public partial class StatusMessageForm : Form
    {
        private string Message;
        Timer timer; 
        public StatusMessageForm(string message)

        {
            timer = new Timer();
            timer.Interval = (2 * 1000); // 1 mins
            timer.Tick += new EventHandler(timer1_Tick);
            timer.Start();

            InitializeComponent();
            Message = message;
        }

        private void timer1_Tick(object sender, EventArgs e)=>Close();
        

        private void FormLocation()
        {
            Rectangle res = Screen.PrimaryScreen.Bounds;
            this.Location = new Point(res.Width - Size.Width);
            StartPosition = FormStartPosition.Manual;
            //Location = new Point(700 , 0);
            TopMost = true;

        }

        public void ShowSuccess() {
            SavedSuccessfullyMessage message1 = new SavedSuccessfullyMessage(this.Message);
            
            message1.CreateControl(); 
            message1.Dock = DockStyle.Fill;
            Controls.Add(message1);
            FormLocation(); 


           this.Show();
       }

        public void ShowFailed()
        {
            NotSavedMessage message1 = new NotSavedMessage(this.Message);

            message1.CreateControl();
            message1.Dock = DockStyle.Fill;
            Controls.Add(message1);
            FormLocation(); 
            this.Show();
        }

        
    }
}
