using System.Text.Json;

namespace Backend.Helpers;

internal struct Secrets
{
    public string Secret { get; set; }

    public string Issuer { get; set; }

    public string Audience { get; set; }    

    private static Secrets? _instance = null;

    public static Secrets Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = Secrets.FromFile("secrets.json");
            }

            return _instance ?? throw new Exception();
        }
    }

    private static Secrets FromFile(string file) => JsonSerializer.Deserialize<Secrets>(file);
}
