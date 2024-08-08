using DrivingSchool_DataAccessLayer;

namespace Driving_school_BusinessLayer
{
    public class clsDrivingLicense
    {

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
        }

        public clsDrivingLicense() {

            DrivingLicenseID = -1;
            Number = string.Empty ; 
            Type = string.Empty;
            CAP = string.Empty;

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


    }
}
