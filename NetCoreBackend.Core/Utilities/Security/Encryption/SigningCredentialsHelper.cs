using Microsoft.IdentityModel.Tokens;

namespace NetCoreBackend.Core.Utilities.Security.Encryption;

public  class SigningCredentialsHelper
{
    //appsettings.json içersinde ki SecurityKey değerini byte hale getirir   
    public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
    {
        return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);
    }
}
