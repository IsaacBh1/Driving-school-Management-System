using DrivingSchool_DataAccessLayer;

namespace Driving_school_BusinessLayer
{
    public class clsDrivingLicense
    {
        enum enMode { AddNew  = 0 , Update = 1 }; 
        enMode mode = enMode.AddNew;


        public int DrivingLicenseID { get; set; } 
        public string Number { get; set; }
        public string Type { get; set; }
        public string CAP { get; set; } 
        private clsDrivingLicense(int drivingLicenseID, string number, string type, string CAP)
        {
            DrivingLicenseID = drivingLicenseID;
            Number = number;
            Type = type;
            this.CAP = CAP;
            mode = enMode.Update; 
        }

        public clsDrivingLicense() {

            DrivingLicenseID = -1;
            Number = string.Empty ; 
            Type = string.Empty;
            CAP = string.Empty;
            mode = enMode.AddNew; 

        }


        public static clsDrivingLicense Find(int ID)
        {
            string _Number = "" ; 
            string _Type = "" ; 
            string _CAP = "";

            if (clsDrivingLicenseDataAccess.GetDrivingLicenseInfoByID(ID ,ref _Number ,ref _Type ,ref _CAP))
                return new clsDrivingLicense(ID , _Number , _Type , _CAP);
            
            return null; 
        }


        private bool AddNew()
        {
            DrivingLicenseID = clsDrivingLicenseDataAccess.AddNewDrivingLicense(Number, Type, CAP);
            return DrivingLicenseID != -1; 
        
        }


        private bool Update()
        {
            return clsDrivingLicenseDataAccess.UpdateDrivingLicense(DrivingLicenseID , Number ,  Type , CAP);
        }


        public bool Save()
        {
            switch (mode)
            {
                case enMode.AddNew:
                    if (AddNew())
                    {
                        mode = enMode.Update; 
                        return true; 
                    }
                    return false; 
                    
                case enMode.Update:
                    return Update(); 
            }
            return false; 
        }




    }
}
