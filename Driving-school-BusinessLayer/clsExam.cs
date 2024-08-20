using DrivingSchool_DataAccessLayer;
using System;

namespace Driving_school_BusinessLayer
{
    public class clsExam
    {
        enum enMode { AddNew = 0, Update = 1 }
        enMode Mode = enMode.AddNew;

        public int ExamID { get; set; }
        public int ExamTypeID { get; set; }
        public int CandidateFileID { get; set; }
        public DateTime ExamDate { get; set; }
        public string Result { get; set; }
        public int ApplicationInstructorID { get; set; }

        public clsExam()
        {
            ExamID = -1;
            ExamTypeID = -1;
            CandidateFileID = -1;
            ExamDate = DateTime.MinValue;
            Result = string.Empty;
            ApplicationInstructorID = -1;
            Mode = enMode.AddNew;
        }

        private clsExam(int examID, int examTypeID, int candidateFileID, DateTime examDate, string result, int applicationInstructorID)
        {
            ExamID = examID;
            ExamTypeID = examTypeID;
            CandidateFileID = candidateFileID;
            ExamDate = examDate;
            Result = result;
            ApplicationInstructorID = applicationInstructorID;
            Mode = enMode.Update;
        }

        private bool _AddNewExam()
        {
            ExamID = clsExamDataAccess.AddNewExam(ExamTypeID, CandidateFileID, ExamDate, Result, ApplicationInstructorID);
            return ExamID != -1;
        }

        private bool _UpdateExam()
        {
            return clsExamDataAccess.UpdateExam(ExamID, ExamTypeID, CandidateFileID, ExamDate, Result, ApplicationInstructorID);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewExam())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;
                case enMode.Update:
                    return _UpdateExam();
            }
            return false;
        }

        public static clsExam Find(int ID)
        {
            int _ExamTypeID = -1;
            int _CandidateFileID = -1;
            DateTime _ExamDate = DateTime.MinValue;
            string _Result = string.Empty;
            int _ApplicationInstructorID = -1;

            if (clsExamDataAccess.GetExamInfoByID(ID, ref _ExamTypeID, ref _CandidateFileID, ref _ExamDate, ref _Result, ref _ApplicationInstructorID))
            {
                return new clsExam(ID, _ExamTypeID, _CandidateFileID, _ExamDate, _Result, _ApplicationInstructorID);
            }
            return null;
        }
    }
}
