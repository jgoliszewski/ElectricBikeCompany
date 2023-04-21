using ElectricBikeCompany.Shared;
using ElectricBikeCompany.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace ElectricBikeCompany.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DockController : ControllerBase
{
    private readonly IDockService _DockService;

    public DockController(IDockService DockService)
    {
        _DockService = DockService;
    }

    [HttpGet]
    public async Task<List<Dock>> GetDocks()
    {
        return await _DockService.GetDocks();
    }

    [HttpGet("{id}")]
    public async Task<Dock?> GetDockById(Guid id)
    {
        return await _DockService.GetDockById(id);
    }

    [HttpPost]
    public async Task<Dock?> CreateDock(Dock Dock)
    {
        return await _DockService.CreateDock(Dock);
    }

    [HttpPut("{id}")]
    public async Task<Dock?> UpdateDock(Guid id, Dock Dock)
    {
        return await _DockService.UpdateDock(id, Dock);
    }

    [HttpDelete("{id}")]
    public async Task<bool> DeleteDock(Guid id)
    {
        return await _DockService.DeleteDock(id);
    }
}
