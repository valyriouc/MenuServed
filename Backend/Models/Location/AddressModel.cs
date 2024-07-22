namespace Backend.Models;

public class AddressModel
{
    public uint Id { get; set; }

    public short HouseNumber { get; set; }

    public string StreetName { get; set; } = null!;

    public CityModel City { get; set; } = null!;

    public CountryModel Country { get; set; } = null!;

    public uint ZipCode { get; set; }
}
