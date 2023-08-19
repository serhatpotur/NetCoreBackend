using NetCoreBackend.Core.Entities.Concrete;

namespace NetCoreBackend.Core.Utilities.Security.JWT;

public interface ITokenHelper
{
    AccessToken CreateToken(User user,List<OperationClaim> operationClaims);
}
