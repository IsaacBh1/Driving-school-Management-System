using Driving_school_BusinessLayer;
using System;
using System.Data;
using System.Windows.Forms;

namespace Driving_School_Management_System.Forms
{
    public partial class PaymentWindow : Form
    {
        public PaymentWindow()
        {
            InitializeComponent();
            FillPaymentDGVUI(clsBatch.GetAllBatchesInforfmations()); 
        }

        public void FillPaymentDGVUI(DataTable PaymentInformations)
        {
            DGVPayment.Rows.Clear(); 
            foreach (DataRow row in PaymentInformations.Rows)
            {
                DGVPayment.Rows.Add(row[0], row[1], row[2], row[3], row[4], row[5]); 
            }
        }




        private void guna2Button1_Click(object sender, EventArgs e)
        {
           AddPaymentForm paymentForm = new AddPaymentForm();
           paymentForm.ShowDialog();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            FillPaymentDGVUI(clsBatch.GetAllBatchesInforfmations()); 
        }
    }
}
