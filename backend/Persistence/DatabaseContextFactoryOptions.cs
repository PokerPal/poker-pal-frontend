namespace Persistence
{
    public class DatabaseContextFactoryOptions
    {
        internal string InMemoryDatabaseName { get; set; } = "default_in_memory_database";

        internal bool InMemory { get; set; } = false;
        
        internal string? ConnectionString { get; set; }

        public DatabaseContextFactoryOptions UseInMemoryDatabase(string inMemoryDatabaseName)
        {
            this.InMemory = true;
            this.InMemoryDatabaseName = inMemoryDatabaseName ?? this.InMemoryDatabaseName;
            return this;
        }

        public DatabaseContextFactoryOptions UseConnectionString(string connectionString)
        {
            this.ConnectionString = connectionString;
            return this;
        }
    }
}