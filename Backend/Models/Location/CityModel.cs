namespace Backend.Models;

public class CityModel
{
    public uint Id { get; set; }

    public string Name { get; set; } = null!;

    public List<AddressModel> Addresses { get; set; } = new List<AddressModel>();
}
