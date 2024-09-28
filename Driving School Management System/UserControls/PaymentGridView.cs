using System;
using System.Windows.Forms;

namespace Driving_School_Management_System.UserControls
{
    public partial class PaymentGridView : UserControl
    {


        public event Action AddNewBatchPayment; 

        public decimal AmountPayed { get; set; } = 0; 
        public DateTime PaymentDate {  get; set; } = DateTime.Now;
        public int CondidateFileID {  get; set; }


        public PaymentGridView()
        {
            InitializeComponent();
        }


        public PaymentGridView(int ID , decimal AllAmount , decimal RemainingAmount)
        {
            InitializeComponent();
            CondidateFileID = ID; 
            lblFileID.Text = ID.ToString();
            lblAmount.Text = AllAmount.ToString();
            lblReminder.Text = RemainingAmount.ToString();
            numericUpDownAmount.Maximum = Convert.ToInt32(RemainingAmount);

        }

        private void numericUpDownAmount_ValueChanged(object sender, EventArgs e)
        {
            AmountPayed = Convert.ToDecimal(numericUpDownAmount.Value); 
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            PaymentDate = paymentDateTime.Value; 
        }
    }
}
