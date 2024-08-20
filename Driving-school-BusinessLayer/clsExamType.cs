using DrivingSchool_DataAccessLayer;

namespace Driving_school_BusinessLayer
{
    public class clsExamType
    {
        enum enMode { AddNew = 0, Update = 1 }
        enMode Mode = enMode.AddNew;

        public int ExamTypeID { get; set; }
        public string TypeName { get; set; }

        public clsExamType()
        {
            ExamTypeID = -1;
            TypeName = string.Empty;
            Mode = enMode.AddNew;
        }

        private clsExamType(int examTypeID, string typeName)
        {
            ExamTypeID = examTypeID;
            TypeName = typeName;
            Mode = enMode.Update;
        }

        private bool _AddNewExamType()
        {
            ExamTypeID = clsExamTypeDataAccess.AddNewExamType(TypeName);
            return ExamTypeID != -1;
        }

        private bool _UpdateExamType()
        {
            return clsExamTypeDataAccess.UpdateExamType(ExamTypeID, TypeName);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewExamType())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;
                case enMode.Update:
                    return _UpdateExamType();
            }
            return false;
        }

        public static clsExamType Find(int ID)
        {
            string _TypeName = string.Empty;

            if (clsExamTypeDataAccess.GetExamTypeInfoByID(ID, ref _TypeName))
            {
                return new clsExamType(ID, _TypeName);
            }
            return null;
        }
    }
}
