using System;
using System.Data;
using System.Data.SqlClient;

namespace DrivingSchool_DataAccessLayer
{
    public sealed class clsGroupDataAccess
    {
        private static string ConnectionString = clsConnectionStr.ConnectionStr;

        public static DataTable GetAllGroups()
        {
            DataTable Groups = new DataTable();
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "SELECT * FROM Groups;";
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    Groups.Load(reader);
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
            return Groups;
        }

        public static bool GetGroupInfoByID(int groupID, ref int GroupNumber, ref int NumberOfMembers, ref int DrivingLicenseTypesID)
        {
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            string query = "SELECT * FROM Groups WHERE GroupID = @groupID";
            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.Parameters.AddWithValue("@groupID", groupID);
            bool IsFound = false;
            try
            {
                sqlConnection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    IsFound = true;
                    GroupNumber = (int)reader["GroupNumber"];
                    NumberOfMembers = (int)reader["NumberOfMembers"];
                    DrivingLicenseTypesID = (int)reader["DrivingLicenseTypesID"];
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

        public static int AddNewGroup(int GroupNumber, int NumberOfMembers, int DrivingLicenseTypesID)
        {
            int Id = -1;
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            string query = @"INSERT INTO Groups (GroupNumber, NumberOfMembers, DrivingLicenseTypesID) 
                             VALUES (@GroupNumber, @NumberOfMembers, @DrivingLicenseTypesID);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.Parameters.AddWithValue("@GroupNumber", GroupNumber);
            command.Parameters.AddWithValue("@NumberOfMembers", NumberOfMembers);
            command.Parameters.AddWithValue("@DrivingLicenseTypesID", DrivingLicenseTypesID);

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

        public static bool UpdateGroup(int groupID, int GroupNumber, int NumberOfMembers, int DrivingLicenseTypesID)
        {
            int AffectedRows = 0;
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            string query = @"UPDATE Groups SET 
                             GroupNumber = @GroupNumber, 
                             NumberOfMembers = @NumberOfMembers, 
                             DrivingLicenseTypesID = @DrivingLicenseTypesID 
                             WHERE GroupID = @groupID";

            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.Parameters.AddWithValue("@groupID", groupID);
            command.Parameters.AddWithValue("@GroupNumber", GroupNumber);
            command.Parameters.AddWithValue("@NumberOfMembers", NumberOfMembers);
            command.Parameters.AddWithValue("@DrivingLicenseTypesID", DrivingLicenseTypesID);

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

        public static bool DeleteGroup(int Id)
        {
            bool result = false;
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "DELETE FROM Groups WHERE GroupID = @Id";
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

        public static bool IsGroupExists(int Id)
        {
            bool result = false;
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "SELECT CASE WHEN EXISTS (SELECT 1 FROM Groups WHERE GroupID = @Id) THEN 1 ELSE 0 END";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", Id);
            try
            {
                connection.Open();
                result = (int)command.ExecuteScalar() == 1;
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

        public static DataTable GetGroupsByDrivingLicenseType(int DrivingLicenseTypesID)
        {
            DataTable Groups = new DataTable();
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "SELECT * FROM Groups WHERE DrivingLicenseTypesID = @DrivingLicenseTypesID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DrivingLicenseTypesID", DrivingLicenseTypesID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    Groups.Load(reader);
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
            return Groups;
        }

        public static int GetTotalMembersByDrivingLicenseType(int DrivingLicenseTypesID)
        {
            int totalMembers = 0;
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "SELECT SUM(NumberOfMembers) FROM Groups WHERE DrivingLicenseTypesID = @DrivingLicenseTypesID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DrivingLicenseTypesID", DrivingLicenseTypesID);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != DBNull.Value)
                {
                    totalMembers = Convert.ToInt32(result);
                }
            }
            catch
            {
                return -1;
            }
            finally
            {
                connection.Close();
            }
            return totalMembers;
        }
    }
}