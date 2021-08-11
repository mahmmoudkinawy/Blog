using BlogAPI.Models.Account;

namespace BlogAPI.Services
{
    public interface ITokenService
    {
        string CreateToken(ApplicationUserIdentity user);
    }
}
