using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Transactions;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_Implement_Data_Access
{
    static class Program
    {
        static void Main(string[] args)
        {
            //Task t = SelectDataFromTable();
            //Task t = SelectMultipleFromTable();
            //Task t = UpdateRows();
            //Task t = UpdateRowsWithParameters("MERCURY");
            Task t = TestTransactions();
            Console.ReadKey();
        }

        public static async Task SelectDataFromTable()
        {
            // ADO.NET.
            string connectionString = ConfigurationManager.ConnectionStrings["ProgrammingInCSharpConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM JobHeader", connection);
                await connection.OpenAsync();

                SqlDataReader dataReader = await command.ExecuteReaderAsync();

                while (await dataReader.ReadAsync())
                {
                    Console.WriteLine("Job name '{0}' retrieved from db.", dataReader["JobName"]);
                }

                dataReader.Close();
            }
        }

        public static async Task SelectMultipleFromTable()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ProgrammingInCSharpConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM JobHeader;SELECT COUNT(*) AS Total from JobHeader", connection);
                await connection.OpenAsync();

                SqlDataReader dataReader = await command.ExecuteReaderAsync();

                while (await dataReader.ReadAsync())
                {
                    Console.WriteLine("Job name '{0}' retrieved from db.", dataReader["JobName"]);
                }

                await dataReader.NextResultAsync(); // Move to the next result set.
                await dataReader.ReadAsync();
                Console.WriteLine("Total no of records = {0}", dataReader["Total"]);

                dataReader.Close();
            }
        }

        public static async Task UpdateRows()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ProgrammingInCSharpConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("UPDATE JobHeader SET JobName = 'MOTLEY' WHERE ID = '2100219'", connection);
                await connection.OpenAsync();

                int noOfRowsUpdated = await command.ExecuteNonQueryAsync();
                Console.WriteLine("Updated {0} row(s).", noOfRowsUpdated);
            }
        }

        public static async Task UpdateRowsWithParameters(string jobName)
        {
            // Allows protect against SQL injection from a malicious user.
            // Should always validate user input before using in a SQL statement.
            string connectionString = ConfigurationManager.ConnectionStrings["ProgrammingInCSharpConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("UPDATE JobHeader SET JobName = @jobName WHERE ID = '2100219'", connection);
                await connection.OpenAsync();

                // By using parameters, ensures that users cannot enter/insert malicious code into the above SQL.
                // SQL will fail on syntax error, for example.
                command.Parameters.AddWithValue("@jobName", jobName);

                int numberOfInsertedRows = await command.ExecuteNonQueryAsync();
                Console.WriteLine("Updated {0} rows", numberOfInsertedRows);
            }
        }

        public static async Task TestTransactions()
        {
            // Wraps db changes into a transaction - if an error occurs within the scope of the transaction,
            // then whole transaction is rolled back.  Prevents data corruption.
            // Wrap within a using to ensure the object is disposed when no longer in use.
            string connectionString = ConfigurationManager.ConnectionStrings["ProgrammingInCSharpConnection"].ConnectionString;

            using (TransactionScope tscope = new TransactionScope())
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    try
                    {
                        SqlCommand command1 = new SqlCommand("INSERT INTO JobHeader([JobName]) VALUES('Job101')", connection);
                        SqlCommand command2 = new SqlCommand("INSERT INTO JobHeader([JobName]) VALUES('Job101')", connection);
                        await command1.ExecuteNonQueryAsync();
                        await command2.ExecuteNonQueryAsync();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Exception thrown - {0}.", e.Message);
                    }
                }
                tscope.Complete();
            }
        }
    }
}
