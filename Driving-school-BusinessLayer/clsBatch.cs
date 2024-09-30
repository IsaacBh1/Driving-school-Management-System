using DrivingSchool_DataAccessLayer;
using System;
using System.Data;

namespace Driving_school_BusinessLayer
{
    public class clsBatch
    {
        enum enMode { AddNew = 0, Update = 1 }
        enMode Mode = enMode.AddNew;

        public int BatchID { get; set; }
        public decimal Price { get; set; }
        public DateTime PaymentDate { get; set; }
        public int PaymentID { get; set; }

        public clsBatch()
        {
            BatchID = -1;
            Price = 0;
            PaymentDate = DateTime.MinValue;
            PaymentID = -1;
            Mode = enMode.AddNew;
        }

        private clsBatch(int batchID, decimal price, DateTime paymentDate, int paymentID)
        {
            BatchID = batchID;
            Price = price;
            PaymentDate = paymentDate;
            PaymentID = paymentID;
            Mode = enMode.Update;
        }

        private bool _AddNewBatch()
        {
            BatchID = clsBatchDataAccess.AddNewBatch(Price, PaymentDate, PaymentID);
            return BatchID != -1;
        }

        private bool _UpdateBatch()
        {
            return clsBatchDataAccess.UpdateBatch(BatchID, Price, PaymentDate, PaymentID);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewBatch())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;
                case enMode.Update:
                    return _UpdateBatch();
            }
            return false;
        }

        public static clsBatch Find(int ID)
        {
            decimal _Price = 0;
            DateTime _PaymentDate = DateTime.MinValue;
            int _PaymentID = -1;

            if (clsBatchDataAccess.GetBatchInfoByID(ID, ref _Price, ref _PaymentDate, ref _PaymentID))
            {
                return new clsBatch(ID, _Price, _PaymentDate, _PaymentID);
            }
            return null;
        }


        public static DataTable GetAllBatchesInforfmations()
        {
            return clsBatchDataAccess.GetAllBatchInformations(); 
        }
    }
}
