using ElectricBikeCompany.Shared;

namespace ElectricBikeCompany.Server.Services;

public interface IUserService
{
    Task<List<User>> GetUsers();
    Task<User?> GetUserById(Guid UserId);
    Task<User> CreateUser(User User);
    Task<User?> UpdateUser(Guid UserId, User User);
    Task<bool> DeleteUser(Guid UserId);
}
