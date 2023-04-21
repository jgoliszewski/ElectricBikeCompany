using ElectricBikeCompany.Shared;
using ElectricBikeCompany.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace ElectricBikeCompany.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RentController : ControllerBase
{
    private readonly IRentService _RentService;

    public RentController(IRentService RentService)
    {
        _RentService = RentService;
    }

    [HttpGet]
    public async Task<List<Rent>> GetRents()
    {
        return await _RentService.GetRents();
    }

    [HttpGet("{id}")]
    public async Task<Rent?> GetRentById(Guid id)
    {
        return await _RentService.GetRentById(id);
    }

    [HttpPost]
    public async Task<Rent?> CreateRent(Rent Rent)
    {
        return await _RentService.CreateRent(Rent);
    }

    [HttpPut("{id}")]
    public async Task<Rent?> UpdateRent(Guid id, Rent Rent)
    {
        return await _RentService.UpdateRent(id, Rent);
    }

    [HttpDelete("{id}")]
    public async Task<bool> DeleteRent(Guid id)
    {
        return await _RentService.DeleteRent(id);
    }
}
