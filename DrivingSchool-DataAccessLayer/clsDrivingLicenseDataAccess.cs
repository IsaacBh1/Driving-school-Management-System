using System;
using System.Data;
using System.Data.SqlClient;

namespace DrivingSchool_DataAccessLayer
{
    public sealed class clsDrivingLicenseDataAccess
    {
        private static string ConnectionString = "Server=. ; Database=DrivingSchoolDB ; User Id=sa ; Password=sa123456 ; Integrated security=true ; TrustServerCertificate=True;";

        public static DataTable GetAllDrivingLicenses()
        {
            DataTable DrivingLicenses = new DataTable();
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "select * from DrivingLicenses;";
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    DrivingLicenses.Load(reader);
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
            return DrivingLicenses;
        }

        public static bool GetDrivingLicenseInfoByID(int drivingLicenseID, ref string Number, ref string DrivingLicenseType, ref string CAP)
        {
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            string query = "select * from DrivingLicenses where DrivingLicenseID = @drivingLicenseID";
            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.Parameters.AddWithValue("@drivingLicenseID", drivingLicenseID);
            bool IsFound = false;
            try
            {
                sqlConnection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    IsFound = true;
                    Number = (string)reader["Number"];
                    DrivingLicenseType = reader["DrivingLicenseType"] != DBNull.Value ? (string)reader["DrivingLicenseType"] : null;
                    CAP = (string)reader["CAP"];
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

        public static int AddNewDrivingLicense(string Number, string DrivingLicenseType, string CAP)
        {
            int Id = -1;
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            string query = "insert into DrivingLicenses (Number, DrivingLicenseType, CAP) values (@Number, @DrivingLicenseType, @CAP);" +
                "select SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.Parameters.AddWithValue("@Number", Number);
            command.Parameters.AddWithValue("@DrivingLicenseType", DrivingLicenseType);
            command.Parameters.AddWithValue("@CAP", CAP);
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

        public static bool UpdateDrivingLicense(int drivingLicenseID, string Number, string DrivingLicenseType, string CAP)
        {
            int AffectedRows = 0;
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            string query = "UPDATE [dbo].[DrivingLicenses] SET " +
                "Number = @Number, " +
                "DrivingLicenseType = @DrivingLicenseType, " +
                "CAP = @CAP " +
                "WHERE DrivingLicenseID = @drivingLicenseID";

            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.Parameters.AddWithValue("@drivingLicenseID", drivingLicenseID);
            command.Parameters.AddWithValue("@Number", Number);
            command.Parameters.AddWithValue("@DrivingLicenseType", DrivingLicenseType);
            command.Parameters.AddWithValue("@CAP", CAP);
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

        public static bool DeleteDrivingLicense(int Id)
        {
            bool result = false;
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "DELETE FROM DrivingLicenses WHERE DrivingLicenseID = @Id";
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

        public static bool IsDrivingLicenseExists(int Id)
        {
            bool result = false;
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "select Found = 1 from DrivingLicenses where DrivingLicenseID = @Id";
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

        public static int GetDrivingLicenseIDByInfo(string Number, string DrivingLicenseType, string CAP)
        {
            int ID = -1;
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "select DrivingLicenseID from DrivingLicenses where " +
                "Number = @Number and " +
                "DrivingLicenseType = @DrivingLicenseType and " +
                "CAP = @CAP";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Number", Number);
            command.Parameters.AddWithValue("@DrivingLicenseType", DrivingLicenseType);
            command.Parameters.AddWithValue("@CAP", CAP);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ID = (int)reader["DrivingLicenseID"];
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

        public static bool IsDrivingLicenseExists(string Number, string DrivingLicenseType, string CAP)
        {
            return (GetDrivingLicenseIDByInfo(Number, DrivingLicenseType, CAP) != -1);
        }
    }
}
