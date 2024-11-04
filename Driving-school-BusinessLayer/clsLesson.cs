using DrivingSchool_DataAccessLayer;
using System;
using System.Data;

namespace Driving_school_BusinessLayer
{
    public class clsLesson
    {
        enum enMode { AddNew = 0, Update = 1 }
        enMode Mode = enMode.AddNew;

        public int LessonID { get; set; }
        public int GroupID { get; set; }
        public clsGroup Group { get; set; }
        public DateTime LessonDate { get; set; }
        public int hour_ofLesson { get; set; } = 0;
        public int minut_ofLesson { get; set; } = 0;
        public TimeSpan LessonDuration{ get; set; } = TimeSpan.Zero; 
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

        private clsLesson(int lessonID, int groupID ,  DateTime lessonDate, TimeSpan lessonnDuration , int hour , int minut,  string _type, int applicationInstructorID)
        {
            LessonID = lessonID;
            GroupID = groupID;
            Group = clsGroup.Find(groupID);
            LessonDate = lessonDate;
            type = _type;
            InstructorID = applicationInstructorID;
            hour_ofLesson = hour;
            minut_ofLesson = minut;
            LessonDuration = lessonnDuration; 
            Mode = enMode.Update;

        }

        private bool _AddNewLesson()
        {
            LessonID = clsLessonDataAccess.AddNewLesson(type , LessonDate , LessonDuration, hour_ofLesson , minut_ofLesson , GroupID , InstructorID);
            return LessonID != -1;
        }

        private bool _UpdateLesson()
        {
            return clsLessonDataAccess.UpdateLesson(LessonID ,  type, LessonDate, LessonDuration, hour_ofLesson, minut_ofLesson, GroupID, InstructorID);
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



         public static clsLesson Find(int ID)
         {


            int _GroupID = 0 ; 
            DateTime _LessonDate = DateTime.Now ; 
            int _hours = 0 ; 
            int _mins = 0 ; 
            TimeSpan _DurationOfLesson = TimeSpan.Zero ; 
            string _type = string.Empty ;
            int _InstructorID = -1;

             if (clsLessonDataAccess.GetLessonInfoByID(ID, ref  _type, ref _LessonDate, ref _DurationOfLesson , ref _hours, ref _mins  , ref _InstructorID, ref _GroupID))
             {
                 return new clsLesson(ID, _GroupID, _LessonDate, _DurationOfLesson ,  _hours, _mins, _type, _InstructorID);
             }
             return null;
         }

        public static DataTable SearchLessonByID(int ID) => clsLessonDataAccess.SearchLessonByID(ID);
        public static DataTable SearchLessonByLessonType(string Type) => clsLessonDataAccess.SearchLessonByLessonType(Type); 
        public static DataTable SearchLessonByGroup(string group) => clsLessonDataAccess.SearchLessonByGroup(group);

        public static bool DelteLesson(int id) => clsLessonDataAccess.DeleteLesson(id); 






    }
}
