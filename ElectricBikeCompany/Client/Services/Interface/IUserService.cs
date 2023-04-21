using ElectricBikeCompany.Shared;

namespace ElectricBikeCompany.Client.Services;

public interface IUserService
{
    List<User> Users { get; set; }
    Task GetUsers();
    Task<User?> GetUserById(Guid userId);
    Task CreateUser(User user);
    Task UpdateUser(Guid userId, User user);
    Task DeleteUser(Guid userId);
}
