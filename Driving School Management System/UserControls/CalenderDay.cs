using System.Windows.Forms;
using System.Drawing; 
namespace Driving_School_Management_System
{
    public partial class CalenderDay : UserControl
    {
        private bool IsChecked = false;
        string _day; 
        public CalenderDay()
        {
            InitializeComponent();
            BackColor = Color.Gray;

        }
        public CalenderDay(string dayNumber , int numberofLessons , int numberofExams)
        {
            InitializeComponent();
            NumberDay.Text = dayNumber.ToString();
            if (numberofExams > 0 || numberofLessons > 0)
            {
                InetializeCalederDay(numberofLessons, numberofExams);
            }
            _day = dayNumber;
            BackColor = Color.Gray;



        }

        private void InetializeCalederDay(int numberofLessons, int numberofExams)
        {
            Label lbl1 = new Label();
            lbl1.Text = " امتحانات : " + numberofExams.ToString();
            lbl1.ForeColor = Color.Red;
            flowLayoutPanel2.Controls.Add(lbl1);

            Label lbl = new Label();
            lbl.Text = " دروس : " + numberofLessons.ToString() ; ;
            lbl.ForeColor = Color.Blue;
            flowLayoutPanel2.Controls.Add(lbl);
        }


 
        private void flowLayoutPanel1_Paint(object sender, MouseEventArgs e)
        {
            if (IsChecked) BackColor = Color.Gray;
            else BackColor = Color.FromArgb(229, 175, 29);
            IsChecked = !IsChecked;
        }
        private void flowLayoutPanelClick_Paint(object sender, System.EventArgs e)
        {

            if (IsChecked) BackColor = Color.Gray;
            else BackColor = Color.FromArgb(229, 175, 29);
            IsChecked = !IsChecked;
        }
    }
}
