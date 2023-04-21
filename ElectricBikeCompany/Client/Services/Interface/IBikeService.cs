using ElectricBikeCompany.Shared;

namespace ElectricBikeCompany.Client.Services;

public interface IBikeService
{
    List<Bike> Bikes { get; set; }
    Task GetBikes();
    Task<Bike?> GetBikeById(Guid bikeId);
    Task CreateBike(Bike bike);
    Task UpdateBike(Guid bikeId, Bike bike);
    Task DeleteBike(Guid bikeId);
}
