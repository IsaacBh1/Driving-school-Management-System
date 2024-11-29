using System;
using System.Data;
using System.Data.SqlClient;

namespace DrivingSchool_DataAccessLayer
{
    public sealed class clsExpenseDataAccess
    {
        private static string ConnectionString = clsConnectionStr.ConnectionStr;

        public static DataTable GetAllExpenses()
        {
            DataTable Expenses = new DataTable();
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "SELECT * FROM Expenses order by ExpenseID desc ;";
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    Expenses.Load(reader);
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
            return Expenses;
        }

        public static bool GetExpenseInfoByID(int expenseID, ref int ExpenseTypeID, ref decimal Amount, ref string AdditionalNotes, ref int MoneyBankID)
        {
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            string query = "SELECT * FROM Expenses WHERE ExpenseID = @expenseID";
            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.Parameters.AddWithValue("@expenseID", expenseID);
            bool IsFound = false;
            try
            {
                sqlConnection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    IsFound = true;
                    ExpenseTypeID = (int)reader["ExpenseTypeID"];
                    Amount = (decimal)reader["Amount"];
                    AdditionalNotes = reader["AdditionalNotes"] as string;
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

        public static int AddNewExpense(int ExpenseTypeID, decimal Amount, string AdditionalNotes, int MoneyBankID)
        {
            int Id = -1;
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            string query = @"INSERT INTO Expenses (ExpenseTypeID, Amount, AdditionalNotes, MoneyBankID) 
                             VALUES (@ExpenseTypeID, @Amount, @AdditionalNotes, @MoneyBankID);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.Parameters.AddWithValue("@ExpenseTypeID", ExpenseTypeID);
            command.Parameters.AddWithValue("@Amount", Amount);
            command.Parameters.AddWithValue("@AdditionalNotes", (object)AdditionalNotes ?? DBNull.Value);
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

        public static bool UpdateExpense(int expenseID, int ExpenseTypeID, decimal Amount, string AdditionalNotes, int MoneyBankID)
        {
            int AffectedRows = 0;
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            string query = @"UPDATE Expenses SET 
                             ExpenseTypeID = @ExpenseTypeID, 
                             Amount = @Amount, 
                             AdditionalNotes = @AdditionalNotes, 
                             MoneyBankID = @MoneyBankID 
                             WHERE ExpenseID = @expenseID";

            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.Parameters.AddWithValue("@expenseID", expenseID);
            command.Parameters.AddWithValue("@ExpenseTypeID", ExpenseTypeID);
            command.Parameters.AddWithValue("@Amount", Amount);
            command.Parameters.AddWithValue("@AdditionalNotes", (object)AdditionalNotes ?? DBNull.Value);
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

        public static bool DeleteExpense(int Id)
        {
            bool result = false;
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "DELETE FROM Expenses WHERE ExpenseID = @Id";
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

        public static bool IsExpenseExists(int Id)
        {
            bool result = false;
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "SELECT CASE WHEN EXISTS (SELECT 1 FROM Expenses WHERE ExpenseID = @Id) THEN 1 ELSE 0 END";
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

        public static DataTable GetExpensesByMoneyBank(int MoneyBankID)
        {
            DataTable Expenses = new DataTable();
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "SELECT * FROM Expenses WHERE MoneyBankID = @MoneyBankID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@MoneyBankID", MoneyBankID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    Expenses.Load(reader);
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
            return Expenses;
        }

        public static decimal GetTotalExpensesByMoneyBank(int MoneyBankID)
        {
            decimal totalExpense = 0;
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "SELECT SUM(Amount) FROM Expenses WHERE MoneyBankID = @MoneyBankID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@MoneyBankID", MoneyBankID);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != DBNull.Value)
                {
                    totalExpense = (decimal)result;
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
            return totalExpense;
        }
    }
}