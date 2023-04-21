using ElectricBikeCompany.Shared;

namespace ElectricBikeCompany.Server.Services;

public class BusService : IBusService
{
    public List<Bus> Buss = new List<Bus>();

    public async Task<List<Bus>> GetBuss()
    {
        return Buss;
    }

    public async Task<Bus?> GetBusById(Guid busId)
    {
        var dbBus = Buss.Where(t => t.Id == busId).FirstOrDefault();
        return dbBus;
    }

    public async Task<Bus> CreateBus(Bus bus)
    {
        bus.Id = Guid.NewGuid();
        Buss.Add(bus);
        return bus;
    }

    public async Task<Bus?> UpdateBus(Guid busId, Bus bus)
    {
        var dbBus = Buss.Where(t => t.Id == busId).FirstOrDefault();
        if (dbBus is not null)
        {
            dbBus.LicensePlate = bus.LicensePlate;
            dbBus.Capacity = bus.Capacity;
        }
        return dbBus;
    }

    public async Task<bool> DeleteBus(Guid busId)
    {
        //todo: remove this emloyee from his tasks
        var dbBus = Buss.Where(t => t.Id == busId).FirstOrDefault();
        if (dbBus is not null)
        {
            Buss.Remove(dbBus);
            return true;
        }
        return false;
    }
}
