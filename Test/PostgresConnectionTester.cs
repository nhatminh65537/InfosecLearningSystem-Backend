using System;
using Npgsql;
using Microsoft.Extensions.Configuration;

namespace InfosecLearningSystem_Backend.Test
{
    public class PostgresConnectionTester
    {
        private readonly string? _connectionString;

        public PostgresConnectionTester(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("PostgresConnection");
        }

        public void TestConnection()
        {
            try
            {
                using (var connection = new NpgsqlConnection(_connectionString))
                {
                    connection.Open();
                    Console.WriteLine("Connection to PostgreSQL successful!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
