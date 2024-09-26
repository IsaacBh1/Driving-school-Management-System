using Driving_school_BusinessLayer;
using Driving_School_Management_System.UserControls;
using System.Data;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace Driving_School_Management_System.Forms
{
    public partial class InstructorsWindow : Form
    {


        public void LoadInstructorsToUI()
        {
            DataTable Instructors = clsInstructor.GatAllInsructors(); 
            foreach(DataRow row in Instructors.Rows)
                flowLayoutPanelInstructors.Controls.Add(new Instructor((int)row["InstructorID"], row["UserName"].ToString()));
        }


        public InstructorsWindow()
        {
            InitializeComponent();
            LoadInstructorsToUI(); 
        }
    }
}
