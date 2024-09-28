using System;
using System.Data;
using System.Data.SqlClient;

namespace DrivingSchool_DataAccessLayer
{
    public sealed class clsCondidateFileDataAccess
    {
        private static string ConnectionString = clsConnectionStr.ConnectionStr;

        public static DataTable GetAllCondidateFiles()
        {
            DataTable condidateFiles = new DataTable();
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "select * from CondidateFiles ; ";
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    condidateFiles.Load(reader);
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
            return condidateFiles;
        }

        public static DataTable GetAllCondidateFileInformations()
        {
            DataTable condidateFiles = new DataTable();
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "select * from CondidateFileInformation ; ";
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    condidateFiles.Load(reader);
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
            return condidateFiles;
        }


        public static bool GetCondidateFileInfoByID(int condidateFileID, ref int studentID, ref int drivingLicenseTypeID, ref string additionalNotes, ref bool isActive, ref DateTime creatingFileDate, ref bool isArchived, ref int groupID, ref int paymentID, ref int theoreticalInstructorID, ref int applicationInstructorID)
        {
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            string query = "select * from CondidateFiles where CondidateFileID = @condidateFileID";
            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.Parameters.AddWithValue("@condidateFileID", condidateFileID);
            bool isFound = false;
            try
            {
                sqlConnection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    isFound = true;
                    studentID = (int)reader["StudentID"];
                    drivingLicenseTypeID = (int)reader["DrivingLicenseTypeID"];
                    additionalNotes = reader["AdditionalNotes"] as string;
                    isActive = (bool)reader["IsActive"];
                    creatingFileDate = (DateTime)reader["CreatingFileDate"];
                    isArchived = (bool)reader["IsArchived"];
                    groupID = reader["GroupID"] as int? ?? 0;
                    paymentID = (int)reader["PaymentID"];
                    theoreticalInstructorID = reader["theoreticalInstructorID"] as int? ?? 0;
                    applicationInstructorID = reader["ApplicationInstructorID"] as int? ?? 0;
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

        public static int AddNewCondidateFile(int studentID, int drivingLicenseTypeID, string additionalNotes, bool isActive, DateTime creatingFileDate, bool isArchived, int groupID, int paymentID, int theoreticalInstructorID, int applicationInstructorID)
        {
            int id = -1;
            int ISAcrtive = isActive == true ? 1 : 0;
            int IsArchived = isArchived == true ? 1 : 0;
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            string query = "insert into CondidateFiles (StudentID, DrivingLicenseTypeID, AdditionalNotes, IsActive, CreatingFileDate, IsArchived, GroupID, PaymentID, theoreticalInstructorID, ApplicationInstructorID) Values (@StudentID, @DrivingLicenseTypeID, @AdditionalNotes, @IsActive, @CreatingFileDate, @IsArchived, @GroupID, @PaymentID, @theoreticalInstructorID, @ApplicationInstructorID);" +
                "select SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.Parameters.AddWithValue("@StudentID", studentID);
            command.Parameters.AddWithValue("@DrivingLicenseTypeID", drivingLicenseTypeID);
            command.Parameters.AddWithValue("@AdditionalNotes", additionalNotes);
            command.Parameters.AddWithValue("@IsActive", ISAcrtive);
            command.Parameters.AddWithValue("@CreatingFileDate", creatingFileDate);
            command.Parameters.AddWithValue("@IsArchived", IsArchived);
            command.Parameters.AddWithValue("@GroupID", groupID);
            command.Parameters.AddWithValue("@PaymentID", paymentID);
            command.Parameters.AddWithValue("@theoreticalInstructorID", theoreticalInstructorID);
            command.Parameters.AddWithValue("@ApplicationInstructorID", applicationInstructorID);
            try
            {
                sqlConnection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int ID))
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

        public static bool UpdateCondidateFile(int condidateFileID, int studentID, int drivingLicenseTypeID, string additionalNotes, bool isActive, DateTime creatingFileDate, bool isArchived, int groupID, int paymentID, int theoreticalInstructorID, int applicationInstructorID)
        {
            int affectedRows = 0;
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            string query = "UPDATE [dbo].[CondidateFiles] SET " +
                "StudentID = @StudentID," +
                "DrivingLicenseTypeID = @DrivingLicenseTypeID," +
                "AdditionalNotes = @AdditionalNotes," +
                "IsActive = @IsActive," +
                "CreatingFileDate = @CreatingFileDate," +
                "IsArchived = @IsArchived," +
                "GroupID = @GroupID," +
                "PaymentID = @PaymentID," +
                "theoreticalInstructorID = @theoreticalInstructorID," +
                "ApplicationInstructorID = @ApplicationInstructorID" +
                " WHERE CondidateFileID = @condidateFileID";

            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.Parameters.AddWithValue("@condidateFileID", condidateFileID);
            command.Parameters.AddWithValue("@StudentID", studentID);
            command.Parameters.AddWithValue("@DrivingLicenseTypeID", drivingLicenseTypeID);
            command.Parameters.AddWithValue("@AdditionalNotes", additionalNotes);
            command.Parameters.AddWithValue("@IsActive", isActive);
            command.Parameters.AddWithValue("@CreatingFileDate", creatingFileDate);
            command.Parameters.AddWithValue("@IsArchived", isArchived);
            command.Parameters.AddWithValue("@GroupID", groupID);
            command.Parameters.AddWithValue("@PaymentID", paymentID);
            command.Parameters.AddWithValue("@theoreticalInstructorID", theoreticalInstructorID);
            command.Parameters.AddWithValue("@ApplicationInstructorID", applicationInstructorID);
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

        public static bool DeleteCondidateFile(int id)
        {
            bool result = false;
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "DELETE FROM CondidateFiles WHERE CondidateFileID = @Id";
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

        public static bool IsCondidateFileExist(int id)
        {
            bool result = false;
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "select Found = 1 from CondidateFiles where CondidateFileID = @Id";
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

        public static int GetCondidateFileIDByInfo(int studentID, int drivingLicenseTypeID, string additionalNotes, bool isActive, DateTime creatingFileDate, bool isArchived, int groupID, int paymentID, int theoreticalInstructorID, int applicationInstructorID)
        {
            int id = -1;
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "select CondidateFileID from CondidateFiles where " +
                "StudentID = @StudentID and " +
                "DrivingLicenseTypeID = @DrivingLicenseTypeID and " +
                "AdditionalNotes = @AdditionalNotes and " +
                "IsActive = @IsActive and " +
                "CreatingFileDate = @CreatingFileDate and " +
                "IsArchived = @IsArchived and " +
                "GroupID = @GroupID and " +
                "PaymentID = @PaymentID and " +
                "theoreticalInstructorID = @theoreticalInstructorID and " +
                "ApplicationInstructorID = @ApplicationInstructorID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@StudentID", studentID);
            command.Parameters.AddWithValue("@DrivingLicenseTypeID", drivingLicenseTypeID);
            command.Parameters.AddWithValue("@AdditionalNotes", additionalNotes);
            command.Parameters.AddWithValue("@IsActive", isActive);
            command.Parameters.AddWithValue("@CreatingFileDate", creatingFileDate);
            command.Parameters.AddWithValue("@IsArchived", isArchived);
            command.Parameters.AddWithValue("@GroupID", groupID);
            command.Parameters.AddWithValue("@PaymentID", paymentID);
            command.Parameters.AddWithValue("@theoreticalInstructorID", theoreticalInstructorID);
            command.Parameters.AddWithValue("@ApplicationInstructorID", applicationInstructorID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        id = (int)reader["CondidateFileID"];
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

        public static bool IsCondidateFileExist(int studentID, int drivingLicenseTypeID, string additionalNotes, bool isActive, DateTime creatingFileDate, bool isArchived, int groupID, int paymentID, int theoreticalInstructorID, int applicationInstructorID)
        {
            return (GetCondidateFileIDByInfo(studentID, drivingLicenseTypeID, additionalNotes, isActive, creatingFileDate, isArchived, groupID, paymentID, theoreticalInstructorID, applicationInstructorID) != -1);
        }

        public static bool GetCondidateFileInfoByID(int ID, ref int drivingLicenseTypeID, ref string additionalNotes, ref bool isActive, ref DateTime creatingFileDate, ref bool isArchived, ref int groupID, ref int paymentID, ref int theoreticalInstructorID, ref int applicationInstructorID , ref int StudentID)
        {
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            string query = "select * from CondidateFiles where CondidateFileID = @ID ;";
            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.Parameters.AddWithValue("@ID", ID);
            bool IsFound = false;
            try
            {
                sqlConnection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    IsFound = true;
                    drivingLicenseTypeID = (int)reader["DrivingLicenseTypeID"];
                    additionalNotes = (string)reader["additionalNotes"];
                    isActive = (bool)reader["isActive"];
                    creatingFileDate = (DateTime)reader["CreatingFileDate"];
                    isArchived = (bool)reader["isArchived"];
                    groupID = (int)reader["groupID"];
                    paymentID = (int)reader["paymentID"];
                    theoreticalInstructorID = (int)reader["theoreticalInstructorID"];
                    applicationInstructorID = (int)reader["ApplicationInstructorID"];
                    StudentID = (int)reader["StudentID"];
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


        public static DataTable SearchCondidateFileInfoByID(string Id)
        {
            DataTable StudentsInfo = new DataTable();
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "select * from CondidateFileInformation where CondidateFileID like'" + Id + "';";
            SqlCommand command = new SqlCommand(query, connection);
            //command.Parameters.AddWithValue("@Number", Number);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    StudentsInfo.Load(reader);
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
            return StudentsInfo;
        }




        public static DataTable SearchCondidtesFileInfoFirstName_Arabic(string Name)
        {
            DataTable StudentsInfo = new DataTable();
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "select * from CondidateFileInformation where FirstName_Arabic like '%" + Name + "%'; ";
            SqlCommand command = new SqlCommand(query, connection);
            //command.Parameters.AddWithValue("@Name", Name);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    StudentsInfo.Load(reader);
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
            return StudentsInfo;
        }





        public static DataTable SearchCondidatesFileInfoLastName_Arabic(string Name)
        {
            DataTable StudentsInfo = new DataTable();
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "select * from CondidateFileInformation where LastName_Arabic like '%" + Name + "%';";
            SqlCommand command = new SqlCommand(query, connection);
            //command.Parameters.AddWithValue("@Name", LastName);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    StudentsInfo.Load(reader);
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
            return StudentsInfo;
        }

        public static DataTable SearchActiveStudentsFiles(bool isActive)
        {
            DataTable StudentsInfo = new DataTable();
            SqlConnection connection = new SqlConnection(ConnectionString);
            int IsActive = isActive == true ? 1 : 0; 
            string query = "select * from CondidateFileInformation where IsActive = @isActive ; ";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@isActive", IsActive);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    StudentsInfo.Load(reader);
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
            return StudentsInfo;
        }

        public static DataTable SearchArchivedStudentsFiles(bool isArchived)
        {
            DataTable StudentsInfo = new DataTable();
            SqlConnection connection = new SqlConnection(ConnectionString);
            int IsActive = isArchived == true ? 1 : 0;
            string query = "select * from CondidateFileInformation where IsArchived = @isActive ; ";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@isActive", IsActive);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    StudentsInfo.Load(reader);
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
            return StudentsInfo;
        }


        public static DataTable SearchCondidtesFilesByDrivingLisence(string Name)
        {
            DataTable StudentsInfo = new DataTable();
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "select * from CondidateFileInformation where Name like '" + Name + "';";
            SqlCommand command = new SqlCommand(query, connection);
            //command.Parameters.AddWithValue("@isActive", IsActive);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    StudentsInfo.Load(reader);
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
            return StudentsInfo;
        }
        //"++"
        public static DataTable SearchByAll(int CondidateFileID , string FirstName_Arabic , string LastName_Arabic , string DrivingLisenceType, bool isArchived ,bool isActive)
        {
            DataTable StudentsInfo = new DataTable();
            SqlConnection connection = new SqlConnection(ConnectionString);
            int IsArchived = isArchived ? 1 : 0;
            int IsActive = isActive ? 1 : 0;
            string query = @"select * from CondidateFileInformation " +
                            "where " + 
                            "CondidateFileID like '"+ CondidateFileID + "%'and " + 
                            "FirstName_Arabic like '%"+ FirstName_Arabic + "%'and " + 
                            "LastName_Arabic like '%"+ LastName_Arabic + "%'and " +
                            "Name like '"+ DrivingLisenceType+ "%' and " +
                            "IsArchived like '"+ IsArchived + "%' and " +
                            "IsActive like '"+ IsActive + "%' ; ";
            SqlCommand command = new SqlCommand(query, connection);
            //command.Parameters.AddWithValue("@isActive", IsActive);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    StudentsInfo.Load(reader);
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
            return StudentsInfo;
        }

    }
}
