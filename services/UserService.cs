using MyMauiApp.Models;
using MyMauiApp.Services;


namespace MyMauiApp.Services
{
    /// <summary>
    /// UserService - First implementation of IUserService
    /// This stores users in MEMORY (data is lost when app closes)
    /// </summary>
    public class UserService : IUserService
    {
        // Private list to store users (like a mini database in memory)
        private readonly List<MyUser> _users;
        private int _nextId;

        public UserService()
        {

            _users = new List<MyUser>
            {
                new MyUser
                {
                    Id = 1,
                    Username = "john_doe",
                    Email = "john@example.com",
                    FirstName = "John",
                    LastName = "Doe",
                    Phone = "555-0101"
                },
                new MyUser
                {
                    Id = 2,
                    Username = "jane_smith",
                    Email = "jane@example.com",
                    FirstName = "Jane",
                    LastName = "Smith",
                    Phone = "555-0102"
                },
                new MyUser
                {
                    Id = 3,
                    Username = "bob_wilson",
                    Email = "bob@example.com",
                    FirstName = "Bob",
                    LastName = "Wilson",
                    Phone = "555-0103"
                }
            };
            _nextId = 4;
        }


        public async Task<List<MyUser>> GetUsersAsync()
        {

            await Task.Delay(100);


            return _users.ToList();
        }

        public async Task<MyUser?> GetUserByIdAsync(int id)
        {
            await Task.Delay(50);


            return _users.FirstOrDefault(u => u.Id == id);
        }

        public async Task<MyUser> AddUserAsync(MyUser user)
        {
            await Task.Delay(50);

            // Assign a new ID
            user.Id = _nextId++;

            // Add to the list
            _users.Add(user);

            return user;
        }


        public async Task<MyUser?> UpdateUserAsync(int id, MyUser user)
        {
            await Task.Delay(50);

            // Find the user to update
            var existingUser = _users.FirstOrDefault(u => u.Id == id);

            if (existingUser == null)
                return null;

            // Update the properties
            existingUser.Username = user.Username;
            existingUser.Email = user.Email;
            existingUser.FirstName = user.FirstName;
            existingUser.LastName = user.LastName;
            existingUser.Phone = user.Phone;

            return existingUser;
        }


        public async Task<bool> DeleteUserAsync(int id)
        {
            await Task.Delay(50);

            // Find the user
            var user = _users.FirstOrDefault(u => u.Id == id);

            if (user == null)
                return false;


            _users.Remove(user);
            return true;
        }
    }
}