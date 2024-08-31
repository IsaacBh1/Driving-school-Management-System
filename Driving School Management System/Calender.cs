using System;
using System.Globalization;
using System.Windows.Forms;

namespace Driving_School_Management_System
{
    public partial class Calender : UserControl
    {
        public static int _year , _month ; 
        public Calender()
        {
            InitializeComponent();
            ShowDays(DateTime.Now.Month, DateTime.Now.Year); 
        }

        private void btnnextMonth_Click(object sender, EventArgs e)
        {
            _month++; 
            if(_month > 12)
            {
                _month = 1;
                _year++; 
            }
            ShowDays(_month, _year);
        }

        private void btnprevMonth_Click(object sender, EventArgs e)
        {
            _month--;
            if (_month < 1)
            {
                _month = 12;
                _year--;
            }
            ShowDays(_month, _year);
        }

        public void ShowDays(int Month , int Year)
        {
            flowLayoutPanel1.Controls.Clear(); 
            _year = Year ;
            _month = Month ;
            string monthName = new DateTimeFormatInfo().GetMonthName(Month);
            lblMonth.Text = monthName.ToUpper() + " "+ Year.ToString() ;
            DateTime StartOfTheMonth = new DateTime(Year , Month , 1);
            int Day = DateTime.DaysInMonth(Year, Month); 
            int week = Convert.ToInt32(StartOfTheMonth.DayOfWeek.ToString("d"))+1;
            for (int i = 1; i < week; i++)
            {
                CalenderDay Cd = new CalenderDay("" , 0 , 0);
                flowLayoutPanel1.Controls.Add(Cd); 
            }
            for (int i = 1; i <= Day; i++)
            {
                CalenderDay Cd = new CalenderDay(i.ToString(), 0, 0);
                flowLayoutPanel1.Controls.Add(Cd);
            }
        }
    }
}
