using SQLite;

namespace MyMauiApp.Models
{
    public class Author
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(100), NotNull]
        public string? Name { get; set; }

        [MaxLength(100)]
        public string? Email { get; set; }

        [MaxLength(50)]
        public string? Country { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}