using System;
using System.Windows.Forms;

namespace Driving_School_Management_System.Forms
{
    public partial class YesNoDesisionForm : Form
    {

        public delegate void DoOperation();
        public event DoOperation DoOperationEventHundler; 
        public YesNoDesisionForm(string message)
        {
            InitializeComponent();
            Message.Text = message; 
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Close(); 
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            DoOperationEventHundler?.Invoke();
            Close();
        }
    }
}
