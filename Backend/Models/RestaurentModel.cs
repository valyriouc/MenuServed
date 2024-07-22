namespace Backend.Models;

public class RestaurentModel
{
    public uint Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public AddressModel Address { get; set; } = null!;

    public LocationModel Location { get; set; } = null!;

    public List<RestaurentCategoryModel> Categories { get; set; }
        = new List<RestaurentCategoryModel>();

    public List<DeskModel> Tables { get; set; }
        = new List<DeskModel>();

    public List<MenuCardModel> MenuCards { get; set; } 
        = new List<MenuCardModel>();

    public bool WithPickUp { get; set; }

    public bool WithDelivery { get; set; }
}