using System;
using System.Data;
using System.Data.SqlClient;

namespace DrivingSchool_DataAccessLayer
{
    public sealed class clsExamDataAccess
    {
        private static string ConnectionString = "Server=. ; Database=DrivingSchoolDB ; User Id=sa ; Password=sa123456 ;Integrated security=true ; TrustServerCertificate=True; ";

        public static DataTable GetAllExams()
        {
            DataTable exams = new DataTable();
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "select * from Exams; ";
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    exams.Load(reader);
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
            return exams;
        }

        public static bool GetExamInfoByID(int examID, ref int condidateFileID, ref int examTypeID, ref int? result, ref string situation, ref DateTime dateOfExam, ref string additionalNotes, ref TimeSpan timeOfExam)
        {
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            string query = "select * from Exams where ExamID = @examID";
            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.Parameters.AddWithValue("@examID", examID);
            bool isFound = false;
            try
            {
                sqlConnection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    isFound = true;
                    condidateFileID = (int)reader["CondidateFileID"];
                    examTypeID = (int)reader["ExamTypeID"];
                    result = reader["Result"] as int?;
                    situation = (string)reader["Situation"];
                    dateOfExam = (DateTime)reader["DateOfExam"];
                    additionalNotes = reader["AdditionalNotes"] as string;
                    timeOfExam = (TimeSpan)reader["timeOfExam"];
                }
                reader.Close();
                return isFound;
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

        public static int AddNewExam(int condidateFileID, int examTypeID, int? result, string situation, DateTime dateOfExam, string additionalNotes, TimeSpan timeOfExam)
        {
            int id = -1;
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            string query = "insert into Exams (CondidateFileID, ExamTypeID, Result, Situation, DateOfExam, AdditionalNotes, timeOfExam) Values (@CondidateFileID, @ExamTypeID, @Result, @Situation, @DateOfExam, @AdditionalNotes, @timeOfExam);" +
                "select SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.Parameters.AddWithValue("@CondidateFileID", condidateFileID);
            command.Parameters.AddWithValue("@ExamTypeID", examTypeID);
            command.Parameters.AddWithValue("@Result", (object)result ?? DBNull.Value);
            command.Parameters.AddWithValue("@Situation", situation);
            command.Parameters.AddWithValue("@DateOfExam", dateOfExam);
            command.Parameters.AddWithValue("@AdditionalNotes", (object)additionalNotes ?? DBNull.Value);
            command.Parameters.AddWithValue("@timeOfExam", timeOfExam);
            try
            {
                sqlConnection.Open();
                object resultObj = command.ExecuteScalar();
                if (resultObj != null && int.TryParse(resultObj.ToString(), out int ID))
                {
                    id = ID;
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
            return id;
        }

        public static bool UpdateExam(int examID, int condidateFileID, int examTypeID, int? result, string situation, DateTime dateOfExam, string additionalNotes, TimeSpan timeOfExam)
        {
            int affectedRows = 0;
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            string query = "UPDATE [dbo].[Exams] SET " +
                "CondidateFileID = @CondidateFileID," +
                "ExamTypeID = @ExamTypeID," +
                "Result = @Result," +
                "Situation = @Situation," +
                "DateOfExam = @DateOfExam," +
                "AdditionalNotes = @AdditionalNotes," +
                "timeOfExam = @timeOfExam" +
                " WHERE ExamID = @examID";

            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.Parameters.AddWithValue("@examID", examID);
            command.Parameters.AddWithValue("@CondidateFileID", condidateFileID);
            command.Parameters.AddWithValue("@ExamTypeID", examTypeID);
            command.Parameters.AddWithValue("@Result", (object)result ?? DBNull.Value);
            command.Parameters.AddWithValue("@Situation", situation);
            command.Parameters.AddWithValue("@DateOfExam", dateOfExam);
            command.Parameters.AddWithValue("@AdditionalNotes", (object)additionalNotes ?? DBNull.Value);
            command.Parameters.AddWithValue("@timeOfExam", timeOfExam);
            try
            {
                sqlConnection.Open();
                affectedRows = command.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
            return (affectedRows != 0);
        }

        public static bool DeleteExam(int id)
        {
            bool result = false;
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "DELETE FROM Exams WHERE ExamID = @Id";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", id);
            try
            {
                int affectedRows = 0;
                connection.Open();
                affectedRows = command.ExecuteNonQuery();
                if (affectedRows > 0) result = true;
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

        public static bool IsExamExist(int id)
        {
            bool result = false;
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "select Found = 1 from Exams where ExamID = @Id";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", id);
            try
            {
                connection.Open();
                SqlDataReader sqlDataReader = command.ExecuteReader();
                result = sqlDataReader.HasRows;
                sqlDataReader.Close();
            }
            catch { result = false; }
            finally { connection.Close(); }
            return result;
        }

        public static int GetExamIDByInfo(int condidateFileID, int examTypeID, int? result, string situation, DateTime dateOfExam, string additionalNotes, TimeSpan timeOfExam)
        {
            int id = -1;
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "select ExamID from Exams where " +
                "CondidateFileID = @CondidateFileID and " +
                "ExamTypeID = @ExamTypeID and " +
                "Result = @Result and " +
                "Situation = @Situation and " +
                "DateOfExam = @DateOfExam and " +
                "AdditionalNotes = @AdditionalNotes and " +
                "timeOfExam = @timeOfExam";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CondidateFileID", condidateFileID);
            command.Parameters.AddWithValue("@ExamTypeID", examTypeID);
            command.Parameters.AddWithValue("@Result", (object)result ?? DBNull.Value);
            command.Parameters.AddWithValue("@Situation", situation);
            command.Parameters.AddWithValue("@DateOfExam", dateOfExam);
            command.Parameters.AddWithValue("@AdditionalNotes", (object)additionalNotes ?? DBNull.Value);
            command.Parameters.AddWithValue("@timeOfExam", timeOfExam);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        id = (int)reader["ExamID"];
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
            return id;
        }

        public static bool IsExamExist(int condidateFileID, int examTypeID, int? result, string situation, DateTime dateOfExam, string additionalNotes, TimeSpan timeOfExam)
        {
            return (GetExamIDByInfo(condidateFileID, examTypeID, result, situation, dateOfExam, additionalNotes, timeOfExam) != -1);
        }
    }
}
