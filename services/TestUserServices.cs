using System.Net.Http.Json;
using MyMauiApp.Models;



namespace MyMauiApp.Services
{
    /// <summary>
    /// TestUserService - Second implementation of IUserService
    /// This gets REAL data from an API on the internet
    /// This demonstrates how ABSTRACTION helps with TESTING
    /// </summary>
    public class TestUserService : IUserService
    {
        private readonly HttpClient _httpClient;
        private List<MyUser> _cachedUsers = new List<MyUser>();

        // HttpClient is INJECTED through constructor
        public TestUserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Get users from a real API
        /// </summary>
        public async Task<List<MyUser>> GetUsersAsync()
        {
            try
            {
                // Call the Fake Store API
                var apiUsers = await _httpClient.GetFromJsonAsync<List<ApiUser>>(
                    "https://fakestoreapi.com/users?limit=10");

                if (apiUsers != null)
                {
                    // Transform API data to our User model
                    _cachedUsers = apiUsers.Select(apiUser => new MyUser
                    {
                        Id = apiUser.Id,
                        Username = apiUser.Username ?? string.Empty,
                        Email = apiUser.Email ?? string.Empty,
                        FirstName = apiUser.Name?.Firstname ?? string.Empty,
                        LastName = apiUser.Name?.Lastname ?? string.Empty,
                        Phone = apiUser.Phone ?? string.Empty
                    }).ToList();
                }

                return _cachedUsers;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching users from API: {ex.Message}");
                return _cachedUsers;
            }
        }

        public async Task<MyUser?> GetUserByIdAsync(int id)
        {
            await Task.Delay(50);
            return _cachedUsers.FirstOrDefault(u => u.Id == id);
        }

        public async Task<MyUser> AddUserAsync(MyUser user)
        {
            await Task.Delay(50);

            // Generate new ID
            user.Id = _cachedUsers.Any() ? _cachedUsers.Max(u => u.Id) + 1 : 1;
            _cachedUsers.Add(user);
            return user;
        }

        public async Task<MyUser?> UpdateUserAsync(int id, MyUser user)
        {
            await Task.Delay(50);

            var existingUser = _cachedUsers.FirstOrDefault(u => u.Id == id);
            if (existingUser == null)
                return null;

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

            var user = _cachedUsers.FirstOrDefault(u => u.Id == id);
            if (user == null)
                return false;

            _cachedUsers.Remove(user);
            return true;
        }




        // Helper classes to match API structure
        private class ApiUser
        {
            public int Id { get; set; }
            public string? Email { get; set; }
            public string? Username { get; set; }
            public string? Phone { get; set; }
            public NameInfo? Name { get; set; }
        }

        private class NameInfo
        {
            public string? Firstname { get; set; }
            public string? Lastname { get; set; }
        }
    }
}