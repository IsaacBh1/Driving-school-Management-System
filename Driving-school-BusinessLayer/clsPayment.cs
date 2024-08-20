using DrivingSchool_DataAccessLayer;

namespace Driving_school_BusinessLayer
{
    public class clsPayment
    {
        enum enMode { AddNew = 0, Update = 1 }
        enMode Mode = enMode.AddNew;

        public int PaymentID { get; set; }
        public decimal FullAmount { get; set; }
        public decimal AmountPayed { get; set; }
        public int MoneyBankID { get; set; }

        public clsPayment()
        {
            PaymentID = -1;
            FullAmount = 0;
            AmountPayed = 0;
            MoneyBankID = -1;
            Mode = enMode.AddNew;
        }

        private clsPayment(int paymentID, decimal fullAmount, decimal amountPayed, int moneyBankID)
        {
            PaymentID = paymentID;
            FullAmount = fullAmount;
            AmountPayed = amountPayed;
            MoneyBankID = moneyBankID;
            Mode = enMode.Update;
        }

        private bool _AddNewPayment()
        {
            PaymentID = clsPaymentDataAccess.AddNewPayment(FullAmount, AmountPayed, MoneyBankID);
            return PaymentID != -1;
        }

        private bool _UpdatePayment()
        {
            return clsPaymentDataAccess.UpdatePayment(PaymentID, FullAmount, AmountPayed, MoneyBankID);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewPayment())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;
                case enMode.Update:
                    return _UpdatePayment();
            }
            return false;
        }

        public static clsPayment Find(int ID)
        {
            decimal _FullAmount = 0;
            decimal _AmountPayed = 0;
            int _MoneyBankID = -1;

            if (clsPaymentDataAccess.GetPaymentInfoByID(ID, ref _FullAmount, ref _AmountPayed, ref _MoneyBankID))
            {
                return new clsPayment(ID, _FullAmount, _AmountPayed, _MoneyBankID);
            }
            return null;
        }
    }
}