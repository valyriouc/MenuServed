using System.Security.Cryptography;
using System.Text;

namespace Backend.Helpers;

public static class HashHelper
{
    public static string ComputeSha512(string input)
    {
        if (input is null)
        {
            throw new ArgumentNullException(nameof(input));
        }

        using SHA512 sha512 = SHA512.Create();

        byte[] bytes = sha512.ComputeHash(Encoding.UTF8.GetBytes(input));
        string base64String = BitConverter.ToString(bytes).Replace("-", "").ToLowerInvariant();

        return base64String;
    }
}
