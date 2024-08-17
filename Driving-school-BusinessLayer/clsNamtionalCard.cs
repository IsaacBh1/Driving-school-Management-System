using DrivingSchool_DataAccessLayer;
using System;
using System.Data;
using System.Runtime.InteropServices;
namespace Driving_school_BusinessLayer
{
    public class clsNationalCard
    {
        enum enMode { AddNew = 0, Update = 1 };
        enMode Mode = enMode.AddNew;

        public int NamtionalCardID { get; set; }
        public string Type { get; set; }
        public string CardNumber { get; set; }
        public DateTime EndDate { get; set; }


        private clsNationalCard(int namtionalCardID, string type, string cardNumber, DateTime endDate)
        {
            NamtionalCardID = namtionalCardID;
            Type = type;
            CardNumber = cardNumber;
            EndDate = endDate;
            Mode = enMode.Update;

        }

        public clsNationalCard() {
            NamtionalCardID = -1;
            Type = string.Empty;
            CardNumber = string.Empty;
            EndDate = DateTime.Now;
            Mode = enMode.AddNew;

        }
        
        private bool _AddNewNationalCard()
        {
            NamtionalCardID = clsNationalCardDataAccess.AddNewNationalCard(Type , CardNumber , EndDate);
            return (this.NamtionalCardID != -1); 
        }



        private bool _UpdateNationalCard()
        {
            return clsNationalCardDataAccess.UpdateNationalCard(NamtionalCardID ,  Type ,CardNumber , EndDate );
        }

        public bool Save()
        {
            switch(Mode)
            {
                case enMode.AddNew:
                    if (_AddNewNationalCard())
                    {
                        Mode = enMode.Update;
                        return true; 
                    }
                    return false;

                case enMode.Update:
                    return (_UpdateNationalCard()); 
            }
            return false; 
        }


        public static clsNationalCard Find(int ID)
        {
            

            string _Type = string.Empty;
            string _CardNumber = string.Empty;
            DateTime _EndDate = DateTime.Now;

            if(clsNationalCardDataAccess.GetNationalCardInfoByID(ID , ref _Type ,ref _CardNumber ,ref _EndDate))
            {
                return new clsNationalCard(ID, _Type, _CardNumber, _EndDate); 
            }
            return null; 
        }

        public static int Find(string _Type,string _CardNumber,DateTime _EndDate)
        {
            return clsNationalCardDataAccess.GetNationalCardIDByInfo(_Type , _CardNumber , _EndDate);
        }

        public static bool GetNationalCardExists(int ID)
        {
            return clsNationalCardDataAccess.IsNationalCardExists(ID); 
        }


        public static bool DeleteNationalCard(int ID)
        {
            return clsNationalCardDataAccess.DeleteNationalCard(ID);
        }


    }
}
