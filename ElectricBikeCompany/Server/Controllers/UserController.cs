using ElectricBikeCompany.Shared;
using ElectricBikeCompany.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace ElectricBikeCompany.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _UserService;

    public UserController(IUserService UserService)
    {
        _UserService = UserService;
    }

    [HttpGet]
    public async Task<List<User>> GetUsers()
    {
        return await _UserService.GetUsers();
    }

    [HttpGet("{id}")]
    public async Task<User?> GetUserById(Guid id)
    {
        return await _UserService.GetUserById(id);
    }

    [HttpPost]
    public async Task<User?> CreateUser(User User)
    {
        return await _UserService.CreateUser(User);
    }

    [HttpPut("{id}")]
    public async Task<User?> UpdateUser(Guid id, User User)
    {
        return await _UserService.UpdateUser(id, User);
    }

    [HttpDelete("{id}")]
    public async Task<bool> DeleteUser(Guid id)
    {
        return await _UserService.DeleteUser(id);
    }
}
