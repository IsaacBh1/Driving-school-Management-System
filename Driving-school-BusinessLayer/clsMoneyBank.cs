using DrivingSchool_DataAccessLayer;
using System.Data;

namespace Driving_school_BusinessLayer
{
    public class clsMoneyBank
    {
        enum enMode { AddNew = 0, Update = 1 }
        enMode Mode = enMode.AddNew;

        public int MoneyBankID { get; set; }
        public decimal InitialAmount { get; set; }
        public decimal Expences { get; set; }
        public decimal InternalAmount { get; set; }
        public bool IsClosed { get; set; }

        public clsMoneyBank()
        {
            MoneyBankID = -1;
            InitialAmount = 0;
            InternalAmount = 0;
            IsClosed = false;
            Expences = 0; 
            Mode = enMode.AddNew;
        }

        private clsMoneyBank(int moneyBankID, decimal initialAmount, decimal expences, decimal internalAmount, bool isClosed = false)
        {
            MoneyBankID = moneyBankID;
            InitialAmount = initialAmount;
            InternalAmount = internalAmount;
            IsClosed = isClosed;
            Expences = expences; 
            Mode = enMode.Update;
        }

        public void AddPayment(decimal price)
        {
            InternalAmount += price; 
        }

        public bool AddExpence(decimal price)
        {
            if (InternalAmount - price < 0 || price <= 0)
                return false;
            InternalAmount -= price;
            Expences += price; 
            return true;
        }

        private bool _AddNewMoneyBank()
        {
            MoneyBankID = clsMoneyBankDataAccess.AddNewMoneyBank(InitialAmount, Expences, InternalAmount, IsClosed);
            return MoneyBankID != -1;
        }

        private bool _UpdateMoneyBank()
        {
            return clsMoneyBankDataAccess.UpdateMoneyBank(MoneyBankID, InitialAmount, Expences, InternalAmount, IsClosed);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewMoneyBank())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;
                case enMode.Update:
                    return _UpdateMoneyBank();
            }
            return false;
        }

        public static clsMoneyBank Find(int ID)
        {
            decimal _InitialAmount = 0;
            decimal _Expence = 0;
            decimal _InternalAmount = 0;
            bool _IsClosed = false;

            if (clsMoneyBankDataAccess.GetMoneyBankInfoByID(ID, ref _InitialAmount, ref _Expence, ref _InternalAmount, ref _IsClosed))
            {
                return new clsMoneyBank(ID, _InitialAmount, _Expence, _InternalAmount, _IsClosed);
            }
            return null;
        }
        public static int GetCurrentMoneyBank()
        {
            return clsMoneyBankDataAccess.GetCurrentMoneyBank(); 
        }

        public static bool CloseCurrentMoneyBank()
        {
            return clsMoneyBankDataAccess.CloseCurrentMonneyBank(); 
        }

        public static DataTable GetAllMoneyBanks()
        => clsMoneyBankDataAccess.GetAllMoneyBanks();


    }
}
