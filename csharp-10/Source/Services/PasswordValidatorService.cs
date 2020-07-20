using Codenation.Challenge.Models;
using IdentityServer4.Models;
using IdentityServer4.Validation;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
 
namespace Codenation.Challenge.Services
{
    public class PasswordValidatorService: IResourceOwnerPasswordValidator
    {
        private readonly CodenationContext _context;

        public PasswordValidatorService(CodenationContext dbContext)
        {
            _context = dbContext;
        }

        public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var user = _context.Users.Where(x => x.Email.Equals(context.UserName) && x.Password.Equals(context.Password)).AsNoTracking().FirstOrDefault();

            if(user == null)
            {
                context.Result = new GrantValidationResult(
                TokenRequestErrors.InvalidGrant, "Invalid username or password");
            }
            else
            {
                context.Result = new GrantValidationResult(
                subject: user.Id.ToString(),
                authenticationMethod: "custom",
                claims: UserProfileService.GetUserClaims(user));
            }

            return Task.CompletedTask;
        }
    }
}