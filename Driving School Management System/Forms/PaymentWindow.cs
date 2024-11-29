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
                DGVPayment.Rows.Add(row[0], row[1], row[2], row[3], row[4],Convert.ToDateTime(row[5]).ToString("d")); 
            }
        }

        private void InetializeDrivingLIsenceCbox()
        {
            CbxDrivingLicenseType.DataSource = clsDrivingLicenseType.GetAllNames().DefaultView;
            CbxDrivingLicenseType.DisplayMember = "Name";
        }

        private void RefreshPayment()
        {
            FillPaymentDGVUI(clsBatch.GetAllBatchesInforfmations());
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            FillPaymentDGVUI(clsBatch.GetAllBatchesInforfmations());
        }

        private void SerachBatchFromBatchInformations()
        {
            switch(CBoxBatchesFilter.Text)
            {
                case "الملف":
                    //this is search by file Id
                    if(int.TryParse(textbxCondidateFileID.Text , out int FileID))
                        FillPaymentDGVUI(clsBatch.GetAllBatchInfoByID(FileID));
                    break;
                case "الرخصة":
                    //this is search by driving license name
                    FillPaymentDGVUI(clsBatch.GetAllBatchInfoByDrivingLicense(CbxDrivingLicenseType.Text)); 
                    break; 
            }
        }

        private void btnSearchBatch_Click(object sender, EventArgs e)
        {
            SerachBatchFromBatchInformations();
        }

        private void PaymentWindow_Activated(object sender, EventArgs e)
        {
            FillPaymentDGVUI(clsBatch.GetAllBatchesInforfmations());
        }

        private void btnAddPayment_Click(object sender, EventArgs e)
        {
            AddPaymentForm paymentForm = new AddPaymentForm();
            paymentForm.PaymentHaddedEventHundler += RefreshPayment;
            paymentForm.ShowDialog();
        }
    }
}
