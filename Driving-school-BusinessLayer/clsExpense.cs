using DrivingSchool_DataAccessLayer;
using System.Data;

namespace Driving_school_BusinessLayer
{
    public class clsExpense
    {
        enum enMode { AddNew = 0, Update = 1 }
        enMode Mode = enMode.AddNew;

        public int ExpenseID { get; set; }
        public int ExpenseTypeID { get; set; }
        public decimal Amount { get; set; }
        public string AdditionalNotes { get; set; }
        public int MoneyBankID { get; set; }

        public clsExpense()
        {
            ExpenseID = -1;
            ExpenseTypeID = -1;
            Amount = 0;
            AdditionalNotes = string.Empty;
            MoneyBankID = -1;
            Mode = enMode.AddNew;
        }

        private clsExpense(int expenseID, int expenseTypeID, decimal amount, string additionalNotes, int moneyBankID)
        {
            ExpenseID = expenseID;
            ExpenseTypeID = expenseTypeID;
            Amount = amount;
            AdditionalNotes = additionalNotes;
            MoneyBankID = moneyBankID;
            Mode = enMode.Update;
        }

        private bool _AddNewExpense()
        {
            ExpenseID = clsExpenseDataAccess.AddNewExpense(ExpenseTypeID, Amount, AdditionalNotes, MoneyBankID);
            return ExpenseID != -1;
        }

        private bool _UpdateExpense()
        {
            return clsExpenseDataAccess.UpdateExpense(ExpenseID, ExpenseTypeID, Amount, AdditionalNotes, MoneyBankID);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewExpense())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;
                case enMode.Update:
                    return _UpdateExpense();
            }
            return false;
        }

        public static clsExpense Find(int ID)
        {
            int _ExpenseTypeID = -1;
            decimal _Amount = 0;
            string _AdditionalNotes = string.Empty;
            int _MoneyBankID = -1;

            if (clsExpenseDataAccess.GetExpenseInfoByID(ID, ref _ExpenseTypeID, ref _Amount, ref _AdditionalNotes, ref _MoneyBankID))
            {
                return new clsExpense(ID, _ExpenseTypeID, _Amount, _AdditionalNotes, _MoneyBankID);
            }
            return null;
        }

        public static DataTable GetAllExpencesTypes()
        {
            return clsExpenceTypeDataAccess.GetAllExpenceTypes();
        }

    }
}
