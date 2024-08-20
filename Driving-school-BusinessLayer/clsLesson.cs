using DrivingSchool_DataAccessLayer;
using System;

namespace Driving_school_BusinessLayer
{
    public class clsLesson
    {
        enum enMode { AddNew = 0, Update = 1 }
        enMode Mode = enMode.AddNew;

        public int LessonID { get; set; }
        public int CandidateFileID { get; set; }
        public DateTime LessonDate { get; set; }
        public string Notes { get; set; }
        public int ApplicationInstructorID { get; set; }
        public bool IsCompleted { get; set; }

        public clsLesson()
        {
            LessonID = -1;
            CandidateFileID = -1;
            LessonDate = DateTime.MinValue;
            Notes = string.Empty;
            ApplicationInstructorID = -1;
            IsCompleted = false;
            Mode = enMode.AddNew;
        }

        private clsLesson(int lessonID, int candidateFileID, DateTime lessonDate, string notes, int applicationInstructorID, bool isCompleted)
        {
            LessonID = lessonID;
            CandidateFileID = candidateFileID;
            LessonDate = lessonDate;
            Notes = notes;
            ApplicationInstructorID = applicationInstructorID;
            IsCompleted = isCompleted;
            Mode = enMode.Update;
        }

        private bool _AddNewLesson()
        {
            LessonID = clsLessonDataAccess.AddNewLesson(CandidateFileID, LessonDate, Notes, ApplicationInstructorID, IsCompleted);
            return LessonID != -1;
        }

        private bool _UpdateLesson()
        {
            return clsLessonDataAccess.UpdateLesson(LessonID, CandidateFileID, LessonDate, Notes, ApplicationInstructorID, IsCompleted);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewLesson())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;
                case enMode.Update:
                    return _UpdateLesson();
            }
            return false;
        }

        public static clsLesson Find(int ID)
        {
            int _CandidateFileID = -1;
            DateTime _LessonDate = DateTime.MinValue;
            string _Notes = string.Empty;
            int _ApplicationInstructorID = -1;
            bool _IsCompleted = false;

            if (clsLessonDataAccess.GetLessonInfoByID(ID, ref _CandidateFileID, ref _LessonDate, ref _Notes, ref _ApplicationInstructorID, ref _IsCompleted))
            {
                return new clsLesson(ID, _CandidateFileID, _LessonDate, _Notes, _ApplicationInstructorID, _IsCompleted);
            }
            return null;
        }
    }
}
