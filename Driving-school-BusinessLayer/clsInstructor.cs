using DrivingSchool_DataAccessLayer;
using System.Data;

namespace Driving_school_BusinessLayer
{
     public class clsInstructor
    {
        enum enMode { AddNew = 0, Update = 1 };
        enMode Mode = enMode.AddNew;

        public int InstructorID {  get; set; }
        public int PersonID {  get; set; }
        public string UserName { get; set; }
        public bool  Gender { get; set; }
        public int DrivingLicenseID { get; set; }
        public int NationalCardID { get ; set; }
        public clsDrivingLicense DrivingLicence { get; set; }
        public clsNationalCard NationalCard { get; set;}

        private clsInstructor(int instructorID, int personID, string userName, bool gender, int drivingLicenseID)
        {
            InstructorID = instructorID;
            PersonID = personID;
            Gender = gender;
            DrivingLicenseID = drivingLicenseID;
            DrivingLicence = clsDrivingLicense.Find(DrivingLicenseID);
            NationalCard = clsNationalCard.Find(NationalCardID);
            UserName = NationalCard.CardNumber;
            Mode = enMode.Update;

        }

        public clsInstructor()
        {
            InstructorID = -1;
            PersonID = -1;
            UserName = "";
            Gender = true;
            DrivingLicenseID = -1;
            Mode = enMode.AddNew; 
        }

        private bool _AddNewInstructor()
        {
            InstructorID = clsInstructorDataAccess.AddNewInstructor(PersonID, UserName, Gender, DrivingLicenseID, NationalCardID);
            return (InstructorID != -1); 
        }

        private bool _UpdateInstructor()
        {
            return clsInstructorDataAccess.UpdateInstructor(InstructorID, PersonID, UserName, Gender, DrivingLicenseID, NationalCardID); 
        }



        public bool Save()
        {
            switch(Mode)
            {
                case enMode.AddNew: 
                    if(_AddNewInstructor())
                    {
                        Mode = enMode.Update;
                        return true; 
                    }
                    return false;

                case enMode.Update:
                    return _UpdateInstructor(); 
            }

            return false; 
        }


        public static clsInstructor Find(int Id)
        {

            //int _InstructorID = -1 ; 
            int _PersonID  = -1 ; 
            string _UserName = "" ; 
            bool _Gender = true ; 
            int _DrivingLicenseID = -1 ; 
            int _NationalCardID = -1; 


            if (clsInstructorDataAccess.GetInstructorInfoByID(Id  ,ref _PersonID ,ref _UserName ,ref _Gender ,ref _DrivingLicenseID ,ref _NationalCardID))
            {
                return new clsInstructor(Id, _PersonID, _UserName, _Gender, _DrivingLicenseID); 
            }
            return null; 
        }

        public static bool DeleteInstructor(int Id)
        {
            return clsInstructorDataAccess.DeleteInstructor(Id); 
        }

        public static bool InstructorExists(int Id)
        {
            return clsInstructorDataAccess.DeleteInstructor(Id) ;
        }

        public static DataTable GatAllInsructors()
        {
            return clsInstructorDataAccess.GetAllInstructors();
        }


        public static DataTable GatAllInsructorsUserName()
        {
            return clsInstructorDataAccess.GetAllInstructorsUserNames();
        }

        //it will be implemented later on
        public DataTable SearchInstructor(string LastName)
        {
            return null; 
        }


        public static int GetInstructorIDByUserName(string UserName)
        {
            return clsInstructorDataAccess.GetInstructorIDByUserName(UserName); 
        }


        public static string GetInsreuctorUserNameByID(int ID)
        {
            return clsInstructorDataAccess.GetInstructorUserNameByID(ID); 

        }


    }
}
