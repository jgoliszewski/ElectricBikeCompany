using ElectricBikeCompany.Shared;

namespace ElectricBikeCompany.Server.Services;

public class BikeService : IBikeService
{
    public List<Bike> Bikes = new List<Bike>();

    public async Task<List<Bike>> GetBikes()
    {
        return Bikes;
    }

    public async Task<Bike?> GetBikeById(Guid bikeId)
    {
        var dbBike = Bikes.Where(t => t.Id == bikeId).FirstOrDefault();
        return dbBike;
    }

    public async Task<Bike> CreateBike(Bike bike)
    {
        bike.Id = Guid.NewGuid();
        Bikes.Add(bike);
        return bike;
    }

    public async Task<Bike?> UpdateBike(Guid bikeId, Bike bike)
    {
        var dbBike = Bikes.Where(t => t.Id == bikeId).FirstOrDefault();
        if (dbBike is not null)
        {
            dbBike.BatteryPercent = bike.BatteryPercent;
            dbBike.Dock = bike.Dock;
            dbBike.Model = bike.Model;
        }
        return dbBike;
    }

    public async Task<bool> DeleteBike(Guid bikeId)
    {
        //todo: remove this emloyee from his tasks
        var dbBike = Bikes.Where(t => t.Id == bikeId).FirstOrDefault();
        if (dbBike is not null)
        {
            Bikes.Remove(dbBike);
            return true;
        }
        return false;
    }
}
