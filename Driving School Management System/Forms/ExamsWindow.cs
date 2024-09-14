using System;
using System.Windows.Forms;

namespace Driving_School_Management_System.Forms
{
    public partial class ExamsWindow : Form
    {
        public ExamsWindow()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            AddExamForm examForm = new AddExamForm();
            examForm.ShowDialog();
        }
    }
}
