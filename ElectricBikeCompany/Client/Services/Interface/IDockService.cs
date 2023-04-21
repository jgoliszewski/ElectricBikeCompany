using ElectricBikeCompany.Shared;

namespace ElectricBikeCompany.Client.Services;

public interface IDockService
{
    List<Dock> Docks { get; set; }
    Task GetDocks();
    Task<Dock?> GetDockById(Guid dockId);
    Task CreateDock(Dock dock);
    Task UpdateDock(Guid dockId, Dock dock);
    Task DeleteDock(Guid dockId);
}
