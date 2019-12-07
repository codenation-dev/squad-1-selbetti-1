using CentralErros.Models;
using IdentityServer4.Models;
using IdentityServer4.Validation;
using System.Linq;
using System.Threading.Tasks;

namespace CentralErros.Services
{
    public class PasswordValidatorService : IResourceOwnerPasswordValidator
    {
        private readonly CentralErrosContext dbContext;

        public PasswordValidatorService(CentralErrosContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var user = dbContext.Users.FirstOrDefault(t => t.Email == context.UserName);

            if (user != null && user.Password == context.Password)
            {
                context.Result = new GrantValidationResult(
                    subject: user.Id.ToString(),
                    authenticationMethod: "custom",
                    claims: UserProfileService.GetUserClaims(user));
            }
            else
            {
                context.Result = new GrantValidationResult(
                    TokenRequestErrors.InvalidGrant, "Invalid username or password");
            }

            return Task.CompletedTask;
        }
    }
}
