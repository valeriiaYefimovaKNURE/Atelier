

namespace IDZ.Persistense.Configuration
{
    public sealed class DatabaseConfiguration
    {
        private static DatabaseConfiguration? instance;
        internal static DatabaseConfiguration Instance
        {
            get
            {
                if(instance == null)
                    throw new ArgumentException("Database configuration is not ready");
                return instance;
            }
        }
        public string ConnectionString { get; }
        private DatabaseConfiguration(string connectionString) 
        {
            ConnectionString = connectionString;
        }
        public static void Initialize(string connectionString) 
        { 
            instance= new DatabaseConfiguration(connectionString);
        }

    }
}
