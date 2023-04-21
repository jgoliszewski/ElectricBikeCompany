using ElectricBikeCompany.Shared;

namespace ElectricBikeCompany.Server.Services;

public class RentService : IRentService
{
    public List<Rent> Rents = new List<Rent>();

    public async Task<List<Rent>> GetRents()
    {
        return Rents;
    }

    public async Task<Rent?> GetRentById(Guid rentId)
    {
        var dbRent = Rents.Where(t => t.Id == rentId).FirstOrDefault();
        return dbRent;
    }

    public async Task<Rent> CreateRent(Rent rent)
    {
        rent.Id = Guid.NewGuid();
        Rents.Add(rent);
        return rent;
    }

    public async Task<Rent?> UpdateRent(Guid rentId, Rent rent)
    {
        var dbRent = Rents.Where(t => t.Id == rentId).FirstOrDefault();
        if (dbRent is not null)
        {
            dbRent.User = rent.User;
            dbRent.Bike = rent.Bike;
            dbRent.Dock_start = rent.Dock_start;
            dbRent.Dock_end = rent.Dock_end;
            dbRent.Rent_start = rent.Rent_start;
            dbRent.Rent_end = rent.Rent_end;
        }
        return dbRent;
    }

    public async Task<bool> DeleteRent(Guid rentId)
    {
        //todo: remove this emloyee from his tasks
        var dbRent = Rents.Where(t => t.Id == rentId).FirstOrDefault();
        if (dbRent is not null)
        {
            Rents.Remove(dbRent);
            return true;
        }
        return false;
    }
}
