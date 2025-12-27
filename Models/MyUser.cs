namespace MyMauiApp.Models
{
    /// <summary>
    /// User model class - represents a user in our system
    /// This is a simple POCO (Plain Old CLR Object) class
    /// </summary>
    /// 
    public class MyUser
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;

        // Computed property for display
        public string FullName => $"{FirstName} {LastName}";
    }

}



