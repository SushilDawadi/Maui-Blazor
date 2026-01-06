using MyMauiApp.Models;
using MyMauiApp.Data;

namespace MyMauiApp.Services
{
    public class BookService
    {
        private readonly DatabaseService _databaseService;

        public BookService(DatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        // CREATE - Insert a Book
        public async Task<int> AddBookAsync(Book book)
        {
            var db = await _databaseService.GetConnectionAsync();
            return await db.InsertAsync(book);
        }

        // READ - Get all Books
        public async Task<List<Book>> GetBooksAsync()
        {
            var db = await _databaseService.GetConnectionAsync();
            return await db.Table<Book>().ToListAsync();
        }

        // READ - Get single Book by ID
        public async Task<Book> GetBookByIdAsync(int id)
        {
            var db = await _databaseService.GetConnectionAsync();
            return await db.Table<Book>()
                .Where(b => b.Id == id)
                .FirstOrDefaultAsync();
        }

        // UPDATE - Update a Book
        public async Task<int> UpdateBookAsync(Book book)
        {
            var db = await _databaseService.GetConnectionAsync();
            return await db.UpdateAsync(book);
        }

        // DELETE - Delete a Book
        public async Task<int> DeleteBookAsync(Book book)
        {
            var db = await _databaseService.GetConnectionAsync();
            return await db.DeleteAsync(book);
        }

        // ADDITIONAL - Delete Book by ID
        public async Task<int> DeleteBookByIdAsync(int id)
        {
            var book = await GetBookByIdAsync(id);
            if (book != null)
            {
                return await DeleteBookAsync(book);
            }
            return 0;
        }

        // ADDITIONAL - Get Books by Author ID
        public async Task<List<Book>> GetBooksByAuthorIdAsync(int authorId)
        {
            var db = await _databaseService.GetConnectionAsync();
            return await db.Table<Book>()
                .Where(b => b.AuthorId == authorId)
                .ToListAsync();
        }
    }
}