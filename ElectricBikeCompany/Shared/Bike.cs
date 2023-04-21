namespace ElectricBikeCompany.Shared;

public class Bike
{
    public Guid Id { get; set; }
    public int BatteryPercent { get; set; }
    public Model Model { get; set; }
    public Dock? Dock { get; set; }
}
