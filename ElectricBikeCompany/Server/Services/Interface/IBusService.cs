using ElectricBikeCompany.Shared;

namespace ElectricBikeCompany.Server.Services;

public interface IBusService
{
    Task<List<Bus>> GetBuss();
    Task<Bus?> GetBusById(Guid BusId);
    Task<Bus> CreateBus(Bus Bus);
    Task<Bus?> UpdateBus(Guid BusId, Bus Bus);
    Task<bool> DeleteBus(Guid BusId);
}
