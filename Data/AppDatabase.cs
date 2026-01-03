using SQLite;
using MyMauiApp.Models;

namespace MyMauiApp.Data
{
    public class AppDatabase
    {
        private SQLiteAsyncConnection _database;

        // Constructor - Initializes database
        public AppDatabase()
        {
        }

        // Initialize database connection and create tables
        async Task Init()
        {
            // If database already exists, don't recreate
            if (_database != null)
                return;

            // Get database location in AppDataDirectory
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "book_management.db");



            Console.WriteLine($"Database Path: {dbPath}");

            //Create SQLiteAsyncConnection
            _database = new SQLiteAsyncConnection(dbPath);

            //Create Tables using CreateTableAsync<T>()
            await _database.CreateTableAsync<Book>();
            await _database.CreateTableAsync<Author>();

            Console.WriteLine("Database and tables created successfully");
        }

        // ============================================
        // CRUD OPERATIONS FOR BOOK TABLE
        // ============================================

        // CREATE - Insert a Book
        public async Task<int> AddBookAsync(Book book)
        {
            await Init();
            // InsertAsync returns number of rows inserted
            return await _database.InsertAsync(book);
        }

        // READ - Get all Books
        public async Task<List<Book>> GetBooksAsync()
        {
            await Init();
            return await _database.Table<Book>().ToListAsync();
        }

        // READ - Get single Book by ID
        public async Task<Book> GetBookByIdAsync(int id)
        {
            await Init();
            return await _database.Table<Book>()
                .Where(b => b.Id == id)
                .FirstOrDefaultAsync();
        }

        // UPDATE - Update a Book
        public async Task<int> UpdateBookAsync(Book book)
        {
            await Init();
            // UpdateAsync returns number of rows updated
            return await _database.UpdateAsync(book);
        }

        // DELETE - Delete a Book
        public async Task<int> DeleteBookAsync(Book book)
        {
            await Init();
            // DeleteAsync returns number of rows deleted
            return await _database.DeleteAsync(book);
        }

        // ============================================
        // CRUD OPERATIONS FOR AUTHOR TABLE
        // ============================================

        // CREATE - Insert an Author
        public async Task<int> AddAuthorAsync(Author author)
        {
            await Init();
            return await _database.InsertAsync(author);
        }

        // READ - Get all Authors
        public async Task<List<Author>> GetAuthorsAsync()
        {
            await Init();
            return await _database.Table<Author>().ToListAsync();
        }

        // READ - Get single Author by ID
        public async Task<Author> GetAuthorByIdAsync(int id)
        {
            await Init();
            return await _database.Table<Author>()
                .Where(a => a.Id == id)
                .FirstOrDefaultAsync();
        }

        // UPDATE - Update an Author
        public async Task<int> UpdateAuthorAsync(Author author)
        {
            await Init();
            return await _database.UpdateAsync(author);
        }

        // DELETE - Delete an Author
        public async Task<int> DeleteAuthorAsync(Author author)
        {
            await Init();
            return await _database.DeleteAsync(author);
        }
    }
}