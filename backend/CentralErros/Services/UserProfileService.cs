using CentralErros.Models;
using IdentityServer4.Models;
using IdentityServer4.Services;
using IdentityServer4.Validation;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CentralErros.Services
{
    public class UserProfileService : IProfileService
    {
        private readonly CentralErrosContext dbContext;

        public UserProfileService(CentralErrosContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var request = context.ValidatedRequest as ValidatedTokenRequest;

            if (request != null)
            {
                var user = dbContext.Users.FirstOrDefault(t => t.Email == request.UserName);
                if (user != null)
                    context.AddRequestedClaims(GetUserClaims(user));
            }

            return Task.CompletedTask;
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            context.IsActive = true;
            return Task.CompletedTask;
        }


        public static Claim[] GetUserClaims(User user)
        {
            return new[]
            {
                new Claim(ClaimTypes.Name, user.FullName ?? ""),
                new Claim(ClaimTypes.Email, user.Email ?? ""),
                new Claim(ClaimTypes.Role, "user")
            };
        }
    }
}
