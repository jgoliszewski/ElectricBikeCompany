namespace ElectricBikeCompany.Shared;

public class Dock
{
    public Guid Id { get; set; }
    public int Capacity { get; set; }
    public int Taken_spaces { get; set; }
    public string Address { get; set; }
}
