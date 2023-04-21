namespace ElectricBikeCompany.Shared;

public class Rent
{
    public Guid Id { get; set; }
    public User User { get; set; }
    public Bike Bike { get; set; }
    public DateTime? Rent_start { get; set; }
    public DateTime? Rent_end { get; set; }
    public Dock Dock_start { get; set; }
    public Dock? Dock_end { get; set; }
}
