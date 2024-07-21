namespace Backend.Models;

/// <summary>
/// What has to be in the menu card
/// </summary>
public class MenuCardModel
{
    public int Id { get; set; }

    public bool WithPdf { get; set; }

    public string? Path { get; set; }

    public byte[] GetFileContent()
    {
        return Array.Empty<byte>();
    }
}

