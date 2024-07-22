namespace Backend.Models;

public class CountryModel
{
    public uint Id { get; set; }

    public string Name { get; set; } = null!;

    public string CountryCode { get; set; } = null!;
}
