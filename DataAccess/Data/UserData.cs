using DataAccess.DbAccess;
using DataAccess.Models;

namespace DataAccess.Data;

public class UserData : IUserData
{
    private readonly ISqlDataAccess _sqlDataAccess;

    public UserData(ISqlDataAccess sqlDataAccess) => _sqlDataAccess = sqlDataAccess;

    public async Task<IEnumerable<User>> GetUsers() =>
        await _sqlDataAccess.LoadData<User, dynamic>("dbo.spUser_GetAll", new { });

    public async Task<User?> GetUser(int id)
    {
        var results = await _sqlDataAccess.LoadData<User, dynamic>(
            "dbo.spUser_GetById",
            new { Id = id });

        return results.FirstOrDefault();
    }

    public Task InsertUser(User user) =>
        _sqlDataAccess.SaveData("dbo.spUser_Insert", new { user.FirstName, user.LastName });

    public Task UpdateUser(User user) =>
        _sqlDataAccess.SaveData("dbo.spUser_Update", user);

    public Task DeleteUser(int id) =>
        _sqlDataAccess.SaveData("dbo.spUser_Delete", new { Id = id });
}