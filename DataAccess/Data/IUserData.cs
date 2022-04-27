using DataAccess.Models;

namespace DataAccess.Data;

public interface IUserData
{
    Task<IEnumerable<User>> GetUsers();
    Task<User?> GetUser(int id);
    Task InsertUser(User user);
    Task UpdateUser(User user);
    Task DeleteUser(int id);
}