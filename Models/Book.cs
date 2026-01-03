using SQLite;

namespace MyMauiApp.Models
{
    public class Book
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(200)]
        public string Title { get; set; } = string.Empty;

        [MaxLength(100)]
        public string Author { get; set; } = string.Empty;

        [MaxLength(50)]
        public string ISBN { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public int PublicationYear { get; set; }

        public int AuthorId { get; set; }
    }
}