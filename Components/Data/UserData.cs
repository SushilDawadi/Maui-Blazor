

using MauiBlazorApp.Models;

namespace MyMauiApp.Data
{
    /*
     * Static User Data Store
     * 
     * Demonstrates:  In-memory data storage using static class
     * - Persists data across page navigations
     * - Provides centralized access to user list
     */
    public static class UserData
    {
        public static List<User> UsersList { get; set; } = new List<User>
        {
            new User
            {
                Id = 1,
                Name = "Ram Bahadur Thapa",
                Email = "ram. thapa@example.com",
                Age = 28,
                PhoneNumber = "9841234567",
                ImageUrl = "https://i.pravatar.cc/150?img=12",
                Address = "Kathmandu, Nepal",
                CreatedDate = DateTime. Now. AddDays(-15)
            },
            new User
            {
                Id = 2,
                Name = "Sita Kumari Sharma",
                Email = "sita.sharma@example.com",
                Age = 32,
                PhoneNumber = "9851234567",
                ImageUrl = "https://i.pravatar.cc/150?img=5",
                Address = "Pokhara, Nepal",
                CreatedDate = DateTime.Now.AddDays(-10)
            },
            new User
            {
                Id = 3,
                Name = "Hari Prasad Gautam",
                Email = "hari.gautam@example.com",
                Age = 45,
                PhoneNumber = "9861234567",
                ImageUrl = "https://i.pravatar.cc/150?img=15",
                Address = "Lalitpur, Nepal",
                CreatedDate = DateTime.Now.AddDays(-7)
            },
            new User
            {
                Id = 4,
                Name = "Gita Rana Magar",
                Email = "gita.magar@example.com",
                Age = 26,
                PhoneNumber = "9871234567",
                ImageUrl = "https://i.pravatar.cc/150?img=9",
                Address = "Bhaktapur, Nepal",
                CreatedDate = DateTime.Now. AddDays(-5)
            },
            new User
            {
                Id = 5,
                Name = "Krishna Bahadur Tamang",
                Email = "krishna.tamang@example.com",
                Age = 38,
                PhoneNumber = "9881234567",
                ImageUrl = "https://i.pravatar.cc/150?img=33",
                Address = "Biratnagar, Nepal",
                CreatedDate = DateTime.Now. AddDays(-3)
            }
        };

        public static int NextUserId { get; set; } = 6;
    }
}