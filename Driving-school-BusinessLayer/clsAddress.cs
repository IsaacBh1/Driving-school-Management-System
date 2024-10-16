using DrivingSchool_DataAccessLayer;
using System.Net;
using System.Runtime.InteropServices.WindowsRuntime;

namespace Driving_school_BusinessLayer
{
    public class clsAddress
    {

        enum enMode {AddNew = 0 , Update = 1 }; 
        enMode Mode = enMode.AddNew;
        public int AddressID { get; set; } 
        public string Country { get; set; }
        public string State {  get; set; }
        public string LocalAddress {  get; set; }

        public clsAddress() {

            AddressID = -1; 
            Country = string.Empty;
            State = string.Empty;
            LocalAddress = string.Empty;
            Mode = enMode.AddNew; 
        }

        private clsAddress(int AddressID , string Country  ,string State , string LocalAddress )
        {
            this.AddressID = AddressID; 
            this.State = State;
            this.LocalAddress = LocalAddress;
            this.Country = Country;
            Mode = enMode.Update;
        }

        public string GetFullAddress()
        {
            if (LocalAddress is null)
                return State; 
            if (LocalAddress.Length == 0)
                return State;

            return LocalAddress + " - \n " + State;

        }

        private bool _AddNewAddress()
        {
            AddressID = clsAddressDataAccess.AddNewAddress(Country , State , LocalAddress);
            return (AddressID != -1); 

        }
        private bool _UpdateAddress()
        {
            return clsAddressDataAccess.UpdateAddress(AddressID, Country, State, LocalAddress); 
        }

        public bool Save()
        {
            switch(Mode)
            {
                case enMode.AddNew: 
                    if(_AddNewAddress())
                    {
                        Mode = enMode.Update; 
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return _UpdateAddress(); 
            }
            return false; 
        }



        public static clsAddress Find(int AddressID)
        {
            string _Country = string.Empty ; 
            string _State = string.Empty ; 
            string _LocalAddress = string.Empty; 

            
            if(clsAddressDataAccess.GetAddressInfoByID(AddressID ,ref _Country ,ref _State ,ref _LocalAddress))
            {
                return new clsAddress(AddressID , _Country , _State , _LocalAddress);
            }
            else
            {
                return null; 
            }
        }


        public static int Find(string _Country ,string _State ,string _LocalAddress)
        {
            return clsAddressDataAccess.GetAddressIDByInfo(_Country ,_State ,_LocalAddress);
        }

        public static bool DeleteAddress(int Id)
        {
            return clsAddressDataAccess.DeleteAddress(Id); 
        }









    }
}
