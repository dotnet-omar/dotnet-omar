using System.Security.Cryptography;
using System.Text;

namespace DotnetOmar.Helper;

public static class Helper
{
    public static string GetHash(string text)
    {
        var textBytes = Encoding.UTF8.GetBytes(text);
        var hash = SHA256.HashData(textBytes);
        return BitConverter.ToString(hash);
    }
}