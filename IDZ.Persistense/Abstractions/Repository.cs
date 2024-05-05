using System.Data.SqlClient;
using IDZ.Persistense.Configuration;

namespace IDZ.Persistense.Abstractions
{
    public abstract class Repository
    {
        public SqlConnection CreateOpenedConnection() 
        { 
            var connectionString=DatabaseConfiguration.Instance.ConnectionString;
            var connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }
    }
}
