using ElectricBikeCompany.Shared;

namespace ElectricBikeCompany.Server.Services;

public interface IRentService
{
    Task<List<Rent>> GetRents();
    Task<Rent?> GetRentById(Guid RentId);
    Task<Rent> CreateRent(Rent Rent);
    Task<Rent?> UpdateRent(Guid RentId, Rent Rent);
    Task<bool> DeleteRent(Guid RentId);
}
