using DrivingSchool_DataAccessLayer;

namespace Driving_school_BusinessLayer
{
    public class clsGroup
    {
        enum enMode { AddNew = 0, Update = 1 }
        enMode Mode = enMode.AddNew;

        public int GroupID { get; set; }
        public int GroupNumber { get; set; }
        public int NumberOfMembers { get; set; }
        public int DrivingLicenseTypesID { get; set; }

        public clsGroup()
        {
            GroupID = -1;
            GroupNumber = 0;
            NumberOfMembers = 0;
            DrivingLicenseTypesID = -1;
            Mode = enMode.AddNew;
        }

        private clsGroup(int groupID, int groupNumber, int numberOfMembers, int drivingLicenseTypesID)
        {
            GroupID = groupID;
            GroupNumber = groupNumber;
            NumberOfMembers = numberOfMembers;
            DrivingLicenseTypesID = drivingLicenseTypesID;
            Mode = enMode.Update;
        }

        private bool _AddNewGroup()
        {
            GroupID = clsGroupDataAccess.AddNewGroup(GroupNumber, NumberOfMembers, DrivingLicenseTypesID);
            return GroupID != -1;
        }

        private bool _UpdateGroup()
        {
            return clsGroupDataAccess.UpdateGroup(GroupID, GroupNumber, NumberOfMembers, DrivingLicenseTypesID);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewGroup())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;
                case enMode.Update:
                    return _UpdateGroup();
            }
            return false;
        }

        public static clsGroup Find(int ID)
        {
            int _GroupNumber = 0;
            int _NumberOfMembers = 0;
            int _DrivingLicenseTypesID = -1;

            if (clsGroupDataAccess.GetGroupInfoByID(ID, ref _GroupNumber, ref _NumberOfMembers, ref _DrivingLicenseTypesID))
            {
                return new clsGroup(ID, _GroupNumber, _NumberOfMembers, _DrivingLicenseTypesID);
            }
            return null;
        }
    }
}
