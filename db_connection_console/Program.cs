using System;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        string connectionString = "Data Source=AMAZE\\SQLEXPRESS;Initial Catalog=person;Integrated Security=True";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                connection.Open();
                Console.WriteLine("Connected to the database");

                // Your database operations go here

                // Example: Execute a query
                string query = "SELECT * FROM dbo.tbl_customer";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Process the results
                            Console.WriteLine($"Forename: {reader["forename"]}, Surname: {reader["surname"]}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

