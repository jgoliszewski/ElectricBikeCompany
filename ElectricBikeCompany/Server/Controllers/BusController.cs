using ElectricBikeCompany.Shared;
using ElectricBikeCompany.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace ElectricBikeCompany.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BusController : ControllerBase
{
    private readonly IBusService _BusService;

    public BusController(IBusService BusService)
    {
        _BusService = BusService;
    }

    [HttpGet]
    public async Task<List<Bus>> GetBuss()
    {
        return await _BusService.GetBuss();
    }

    [HttpGet("{id}")]
    public async Task<Bus?> GetBusById(Guid id)
    {
        return await _BusService.GetBusById(id);
    }

    [HttpPost]
    public async Task<Bus?> CreateBus(Bus Bus)
    {
        return await _BusService.CreateBus(Bus);
    }

    [HttpPut("{id}")]
    public async Task<Bus?> UpdateBus(Guid id, Bus Bus)
    {
        return await _BusService.UpdateBus(id, Bus);
    }

    [HttpDelete("{id}")]
    public async Task<bool> DeleteBus(Guid id)
    {
        return await _BusService.DeleteBus(id);
    }
}
