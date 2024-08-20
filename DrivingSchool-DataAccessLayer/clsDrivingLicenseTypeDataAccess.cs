using System;
using System.Data;
using System.Data.SqlClient;

namespace DrivingSchool_DataAccessLayer
{
    public sealed class clsDrivingLicenseTypeDataAccess
    {
        private static string ConnectionString = clsConnectionStr.ConnectionStr;

        public static DataTable GetAllDrivingLicenseTypes()
        {
            DataTable DrivingLicenseTypes = new DataTable();
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "select * from DrivingLicenseTypes;";
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    DrivingLicenseTypes.Load(reader);
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
            return DrivingLicenseTypes;
        }

        public static bool GetDrivingLicenseTypeInfoByID(int drivingLicenseTypeID, ref string Name, ref decimal Price, ref bool Situation, ref int NumberOfLessons_Theo, ref int NumberOfLessons_App, ref string IconImagePath, ref int Instructor_TheoID, ref int Instructor_AppID)
        {
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            string query = "select * from DrivingLicenseTypes where DrivingLiceseTypeID = @drivingLicenseTypeID";
            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.Parameters.AddWithValue("@drivingLicenseTypeID", drivingLicenseTypeID);
            bool IsFound = false;
            try
            {
                sqlConnection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    IsFound = true;
                    Name = (string)reader["Name"];
                    Price = (decimal)reader["Price"];
                    Situation =(bool) reader["Situation"] ;
                    NumberOfLessons_Theo = (int)reader["NumberOfLessons_Theo"];
                    NumberOfLessons_App = (int)reader["NumberOfLessons_App"];
                    IconImagePath = reader["IconImagePath"] as string;
                    Instructor_TheoID = (int)reader["Instructor_TheoID"];
                    Instructor_AppID = (int)reader["Instructor_AppID"];
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

        public static int AddNewDrivingLicenseType(string Name, decimal Price, bool? Situation, int? NumberOfLessons_Theo, int? NumberOfLessons_App, string IconImagePath, int? Instructor_TheoID, int? Instructor_AppID)
        {
            int Id = -1;
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            string query = "insert into DrivingLicenseTypes (Name, Price, Situation, NumberOfLessons_Theo, NumberOfLessons_App, IconImagePath, Instructor_TheoID, Instructor_AppID) values (@Name, @Price, @Situation, @NumberOfLessons_Theo, @NumberOfLessons_App, @IconImagePath, @Instructor_TheoID, @Instructor_AppID);" +
                "select SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.Parameters.AddWithValue("@Name", Name);
            command.Parameters.AddWithValue("@Price", Price);
            command.Parameters.AddWithValue("@Situation", Situation.HasValue ? (object)Situation.Value : DBNull.Value);
            command.Parameters.AddWithValue("@NumberOfLessons_Theo", NumberOfLessons_Theo.HasValue ? (object)NumberOfLessons_Theo.Value : DBNull.Value);
            command.Parameters.AddWithValue("@NumberOfLessons_App", NumberOfLessons_App.HasValue ? (object)NumberOfLessons_App.Value : DBNull.Value);
            command.Parameters.AddWithValue("@IconImagePath", string.IsNullOrEmpty(IconImagePath) ? DBNull.Value : (object)IconImagePath);
            command.Parameters.AddWithValue("@Instructor_TheoID", Instructor_TheoID.HasValue ? (object)Instructor_TheoID.Value : DBNull.Value);
            command.Parameters.AddWithValue("@Instructor_AppID", Instructor_AppID.HasValue ? (object)Instructor_AppID.Value : DBNull.Value);
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

        public static bool UpdateDrivingLicenseType(int drivingLicenseTypeID, string Name, decimal Price, bool? Situation, int? NumberOfLessons_Theo, int? NumberOfLessons_App, string IconImagePath, int? Instructor_TheoID, int? Instructor_AppID)
        {
            int AffectedRows = 0;
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            string query = "UPDATE [dbo].[DrivingLicenseTypes] SET " +
                "Name = @Name, " +
                "Price = @Price, " +
                "Situation = @Situation, " +
                "NumberOfLessons_Theo = @NumberOfLessons_Theo, " +
                "NumberOfLessons_App = @NumberOfLessons_App, " +
                "IconImagePath = @IconImagePath, " +
                "Instructor_TheoID = @Instructor_TheoID, " +
                "Instructor_AppID = @Instructor_AppID " +
                "WHERE DrivingLiceseTypeID = @drivingLicenseTypeID";

            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.Parameters.AddWithValue("@drivingLicenseTypeID", drivingLicenseTypeID);
            command.Parameters.AddWithValue("@Name", Name);
            command.Parameters.AddWithValue("@Price", Price);
            command.Parameters.AddWithValue("@Situation", Situation.HasValue ? (object)Situation.Value : DBNull.Value);
            command.Parameters.AddWithValue("@NumberOfLessons_Theo", NumberOfLessons_Theo.HasValue ? (object)NumberOfLessons_Theo.Value : DBNull.Value);
            command.Parameters.AddWithValue("@NumberOfLessons_App", NumberOfLessons_App.HasValue ? (object)NumberOfLessons_App.Value : DBNull.Value);
            command.Parameters.AddWithValue("@IconImagePath", string.IsNullOrEmpty(IconImagePath) ? DBNull.Value : (object)IconImagePath);
            command.Parameters.AddWithValue("@Instructor_TheoID", Instructor_TheoID.HasValue ? (object)Instructor_TheoID.Value : DBNull.Value);
            command.Parameters.AddWithValue("@Instructor_AppID", Instructor_AppID.HasValue ? (object)Instructor_AppID.Value : DBNull.Value);
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

        public static bool DeleteDrivingLicenseType(int Id)
        {
            bool result = false;
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "DELETE FROM DrivingLicenseTypes WHERE DrivingLiceseTypeID = @Id";
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

        public static bool IsDrivingLicenseTypeExists(int Id)
        {
            bool result = false;
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "select Found = 1 from DrivingLicenseTypes where DrivingLiceseTypeID = @Id";
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

        public static int GetDrivingLicenseTypeIDByInfo(string Name, decimal Price, bool? Situation, int? NumberOfLessons_Theo, int? NumberOfLessons_App, string IconImagePath, int? Instructor_TheoID, int? Instructor_AppID)
        {
            int ID = -1;
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "select DrivingLiceseTypeID from DrivingLicenseTypes where " +
                "Name = @Name and " +
                "Price = @Price and " +
                "Situation = @Situation and " +
                "NumberOfLessons_Theo = @NumberOfLessons_Theo and " +
                "NumberOfLessons_App = @NumberOfLessons_App and " +
                "IconImagePath = @IconImagePath and " +
                "Instructor_TheoID = @Instructor_TheoID and " +
                "Instructor_AppID = @Instructor_AppID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Name", Name);
            command.Parameters.AddWithValue("@Price", Price);
            command.Parameters.AddWithValue("@Situation", Situation.HasValue ? (object)Situation.Value : DBNull.Value);
            command.Parameters.AddWithValue("@NumberOfLessons_Theo", NumberOfLessons_Theo.HasValue ? (object)NumberOfLessons_Theo.Value : DBNull.Value);
            command.Parameters.AddWithValue("@NumberOfLessons_App", NumberOfLessons_App.HasValue ? (object)NumberOfLessons_App.Value : DBNull.Value);
            command.Parameters.AddWithValue("@IconImagePath", string.IsNullOrEmpty(IconImagePath) ? DBNull.Value : (object)IconImagePath);
            command.Parameters.AddWithValue("@Instructor_TheoID", Instructor_TheoID.HasValue ? (object)Instructor_TheoID.Value : DBNull.Value);
            command.Parameters.AddWithValue("@Instructor_AppID", Instructor_AppID.HasValue ? (object)Instructor_AppID.Value : DBNull.Value);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ID = (int)reader["DrivingLiceseTypeID"];
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

        public static bool IsDrivingLicenseTypeExists(string Name, decimal Price, bool? Situation, int? NumberOfLessons_Theo, int? NumberOfLessons_App, string IconImagePath, int? Instructor_TheoID, int? Instructor_AppID)
        {
            return (GetDrivingLicenseTypeIDByInfo(Name, Price, Situation, NumberOfLessons_Theo, NumberOfLessons_App, IconImagePath, Instructor_TheoID, Instructor_AppID) != -1);
        }
    }
}
