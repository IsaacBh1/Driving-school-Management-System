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
            InetializeDrivingLIsenceCbox(); 
        }

        private void FillPaymentDGVUI(DataTable PaymentInformations)
        {
            DGVPayment.Rows.Clear(); 
            foreach (DataRow row in PaymentInformations.Rows)
            {
                DGVPayment.Rows.Add(row[0], row[1], row[2], row[3], row[4], row[5]); 
            }
        }

        private void InetializeDrivingLIsenceCbox()
        {
            CbxDrivingLicenseType.DataSource = clsDrivingLicenseType.GetAllNames().DefaultView;
            CbxDrivingLicenseType.DisplayMember = "Name";
        }




        private void guna2Button1_Click(object sender, EventArgs e)
        {
           AddPaymentForm paymentForm = new AddPaymentForm();
            paymentForm.PaymentHaddedEventHundler += RefreshPayment; 
           paymentForm.ShowDialog();
        }

        private void RefreshPayment()
        {
            FillPaymentDGVUI(clsBatch.GetAllBatchesInforfmations());
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            FillPaymentDGVUI(clsBatch.GetAllBatchesInforfmations()); 
        }


        /*

         الملف
        الرخصة
         */

        private void SerachBatchFromBatchInformations()
        {
            switch(CBoxBatchesFilter.Text)
            {
                case "الملف":
                    //this is seatch by file number
                    if(int.TryParse(textbxCondidateFileID.Text , out int FileID))
                        FillPaymentDGVUI(clsBatch.GetAllBatchInfoByID(FileID));
                    break;
                case "الرخصة":
                    //this is search by driving license
                    FillPaymentDGVUI(clsBatch.GetAllBatchInfoByDrivingLicense(CbxDrivingLicenseType.Text)); 
                    break; 
            }
        }

        private void btnSearchBatch_Click(object sender, EventArgs e)
        {
            SerachBatchFromBatchInformations();
        }
    }
}
