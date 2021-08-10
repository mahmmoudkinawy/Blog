using BlogAPI.Models.Account;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;

namespace BlogAPI.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> CreateAsync(ApplicationUserIdentity user, CancellationToken cancellationToken);
        Task<ApplicationUserIdentity> GetByUsernameAsync(string normalizedUsername, CancellationToken cancellationToken);
    }
}
