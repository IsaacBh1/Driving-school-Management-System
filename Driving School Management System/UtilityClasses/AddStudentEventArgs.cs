using System;
namespace Driving_School_Management_System.UtilityClasses
{

    namespace Driving_School_Management_System
    {
        public class AddStudentEventArgs : EventArgs
        {
            public int StudentID { get; }
            public int personID { get; }

            public AddStudentEventArgs(int studentID, int personID)
            {
                StudentID = studentID;
                this.personID = personID;
            }
        }
    }
}
