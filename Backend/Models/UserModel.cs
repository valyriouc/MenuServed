namespace Backend.Models;

public enum UserRole
{
    Customer,
    Employee,
    Owner
}

/// <summary>
/// The filters which the user has set, to find his restaurents
/// </summary>
public class Filter
{

}

/// <summary>
/// The basic user model
/// </summary>
public class UserModel
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public UserRole Role { get; set; }

    public string Password { get; set; } = null!;
}

public class RestaurentCategory
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;
}

public class Location
{
    public int Id { get; set; }

}

public class Desk
{
    public int Id { get; set; }
    
    public string? Name { get; set; }

    public short Number { get; set; }
    
    public byte SeatCount { get; set; }

    public bool IsFree { get; set; }
}

public enum ItemKind
{
    Drink,
    Meal
}

public class MenuCardItem
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; } 

    public ItemKind Kind { get; set; }  

    public int Price { get; set; }
}

/// <summary>
/// What has to be in the menu card 
/// 
/// </summary>
public class MenuCard
{
    public int Id { get; set; }

    public bool WithPdf { get; set; }

    public string? Path { get; set; }

    public byte[] GetFileContent()
    {
        return Array.Empty<byte>();
    }
}

public class Restaurent
{
    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public Location Location { get; set; } = null!;

    public List<RestaurentCategory> Categories { get; set; } 
        = new List<RestaurentCategory>();

    public List<Desk> Tables { get; set; }
        = new List<Desk>();

    public bool WithPickUp { get; set; }

    public bool WithDelivery { get; set; }

}