namespace Backend.Models;

/// <summary>
/// What has to be in the menu card
/// </summary>
public class MenuCardModel
{
    public uint Id { get; set; }

    public bool WithPdf { get; set; }

    public string? Path { get; set; }

    public bool IsCurrent { get; set; }

    public List<MenuCardItemModel> Items { get; set; } 
        = new List<MenuCardItemModel>();

    public byte[] GetFileContent()
    {
        return Array.Empty<byte>();
    }
}

