using Dapper;
using System.Data;
using Microsoft.Data.SqlClient; // Use this for modern .NET projects


namespace PharmacyApplication
{
    public class DapperAdapter
    {
        private readonly string _sqlConnection;
        public ConfigurationBuilder _configuration = new ConfigurationBuilder();

        public DapperAdapter()
        {
            // Change the connection string to match SQL Server format
            _sqlConnection = "Server=localhost\\SQLEXPRESS;Database=Pharmacy;Trusted_Connection=True;TrustServerCertificate=True;";
        }

        public int Execute(string function, object? param = null)
        {
            using (var dbConnection = new SqlConnection(_sqlConnection)) // Use SqlConnection
            {
                dbConnection.Open();
                var result = dbConnection.Execute(function, param, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<int> ExecuteAsync(string function, object? param = null)
        {
            using (var dbConnection = new SqlConnection(_sqlConnection)) // Use SqlConnection
            {
                dbConnection.Open();
                var result = await dbConnection.ExecuteAsync(function, param, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public IEnumerable<T> Query<T>(string function, object? param = null)
        {
            using (var dbConnection = new SqlConnection(_sqlConnection)) // Use SqlConnection
            {
                dbConnection.Open();
                var result = dbConnection.Query<T>(function, param, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(string function, object? param = null)
        {
            using (var dbConnection = new SqlConnection(_sqlConnection)) // Use SqlConnection
            {
                dbConnection.Open();
                var result = await dbConnection.QueryAsync<T>(function, param, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<IEnumerable<T>> QuerySqlAsync<T>(string sql)
        {
            using (var dbConnection = new SqlConnection(_sqlConnection)) // Use SqlConnection
            {
                dbConnection.Open();
                var result = await dbConnection.QueryAsync<T>(sql);
                return result;
            }
        }

        public async Task<string> ExtractCSVAsync(string function)
        {
            using (var dbConnection = new SqlConnection(_sqlConnection)) // Use SqlConnection
            {
                dbConnection.Open();
                // Handle CSV extraction differently for SQL Server if needed
                var result = ""; // Placeholder logic; SQL Server doesn't support BeginTextExport like Npgsql
                return result;
            }
        }
    }
}
