using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Driving_School_Management_System.Forms
{
    public partial class ExpencesWindow : Form
    {

        ExpencesForm expencesForm = null; 


        public ExpencesWindow()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            expencesForm = new ExpencesForm();
            expencesForm.ShowDialog();
        }
    }
}
