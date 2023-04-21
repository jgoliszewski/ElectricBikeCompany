using ElectricBikeCompany.Shared;
using ElectricBikeCompany.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace ElectricBikeCompany.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BikeController : ControllerBase
{
    private readonly IBikeService _BikeService;

    public BikeController(IBikeService BikeService)
    {
        _BikeService = BikeService;
    }

    [HttpGet]
    public async Task<List<Bike>> GetBikes()
    {
        return await _BikeService.GetBikes();
    }

    [HttpGet("{id}")]
    public async Task<Bike?> GetBikeById(Guid id)
    {
        return await _BikeService.GetBikeById(id);
    }

    [HttpPost]
    public async Task<Bike?> CreateBike(Bike Bike)
    {
        return await _BikeService.CreateBike(Bike);
    }

    [HttpPut("{id}")]
    public async Task<Bike?> UpdateBike(Guid id, Bike Bike)
    {
        return await _BikeService.UpdateBike(id, Bike);
    }

    [HttpDelete("{id}")]
    public async Task<bool> DeleteBike(Guid id)
    {
        return await _BikeService.DeleteBike(id);
    }
}
