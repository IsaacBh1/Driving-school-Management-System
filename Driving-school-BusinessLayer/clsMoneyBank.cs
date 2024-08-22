using DrivingSchool_DataAccessLayer;

namespace Driving_school_BusinessLayer
{
    public class clsMoneyBank
    {
        enum enMode { AddNew = 0, Update = 1 }
        enMode Mode = enMode.AddNew;

        public int MoneyBankID { get; set; }
        public decimal InitialAmount { get; set; }
        public decimal AllAmount { get; set; }
        public decimal InternalAmount { get; set; }
        public decimal NetProfit { get; set; }
        public bool IsClosed { get; set; }

        public clsMoneyBank()
        {
            MoneyBankID = -1;
            InitialAmount = 0;
            AllAmount = 0;
            InternalAmount = 0;
            NetProfit = 0;
            IsClosed = false;
            Mode = enMode.AddNew;
        }

        private clsMoneyBank(int moneyBankID, decimal initialAmount, decimal allAmount, decimal internalAmount, decimal netProfit, bool isClosed)
        {
            MoneyBankID = moneyBankID;
            InitialAmount = initialAmount;
            AllAmount = allAmount;
            InternalAmount = internalAmount;
            NetProfit = netProfit;
            IsClosed = isClosed;
            Mode = enMode.Update;
        }

        private bool _AddNewMoneyBank()
        {
            MoneyBankID = clsMoneyBankDataAccess.AddNewMoneyBank(InitialAmount, AllAmount, InternalAmount, NetProfit, IsClosed);
            return MoneyBankID != -1;
        }

        private bool _UpdateMoneyBank()
        {
            return clsMoneyBankDataAccess.UpdateMoneyBank(MoneyBankID, InitialAmount, AllAmount, InternalAmount, NetProfit, IsClosed);
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
            decimal _AllAmount = 0;
            decimal _InternalAmount = 0;
            decimal _NetProfit = 0;
            bool _IsClosed = false;

            if (clsMoneyBankDataAccess.GetMoneyBankInfoByID(ID, ref _InitialAmount, ref _AllAmount, ref _InternalAmount, ref _NetProfit, ref _IsClosed))
            {
                return new clsMoneyBank(ID, _InitialAmount, _AllAmount, _InternalAmount, _NetProfit, _IsClosed);
            }
            return null;
        }
        public static int GetCurrentMoneyBank()
        {
            return clsMoneyBankDataAccess.GetCurrentMoneyBank(); 
        }
    }
}
