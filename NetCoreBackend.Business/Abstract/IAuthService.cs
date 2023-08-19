using NetCoreBackend.Core.Entities.Concrete;
using NetCoreBackend.Core.Utilities.Results.Abstract;
using NetCoreBackend.Core.Utilities.Security.JWT;
using NetCoreBackend.Entities.DTOs;

namespace NetCoreBackend.Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password);
        IDataResult<User> Login(UserForLoginDto userForLoginDto);
        IResult UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(User user);
    }
}
