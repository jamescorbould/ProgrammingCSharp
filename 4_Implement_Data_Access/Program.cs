using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_Implement_Data_Access
{
    static class Program
    {
        static void Main(string[] args)
        {
            Task t = SelectDataFromTable();
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
    }
}
