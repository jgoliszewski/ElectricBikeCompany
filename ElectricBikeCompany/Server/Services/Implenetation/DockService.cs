using ElectricBikeCompany.Shared;

namespace ElectricBikeCompany.Server.Services;

public class DockService : IDockService
{
    public List<Dock> Docks = new List<Dock>();

    public async Task<List<Dock>> GetDocks()
    {
        return Docks;
    }

    public async Task<Dock?> GetDockById(Guid dockId)
    {
        var dbDock = Docks.Where(t => t.Id == dockId).FirstOrDefault();
        return dbDock;
    }

    public async Task<Dock> CreateDock(Dock dock)
    {
        dock.Id = Guid.NewGuid();
        Docks.Add(dock);
        return dock;
    }

    public async Task<Dock?> UpdateDock(Guid dockId, Dock dock)
    {
        var dbDock = Docks.Where(t => t.Id == dockId).FirstOrDefault();
        if (dbDock is not null)
        {
            dbDock.Capacity = dock.Capacity;
            dbDock.Taken_spaces = dock.Taken_spaces;
            dbDock.Address = dock.Address;
        }
        return dbDock;
    }

    public async Task<bool> DeleteDock(Guid dockId)
    {
        //todo: remove this emloyee from his tasks
        var dbDock = Docks.Where(t => t.Id == dockId).FirstOrDefault();
        if (dbDock is not null)
        {
            Docks.Remove(dbDock);
            return true;
        }
        return false;
    }
}
