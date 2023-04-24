namespace ElectricBikeCompany.Shared;

public class User
{
    public Guid Id { get; set; }
    public string Username { get; set; }

    //todo: hashed password
    public string? Password { get; set; }
}
