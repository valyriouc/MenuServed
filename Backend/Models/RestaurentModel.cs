namespace Backend.Models;

public class RestaurentModel
{
    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public LocationModel Location { get; set; } = null!;

    public List<RestaurentCategoryModel> Categories { get; set; }
        = new List<RestaurentCategoryModel>();

    public List<DeskModel> Tables { get; set; }
        = new List<DeskModel>();

    public bool WithPickUp { get; set; }

    public bool WithDelivery { get; set; }

}