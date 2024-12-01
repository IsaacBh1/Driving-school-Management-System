using DrivingSchool_DataAccessLayer;
using System.Data;


namespace Driving_school_BusinessLayer
{
    public class clsDrivingLicenseType
    {

        enum enMode { AddNew = 0 , Update = 1 }
        enMode Mode = enMode.AddNew;

            private clsDrivingLicenseType(int drivingLiceseTypeID, string name, decimal price, bool situation
                , byte numberOfLessons_Theo, byte numberOfLessons_App, 
                string iconImagePath, int instructor_TheoID, int instructor_AppID)
            {
                DrivingLiceseTypeID = drivingLiceseTypeID;
                Name = name;
                Price = price;
                Situation = situation;
                NumberOfLessons_Theo = numberOfLessons_Theo;
                NumberOfLessons_App = numberOfLessons_App;
                IconImagePath = iconImagePath;         
                Instructor_TheoID = instructor_TheoID;
                InstructorTheo = clsInstructor.Find(Instructor_TheoID); 
                Instructor_AppID = instructor_AppID;
                InstructorApp = clsInstructor.Find(Instructor_AppID);
                Mode = enMode.Update; 
            }

        public int DrivingLiceseTypeID {  get; set; }
	    public string Name {  get; set; }
	    public decimal Price {  get; set; }
        public bool Situation {  get; set; }
        public byte NumberOfLessons_Theo {  get; set; }
        public byte NumberOfLessons_App {  get; set; }
        public string IconImagePath {  get; set; }
        public clsInstructor InstructorTheo {  get; set; }
	    public int Instructor_TheoID {  get; set; }
        public clsInstructor InstructorApp { get; set; }
        public int Instructor_AppID {  get; set; }


        public clsDrivingLicenseType()
        {
            DrivingLiceseTypeID = -1;
            Name = string.Empty;
            Price = 0;
            Situation = false;
            NumberOfLessons_Theo = 0; 
            NumberOfLessons_App =  0; 
            IconImagePath = string.Empty;
            Instructor_TheoID = -1;
            Instructor_AppID = -1; 
            Mode = enMode.AddNew; 

        }
        
        private bool _AddNewDrivingLicenseType()
        {
            DrivingLiceseTypeID =  clsDrivingLicenseTypeDataAccess.AddNewDrivingLicenseType(Name, Price, Situation, NumberOfLessons_Theo, NumberOfLessons_App, IconImagePath, Instructor_TheoID, Instructor_AppID) ;
            return  DrivingLiceseTypeID != -1; 
        }


        private bool _UpdateDrivingLicenseType()
        {
            return clsDrivingLicenseTypeDataAccess.UpdateDrivingLicenseType(DrivingLiceseTypeID, Name, Price, Situation, NumberOfLessons_Theo, NumberOfLessons_App, IconImagePath, Instructor_TheoID, Instructor_AppID); 
        }


        public static string GetSituation(int situation)
            => situation == 1 ? "نشط" : "مؤرشف" ;

        public static bool GetSituation(string situation)
          => situation == "نشط" ? true : false;

        public bool Save()
        {
            switch(Mode)
            {
                case enMode.AddNew:
                    if(_AddNewDrivingLicenseType())
                    {
                        Mode = enMode.Update; 
                        return true;
                    }
                    return false;
                case enMode.Update: 
                    return _UpdateDrivingLicenseType();
            }
            return false; 
        }


        public static clsDrivingLicenseType Find(int ID)
        {
            //int _DrivingLiceseTypeID = -1;
            string _Name = string.Empty;
            decimal _Price = 0;
            bool _Situation = false;
            int _NumberOfLessons_Theo = 0;
            int _NumberOfLessons_App = 0;
            string _IconImagePath = string.Empty;
            int _Instructor_TheoID = -1;
            int _Instructor_AppID = -1;

            if (clsDrivingLicenseTypeDataAccess.GetDrivingLicenseTypeInfoByID(ID ,ref _Name ,ref _Price , ref _Situation ,ref _NumberOfLessons_Theo ,ref _NumberOfLessons_App ,ref _IconImagePath ,ref _Instructor_TheoID ,ref _Instructor_AppID))
            {
                return new clsDrivingLicenseType(ID, _Name, _Price, _Situation, (byte)_NumberOfLessons_Theo, (byte)_NumberOfLessons_App, _IconImagePath, _Instructor_TheoID, _Instructor_AppID); 

            }
            return null;
        }

        public static DataTable GetAll()
        {
            return clsDrivingLicenseTypeDataAccess.GetAllDrivingLicenseTypes();
        }


        public static DataTable GetAllNames()
        {
            return clsDrivingLicenseTypeDataAccess.GetAllNamesDrivingLicenseTypes(); 
        }
        public static int GetDrivingLicenseTypeIDByName(string Name)
        {
            return clsDrivingLicenseTypeDataAccess.GetDrivingLicenseTypeIDByName (Name);
        }
        public static decimal GetDrivingLicenseTypePriceByID(int ID)
        {
            return clsDrivingLicenseTypeDataAccess.GetDrivingLicenseTypePriceByID(ID); 
        }


        public static string GetDrivingLicenseNameByID(int ID)
            =>clsDrivingLicenseTypeDataAccess.GetDrivingLicenseNameByID(ID);
        


    }
}
