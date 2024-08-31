using System;
using System.Drawing;
using System.Windows.Forms;

namespace Driving_School_Management_System
{
    public partial class ExpensesBar : UserControl
    {
        public string ExpenceName { get; set; } 
        public float ExpenceValue { get; set; } = 0f;

        private Random rnd = new Random();

        private Color color { get; set; }
        public ExpensesBar(string ExpenceName ,float ExpenceValue , int percentage)
        {
            InitializeComponent();
            this.ExpenceName = ExpenceName;
            this.ExpenceValue = ExpenceValue;
            color = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
            ExpenceProgressBar.ProgressColor = color;
            ExpenceProgressBar.ProgressColor2 = color; 
            ExpenceProgressBar.Value = percentage;
            NameOfExpence.Text = ExpenceName.ToString();
            ValueOfExpence.Text = ExpenceValue.ToString() + " DA"; 
         
        }
        public ExpensesBar()
        {
            InitializeComponent(); 
        }
    }
}
