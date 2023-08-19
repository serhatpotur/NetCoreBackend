namespace NetCoreBackend.Core.Utilities.Security.JWT;

public class AccessToken
{
    public string Token { get; set; }
    public DateTime Expiration { get; set; }// token bitiş süresi
}
