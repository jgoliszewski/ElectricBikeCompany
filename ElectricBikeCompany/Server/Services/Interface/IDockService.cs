using ElectricBikeCompany.Shared;

namespace ElectricBikeCompany.Server.Services;

public interface IDockService
{
    Task<List<Dock>> GetDocks();
    Task<Dock?> GetDockById(Guid DockId);
    Task<Dock> CreateDock(Dock Dock);
    Task<Dock?> UpdateDock(Guid DockId, Dock Dock);
    Task<bool> DeleteDock(Guid DockId);
}
