using System;
using System.Windows.Forms;

namespace Driving_School_Management_System.Forms
{
    public partial class ConfirmsClosingMoneyBankForm : Form
    {

        public delegate void CloseMoneyBox();

        public event CloseMoneyBox BoxClosedbtnClicked ;
        public ConfirmsClosingMoneyBankForm()
        {
            InitializeComponent();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close(); 
        }

        private void  guna2Button1_Click(object sender, EventArgs e)
        {
            BoxClosedbtnClicked?.Invoke();
            Close(); 
        }
    }
}
