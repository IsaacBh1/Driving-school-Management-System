using System;
using System.Data;
using System.Data.SqlClient;

namespace DrivingSchool_DataAccessLayer
{
    public sealed class clsStudentDataAccess
    {
        private static string ConnectionString = "Server=. ; Database=DrivingSchoolDB ; User Id=sa ; Password=sa123456 ; Integrated security=true ; TrustServerCertificate=True;";

        public static DataTable GetAllStudents()
        {
            DataTable Students = new DataTable();
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "select * from Students;";
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    Students.Load(reader);
                }
                reader.Close();
            }
            catch
            {
                return null;
            }
            finally
            {
                connection.Close();
            }
            return Students;
        }

        public static bool GetStudentInfoByID(int studentID, ref int PersonID, ref string UserName, ref DateTime BirthDate, ref string BirthCountry, ref bool Gender, ref int NationalCardID)
        {
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            string query = "select * from Students where StudentID = @studentID";
            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.Parameters.AddWithValue("@studentID", studentID);
            bool IsFound = false;
            try
            {
                sqlConnection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    IsFound = true;
                    PersonID = (int)reader["PersonID"];
                    UserName = reader["UserName"] != DBNull.Value ? (string)reader["UserName"] : null;
                    BirthDate = (DateTime)reader["BirthDate"];
                    BirthCountry = reader["BirthCountry"] != DBNull.Value ? (string)reader["BirthCountry"] : null;
                    Gender = (bool)reader["Gender"];
                    NationalCardID = (int)reader["NationalCardID"];
                }
                reader.Close();
                return IsFound;
            }
            catch
            {
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public static int AddNewStudent(int PersonID, string UserName, DateTime BirthDate, string BirthCountry, bool Gender, int NationalCardID)
        {
            int Id = -1;
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            string query = "insert into Students (PersonID, UserName, BirthDate, BirthCountry, Gender, NationalCardID) values (@PersonID, @UserName, @BirthDate, @BirthCountry, @Gender, @NationalCardID);" +
                "select SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@BirthDate", BirthDate);
            command.Parameters.AddWithValue("@BirthCountry", BirthCountry);
            command.Parameters.AddWithValue("@Gender", Gender);
            command.Parameters.AddWithValue("@NationalCardID", NationalCardID);
            try
            {
                sqlConnection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int ID))
                {
                    Id = ID;
                }
            }
            catch
            {
                return -1;
            }
            finally
            {
                sqlConnection.Close();
            }
            return Id;
        }

        public static bool UpdateStudent(int studentID, int PersonID, string UserName, DateTime BirthDate, string BirthCountry, bool Gender, int NationalCardID)
        {
            int AffectedRows = 0;
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            string query = "UPDATE [dbo].[Students] SET " +
                "PersonID = @PersonID, " +
                "UserName = @UserName, " +
                "BirthDate = @BirthDate, " +
                "BirthCountry = @BirthCountry, " +
                "Gender = @Gender, " +
                "NationalCardID = @NationalCardID " +
                "WHERE StudentID = @studentID";

            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.Parameters.AddWithValue("@studentID", studentID);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@BirthDate", BirthDate);
            command.Parameters.AddWithValue("@BirthCountry", BirthCountry);
            command.Parameters.AddWithValue("@Gender", Gender);
            command.Parameters.AddWithValue("@NationalCardID", NationalCardID);
            try
            {
                sqlConnection.Open();
                AffectedRows = command.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
            return (AffectedRows != 0);
        }

        public static bool DeleteStudent(int Id)
        {
            bool result = false;
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "DELETE FROM Students WHERE StudentID = @Id";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", Id);
            try
            {
                int AffectedRows = 0;
                connection.Open();
                AffectedRows = command.ExecuteNonQuery();
                if (AffectedRows > 0) result = true;
            }
            catch
            {
                result = false;
            }
            finally
            {
                connection.Close();
            }
            return result;
        }

        public static bool IsStudentExists(int Id)
        {
            bool result = false;
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "select Found = 1 from Students where StudentID = @Id";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", Id);
            try
            {
                connection.Open();
                SqlDataReader sqlDataReader = command.ExecuteReader();
                result = sqlDataReader.HasRows;
                sqlDataReader.Close();
            }
            catch
            {
                result = false;
            }
            finally
            {
                connection.Close();
            }
            return result;
        }

        public static int GetStudentIDByInfo(int PersonID, string UserName, DateTime BirthDate, string BirthCountry, bool Gender, int NationalCardID)
        {
            int ID = -1;
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "select StudentID from Students where " +
                "PersonID = @PersonID and " +
                "UserName = @UserName and " +
                "BirthDate = @BirthDate and " +
                "BirthCountry = @BirthCountry and " +
                "Gender = @Gender and " +
                "NationalCardID = @NationalCardID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@BirthDate", BirthDate);
            command.Parameters.AddWithValue("@BirthCountry", BirthCountry);
            command.Parameters.AddWithValue("@Gender", Gender);
            command.Parameters.AddWithValue("@NationalCardID", NationalCardID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ID = (int)reader["StudentID"];
                    }
                }
                reader.Close();
            }
            catch
            {
                return -1;
            }
            finally
            {
                connection.Close();
            }
            return ID;
        }

        public static bool IsStudentExists(int PersonID, string UserName, DateTime BirthDate, string BirthCountry, bool Gender, int NationalCardID)
        {
            return (GetStudentIDByInfo(PersonID, UserName, BirthDate, BirthCountry, Gender, NationalCardID) != -1);
        }
    }
}
