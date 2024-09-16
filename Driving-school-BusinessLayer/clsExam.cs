using DrivingSchool_DataAccessLayer;
using System;
using System.Data;

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
        public int? Result { get; set; }
        public string Situation { get; set; }
        public string AdditionalNotes { get; set; }
        public TimeSpan timeOfExam { get; set; }
        /*
            ExamID 
	        CondidateFileID 
	        ExamTypeID 
	        Result 
	        Situation 
	        DateOfExam  
	        AdditionalNotes 
	        timeOfExam 
         */

        public clsExam()
        {
            ExamID = -1;
            ExamTypeID = -1;
            CandidateFileID = -1;
            ExamDate = DateTime.MinValue;
            Result = 0;
            Mode = enMode.AddNew;
        }

        private clsExam(int examID, int examTypeID, int candidateFileID, DateTime examDate, int result, string situation, string additionalNotes, TimeSpan timeOfExam)
        {
            ExamID = examID;
            ExamTypeID = examTypeID;
            CandidateFileID = candidateFileID;
            ExamDate = examDate;
            Result = result;
            Situation = situation;
            AdditionalNotes = additionalNotes;
            this.timeOfExam = timeOfExam;
        }

        private bool _AddNewExam()
        {
            ExamID = clsExamDataAccess.AddNewExam(CandidateFileID, ExamTypeID, Result, Situation, ExamDate, AdditionalNotes, timeOfExam); 
            return ExamID != -1;
        }

        private bool _UpdateExam()
        {
            return clsExamDataAccess.UpdateExam(ExamID, CandidateFileID, ExamTypeID, Result, Situation, ExamDate, AdditionalNotes, timeOfExam);
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

      /*  public static clsExam Find(int ID)
        {
            int _ExamTypeID = -1;
            int _CandidateFileID = -1;
            DateTime _ExamDate = DateTime.MinValue;
            string _Result = string.Empty;
            int _ApplicationInstructorID = -1;

            if (clsExamDataAccess.GetExamInfoByID(
                ID, ref _ExamTypeID, ref _CandidateFileID, ref _ExamDate, ref _Result, ref _ApplicationInstructorID))
            {
                
            }
            return null;
        }*/

        public static DataTable GetAllExamInformations()
        {
            return clsExamDataAccess.GetAllExamInformations(); 
        }


    }
}
