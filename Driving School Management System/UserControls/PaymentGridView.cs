using System;
using System.Windows.Forms;

namespace Driving_School_Management_System.UserControls
{
    public partial class PaymentGridView : UserControl
    {


        

        public int FileID {  get; set; }
        public decimal AllAmount {  get; set; }
        public decimal RemainingAmount {  get; set; } 

        
        public PaymentGridView()
        {
            InitializeComponent();
        }


        public PaymentGridView(int ID , decimal AllAmount , decimal RemainingAmount)
        {
            InitializeComponent();
            FileID = ID;
            this.AllAmount = AllAmount;
            this.RemainingAmount = RemainingAmount;
            lblFileID.Text = FileID.ToString();
            lblAmount.Text = AllAmount.ToString();
            lblReminder.Text = RemainingAmount.ToString();
            numericUpDownAmount.Maximum = Convert.ToInt32(RemainingAmount);

        }




      
    }
}
