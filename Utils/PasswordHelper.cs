using System.Security.Cryptography;
using System.Text;

namespace Utils;

public static class PasswordHelper
{
    public static string Hash(string password) =>
        Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(password)));
}
