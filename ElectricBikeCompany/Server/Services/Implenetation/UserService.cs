using ElectricBikeCompany.Shared;

namespace ElectricBikeCompany.Server.Services;

public class UserService : IUserService
{
    public List<User> Users = new List<User>();

    public async Task<List<User>> GetUsers()
    {
        return Users;
    }

    public async Task<User?> GetUserById(Guid userId)
    {
        var dbUser = Users.Where(t => t.Id == userId).FirstOrDefault();
        return dbUser;
    }

    public async Task<User> CreateUser(User user)
    {
        user.Id = new Guid();
        Users.Add(user);
        return user;
    }

    public async Task<User?> UpdateUser(Guid userId, User user)
    {
        var dbUser = Users.Where(t => t.Id == userId).FirstOrDefault();
        if (dbUser is not null)
        {
            dbUser.Username = user.Username;
            dbUser.Password = user.Password;
        }
        return dbUser;
    }

    public async Task<bool> DeleteUser(Guid userId)
    {
        //todo: remove this emloyee from his tasks
        var dbUser = Users.Where(t => t.Id == userId).FirstOrDefault();
        if (dbUser is not null)
        {
            Users.Remove(dbUser);
            return true;
        }
        return false;
    }
}
