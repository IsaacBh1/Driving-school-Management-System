using DrivingSchool_BusinesseLayer;
using DrivingSchool_DataAccessLayer;
using System.Data;

namespace Driving_school_BusinessLayer
{
    public class clsFuelType
    {


        private clsFuelType(int fuelTypeID, string name)
        {
            FuelTypeID = fuelTypeID;
            Name = name;
        }

        enum enMode { AddNew = 0, Update = 1 }
        enMode Mode = enMode.AddNew;


        public int FuelTypeID { get; set; }  
	    public string Name {  get; set; }

        
        public clsFuelType()
        {
            FuelTypeID = -1;
            Name = string.Empty;
        }

        private bool _AddNewFuelTypes()
        {
            FuelTypeID = clsFuelTypeDataAccess.AddNewFuelType(Name);
            return FuelTypeID != -1; 
        }

        private bool _UpdateFuelTypes()
        {
            return clsFuelTypeDataAccess.UpdateFuelType(FuelTypeID, Name); 
        }


        public bool Save()
        {
            switch(Mode)
            {
                case enMode.AddNew:
                    if (_AddNewFuelTypes())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;
                case enMode.Update:
                    return _UpdateFuelTypes();
            }
            return false;
        }

        public static clsFuelType Find(int ID)
        {


            string _Name = "";
            
            bool IsFound = clsFuelTypeDataAccess.GetFuelTypeInfoByID(ID ,ref _Name);
            if (IsFound)
            {
                return new clsFuelType(ID , _Name);
            }
            else
            {
                return null;
            }

        }


        public static DataTable GetAllFuelTypes()
            => clsFuelTypeDataAccess.GetAllFuelTypes();


    }
}
