using System.Security.Cryptography;
using System.Text;

namespace NetCoreBackend.Core.Utilities.Security.Hashing;

public static class HashingHelper
{
    //out : gelen değer boş bile olsa doldurup döndürür. referans yapılar için 
    public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        using (var hmac = new HMACSHA512())
        {
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }
    }

    // Passworod Hash doğrular
    public static bool VerifyPasswordHash(string password,  byte[] passwordHash,  byte[] passwordSalt)
    {
        using (var hmac = new HMACSHA512(passwordSalt))
        {
          var  computedPasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            for (int i = 0; i < computedPasswordHash.Length; i++)
            {
                if (computedPasswordHash[i] != passwordHash[i])
                {
                    return false;
                }
            }
        }
        return true;

    }
}
