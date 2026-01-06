using SQLite;
using MyMauiApp.Models;

namespace MyMauiApp.Data
{
    public class DatabaseService
    {
        private SQLiteAsyncConnection? _database;

        // Initialize database connection and create tables
        public async Task Init()
        {
            // If database already exists, don't recreate
            if (_database != null)
                return;

            string dbPath;
#if WINDOWS
            dbPath = Path. Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                "book_management.db"
            );
#else
            dbPath = Path.Combine(
                FileSystem.AppDataDirectory,
                "book_management.db"
            );
#endif

            Console.WriteLine($"Database Path: {dbPath}");

            // Create SQLiteAsyncConnection
            _database = new SQLiteAsyncConnection(dbPath);

            // Create Tables using CreateTableAsync<T>()
            await _database.CreateTableAsync<Book>();
            await _database.CreateTableAsync<Author>();

            Console.WriteLine("Database and tables created successfully");
        }

        // Get database connection
        public async Task<SQLiteAsyncConnection> GetConnectionAsync()
        {
            await Init();
            return _database ;
        }
    }
}