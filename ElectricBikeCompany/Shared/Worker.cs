namespace ElectricBikeCompany.Shared;

public class Worker
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Bus? Bus { get; set; }
}
