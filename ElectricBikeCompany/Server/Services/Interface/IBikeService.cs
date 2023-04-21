using ElectricBikeCompany.Shared;

namespace ElectricBikeCompany.Server.Services;

public interface IBikeService
{
    Task<List<Bike>> GetBikes();
    Task<Bike?> GetBikeById(Guid BikeId);
    Task<Bike> CreateBike(Bike Bike);
    Task<Bike?> UpdateBike(Guid BikeId, Bike Bike);
    Task<bool> DeleteBike(Guid BikeId);
}
