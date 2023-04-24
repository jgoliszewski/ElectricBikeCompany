using ElectricBikeCompany.Shared;

namespace ElectricBikeCompany.Client.Services;

public interface IBusService
{
    List<Bus> Buses { get; set; }
    Task GetBuses();
    Task<Bus?> GetBusById(Guid busId);
    Task CreateBus(Bus bus);
    Task UpdateBus(Guid busId, Bus bus);
    Task DeleteBus(Guid busId);
}
