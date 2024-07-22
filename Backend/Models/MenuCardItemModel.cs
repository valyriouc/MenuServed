namespace Backend.Models;

public enum ItemKind
{
    Drink,
    Meal
}

public class MenuCardItemModel
{
    public uint Id { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public ItemKind Kind { get; set; }

    public int Price { get; set; }

    // TODO: Incredient list 

    public string ImgPath { get; set; } = null!;
}