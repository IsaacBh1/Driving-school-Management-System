using DrivingSchool_DataAccessLayer;
using System;
using System.Data;
using System.Security.Policy;

namespace Driving_school_BusinessLayer
{
    public class clsLesson
    {
        enum enMode { AddNew = 0, Update = 1 }
        enMode Mode = enMode.AddNew;

        public int LessonID { get; set; }
        public int GroupID { get; set; }
        public DateTime LessonDate { get; set; }
        public int Duration_hours { get; set; } = 0;
        public int Duration_minutes { get; set; } = 0;
        public TimeSpan timeSpan { get; set; } = TimeSpan.Zero; 
        public string type { get; set; }
        public int InstructorID { get; set; }


        public clsLesson()
        {
            LessonID = -1;
            GroupID = -1;
            LessonDate = DateTime.MinValue;
            type = string.Empty;
            InstructorID = -1;
            Mode = enMode.AddNew;
        }

        private clsLesson(int lessonID, int candidateFileID, DateTime lessonDate,int Duration_hours , int Duration_minuts,  string _type, int applicationInstructorID, bool isCompleted)
        {
            LessonID = lessonID;
            GroupID = candidateFileID;
            LessonDate = lessonDate;
            type = _type;
            InstructorID = applicationInstructorID;
            this.Duration_hours = Duration_hours;
            this.Duration_minutes = Duration_minuts; 
            Mode = enMode.Update;
        }

        private bool _AddNewLesson()
        {
            LessonID = clsLessonDataAccess.AddNewLesson(type , LessonDate , timeSpan , Duration_hours , Duration_minutes , GroupID , InstructorID);
            return LessonID != -1;
        }

        private bool _UpdateLesson()
        {
            return clsLessonDataAccess.UpdateLesson(LessonID ,  type, LessonDate, timeSpan, Duration_hours, Duration_minutes, GroupID, InstructorID);
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


        public static DataTable GetAllLessons() => clsLessonDataAccess.GetAllLessons();

        public static int GetNumberOfLessonsPerDay(string day) => clsLessonDataAccess.GetNumberOfLessonsPerDay(day);



        /* public static clsLesson Find(int ID)
         {


             if (clsLessonDataAccess.GetLessonInfoByID(ID, ref _CandidateFileID, ref _LessonDate, ref _Notes, ref _ApplicationInstructorID, ref _IsCompleted))
             {
                 //return new clsLesson(ID, _CandidateFileID, _LessonDate, _Notes, _ApplicationInstructorID, _IsCompleted);
             }
             return null;
         }*/

        public static DataTable SearchLessonByID(int ID) => clsLessonDataAccess.SearchLessonByID(ID);
        public static DataTable SearchLessonByLessonType(string Type) => clsLessonDataAccess.SearchLessonByLessonType(Type); 
        public static DataTable SearchLessonByGroup(string group) => clsLessonDataAccess.SearchLessonByGroup(group); 







    }
}
