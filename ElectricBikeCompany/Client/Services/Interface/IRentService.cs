using ElectricBikeCompany.Shared;

namespace ElectricBikeCompany.Client.Services;

public interface IRentService
{
    List<Rent> Rents { get; set; }
    Task GetRents();
    Task<Rent?> GetRentById(Guid rentId);
    Task CreateRent(Rent rent);
    Task UpdateRent(Guid rentId, Rent rent);
    Task DeleteRent(Guid rentId);
}
