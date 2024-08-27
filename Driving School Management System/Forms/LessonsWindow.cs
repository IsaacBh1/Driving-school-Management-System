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
    public partial class LessonsWindow : Form
    {
        public LessonsWindow()
        {
            InitializeComponent();
        }

        private void btnSearchStudentinfo_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            AddLessonForm form = new AddLessonForm();
            form.ShowDialog();
        }
    }
}
