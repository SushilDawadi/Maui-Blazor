using MyMauiApp.Models;
using MyMauiApp.Data;

namespace MyMauiApp.Services
{
    public class AuthorService
    {
        private readonly DatabaseService _databaseService;

        public AuthorService(DatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        // CREATE - Insert an Author
        public async Task<int> AddAuthorAsync(Author author)
        {
            var db = await _databaseService.GetConnectionAsync();
            return await db.InsertAsync(author);
        }

        // READ - Get all Authors
        public async Task<List<Author>> GetAuthorsAsync()
        {
            var db = await _databaseService.GetConnectionAsync();
            return await db.Table<Author>().ToListAsync();
        }

        // READ - Get single Author by ID
        public async Task<Author> GetAuthorByIdAsync(int id)
        {
            var db = await _databaseService.GetConnectionAsync();
            return await db.Table<Author>()
                .Where(a => a.Id == id)
                .FirstOrDefaultAsync();
        }

        // UPDATE - Update an Author
        public async Task<int> UpdateAuthorAsync(Author author)
        {
            var db = await _databaseService.GetConnectionAsync();
            return await db.UpdateAsync(author);
        }

        // DELETE - Delete an Author
        public async Task<int> DeleteAuthorAsync(Author author)
        {
            var db = await _databaseService.GetConnectionAsync();
            return await db.DeleteAsync(author);
        }

        // ADDITIONAL - Delete Author by ID
        public async Task<int> DeleteAuthorByIdAsync(int id)
        {
            var author = await GetAuthorByIdAsync(id);
            if (author != null)
            {
                return await DeleteAuthorAsync(author);
            }
            return 0;
        }
    }
}