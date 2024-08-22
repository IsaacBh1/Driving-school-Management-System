using System;
using System.Data;
using System.Data.SqlClient;

namespace DrivingSchool_DataAccessLayer
{
    public sealed class clsVehicleDataAccess
    {
        private static string ConnectionString = clsConnectionStr.ConnectionStr;

        public static DataTable GetAllVehicles()
        {
            DataTable Vehicles = new DataTable();
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "SELECT * FROM Vehicles;";
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    Vehicles.Load(reader);
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
            return Vehicles;
        }
        public static DataTable GetAllVehiclesNames()
        {
            DataTable Vehicles = new DataTable();
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "SELECT Name FROM Vehicles;";
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    Vehicles.Load(reader);
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
            return Vehicles;
        }


        public static bool GetVehicleInfoByID(int vehicleID, ref string Name, ref string RegestrationNumber, ref string Mark, ref string Type, ref string Model, ref string Color, ref string ImagePath, ref DateTime? DateOfUsage, ref string AdditionalNotes, ref int FuelType, ref int DrivingLicenseTypeID)
        {
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            string query = "SELECT * FROM Vehicles WHERE VehicleID = @vehicleID";
            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.Parameters.AddWithValue("@vehicleID", vehicleID);
            bool IsFound = false;
            try
            {
                sqlConnection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Name = (string)reader["Name"];
                    RegestrationNumber = (string)reader["RegestrationNumber"];
                    Mark = reader["Mark"] as string;
                    Type = reader["Type"] as string;
                    Model = reader["Model"] as string;
                    Color = reader["Color"] as string;
                    ImagePath = reader["ImagePath"] as string;
                    DateOfUsage = reader["DateOfUsage"] as DateTime?;
                    AdditionalNotes = reader["AdditionalNotes"] as string;
                    FuelType =(int) reader["FuelType"] ;
                    DrivingLicenseTypeID = (int)reader["DrivingLicenseTypeID"];
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

        public static int AddNewVehicle(string Name, string RegestrationNumber, string Mark, string Type, string Model, string Color, string ImagePath, DateTime? DateOfUsage, string AdditionalNotes, int? FuelType, int? DrivingLicenseTypeID)
        {
            int Id = -1;
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            string query = @"INSERT INTO Vehicles (Name, RegestrationNumber, Mark, Type, Model, Color, ImagePath, DateOfUsage, AdditionalNotes, FuelType, DrivingLicenseTypeID) 
                             VALUES (@Name, @RegestrationNumber, @Mark, @Type, @Model, @Color, @ImagePath, @DateOfUsage, @AdditionalNotes, @FuelType, @DrivingLicenseTypeID);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.Parameters.AddWithValue("@Name", Name);
            command.Parameters.AddWithValue("@RegestrationNumber", RegestrationNumber);
            command.Parameters.AddWithValue("@Mark", (object)Mark ?? DBNull.Value);
            command.Parameters.AddWithValue("@Type", (object)Type ?? DBNull.Value);
            command.Parameters.AddWithValue("@Model", (object)Model ?? DBNull.Value);
            command.Parameters.AddWithValue("@Color", (object)Color ?? DBNull.Value);
            command.Parameters.AddWithValue("@ImagePath", (object)ImagePath ?? DBNull.Value);
            command.Parameters.AddWithValue("@DateOfUsage", (object)DateOfUsage ?? DBNull.Value);
            command.Parameters.AddWithValue("@AdditionalNotes", (object)AdditionalNotes ?? DBNull.Value);
            command.Parameters.AddWithValue("@FuelType", (object)FuelType ?? DBNull.Value);
            command.Parameters.AddWithValue("@DrivingLicenseTypeID", (object)DrivingLicenseTypeID ?? DBNull.Value);

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

        public static bool UpdateVehicle(int vehicleID, string Name, string RegestrationNumber, string Mark, string Type, string Model, string Color, string ImagePath, DateTime? DateOfUsage, string AdditionalNotes, int? FuelType, int? DrivingLicenseTypeID)
        {
            int AffectedRows = 0;
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            string query = @"UPDATE Vehicles SET 
                             Name = @Name, 
                             RegestrationNumber = @RegestrationNumber, 
                             Mark = @Mark, 
                             Type = @Type, 
                             Model = @Model, 
                             Color = @Color, 
                             ImagePath = @ImagePath, 
                             DateOfUsage = @DateOfUsage, 
                             AdditionalNotes = @AdditionalNotes, 
                             FuelType = @FuelType, 
                             DrivingLicenseTypeID = @DrivingLicenseTypeID 
                             WHERE VehicleID = @vehicleID";

            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.Parameters.AddWithValue("@vehicleID", vehicleID);
            command.Parameters.AddWithValue("@Name", Name);
            command.Parameters.AddWithValue("@RegestrationNumber", RegestrationNumber);
            command.Parameters.AddWithValue("@Mark", (object)Mark ?? DBNull.Value);
            command.Parameters.AddWithValue("@Type", (object)Type ?? DBNull.Value);
            command.Parameters.AddWithValue("@Model", (object)Model ?? DBNull.Value);
            command.Parameters.AddWithValue("@Color", (object)Color ?? DBNull.Value);
            command.Parameters.AddWithValue("@ImagePath", (object)ImagePath ?? DBNull.Value);
            command.Parameters.AddWithValue("@DateOfUsage", (object)DateOfUsage ?? DBNull.Value);
            command.Parameters.AddWithValue("@AdditionalNotes", (object)AdditionalNotes ?? DBNull.Value);
            command.Parameters.AddWithValue("@FuelType", (object)FuelType ?? DBNull.Value);
            command.Parameters.AddWithValue("@DrivingLicenseTypeID", (object)DrivingLicenseTypeID ?? DBNull.Value);

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

        public static bool DeleteVehicle(int Id)
        {
            bool result = false;
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "DELETE FROM Vehicles WHERE VehicleID = @Id";
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

        public static bool IsVehicleExists(int Id)
        {
            bool result = false;
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "SELECT CASE WHEN EXISTS (SELECT 1 FROM Vehicles WHERE VehicleID = @Id) THEN 1 ELSE 0 END";
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

        public static int GetVehicleIDByInfo(string Name, string RegestrationNumber)
        {
            int ID = -1;
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "SELECT VehicleID FROM Vehicles WHERE Name = @Name AND RegestrationNumber = @RegestrationNumber";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Name", Name);
            command.Parameters.AddWithValue("@RegestrationNumber", RegestrationNumber);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int vehicleID))
                {
                    ID = vehicleID;
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
            return ID;
        }


        public static int GetVehicleIDByVehicleName(string Name)
        {
            int ID = -1;
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "SELECT VehicleID FROM Vehicles WHERE Name = @Name";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Name", Name);
           // command.Parameters.AddWithValue("@RegestrationNumber", RegestrationNumber);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int vehicleID))
                {
                    ID = vehicleID;
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
            return ID;
        }





        public static bool IsVehicleExists(string Name, string RegestrationNumber)
        {
            return (GetVehicleIDByInfo(Name, RegestrationNumber) != -1);
        }
    }
}