

using MyMauiApp.Models;

namespace MyMauiApp.Services
{
    /// <summary>
    /// Interface for MyUser Service - This is the CONTRACT
    /// Any class implementing this interface MUST provide these methods
    /// This is ABSTRACTION in action!
    /// </summary>
    public interface IUserService
    {

        Task<List<MyUser>> GetUsersAsync();


        Task<MyUser?> GetUserByIdAsync(int id);


        Task<MyUser> AddUserAsync(MyUser user);


        Task<MyUser?> UpdateUserAsync(int id, MyUser user);


        Task<bool> DeleteUserAsync(int id);
    }
}