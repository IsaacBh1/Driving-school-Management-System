using System;
using System.Data;
using System.Data.SqlClient;

namespace DrivingSchool_DataAccessLayer
{
    public sealed class clsPaymentDataAccess
    {
        private static string ConnectionString = clsConnectionStr.ConnectionStr;

        public static DataTable GetAllPayments()
        {
            DataTable Payments = new DataTable();
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "SELECT * FROM Payments;";
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    Payments.Load(reader);
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
            return Payments;
        }

        public static bool GetPaymentInfoByID(int paymentID, ref decimal FullAmount, ref decimal AmountPayed, ref int MoneyBankID)
        {
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            string query = "SELECT * FROM Payments WHERE PaymentID = @paymentID";
            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.Parameters.AddWithValue("@paymentID", paymentID);
            bool IsFound = false;
            try
            {
                sqlConnection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    IsFound = true;
                    FullAmount = (decimal)reader["FullAmount"];
                    AmountPayed = (decimal)reader["AmountPayed"];
                    MoneyBankID = (int)reader["MoneyBankID"];
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

        public static int AddNewPayment(decimal FullAmount, decimal AmountPayed, int MoneyBankID)
        {
            int Id = -1;
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            string query = @"INSERT INTO Payments (FullAmount, AmountPayed, MoneyBankID) 
                             VALUES (@FullAmount, @AmountPayed, @MoneyBankID);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.Parameters.AddWithValue("@FullAmount", FullAmount);
            command.Parameters.AddWithValue("@AmountPayed", AmountPayed);
            command.Parameters.AddWithValue("@MoneyBankID", MoneyBankID);

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

        public static bool UpdatePayment(int paymentID, decimal FullAmount, decimal AmountPayed, int MoneyBankID)
        {
            int AffectedRows = 0;
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            string query = @"UPDATE Payments SET 
                             FullAmount = @FullAmount, 
                             AmountPayed = @AmountPayed, 
                             MoneyBankID = @MoneyBankID 
                             WHERE PaymentID = @paymentID";

            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.Parameters.AddWithValue("@paymentID", paymentID);
            command.Parameters.AddWithValue("@FullAmount", FullAmount);
            command.Parameters.AddWithValue("@AmountPayed", AmountPayed);
            command.Parameters.AddWithValue("@MoneyBankID", MoneyBankID);

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

        public static bool DeletePayment(int Id)
        {
            bool result = false;
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "DELETE FROM Payments WHERE PaymentID = @Id";
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

        public static bool IsPaymentExists(int Id)
        {
            bool result = false;
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "SELECT CASE WHEN EXISTS (SELECT 1 FROM Payments WHERE PaymentID = @Id) THEN 1 ELSE 0 END";
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

        public static DataTable GetPaymentsByMoneyBank(int MoneyBankID)
        {
            DataTable Payments = new DataTable();
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "SELECT * FROM Payments WHERE MoneyBankID = @MoneyBankID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@MoneyBankID", MoneyBankID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    Payments.Load(reader);
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
            return Payments;
        }

        public static decimal GetTotalAmountPayedByMoneyBank(int MoneyBankID)
        {
            decimal totalAmountPayed = 0;
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "SELECT SUM(AmountPayed) FROM Payments WHERE MoneyBankID = @MoneyBankID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@MoneyBankID", MoneyBankID);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != DBNull.Value)
                {
                    totalAmountPayed = (decimal)result;
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
            return totalAmountPayed;
        }
    }
}