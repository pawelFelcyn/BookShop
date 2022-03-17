using AspNetAuthentication.Settings;
using AspNetAuthentication.TokenGeneration;
using Domain.Entities;
using System.Security.Claims;

namespace Application.Authentication
{
    public class UserJwtTokenGenerator : JwtTokenGeterator<User>
    {
        public UserJwtTokenGenerator(IAuthenticationSettings authenticationSettings) : base(authenticationSettings)
        {
            IncludeInClaims(ClaimTypes.NameIdentifier, u => u.Id.ToString());
            IncludeInClaims(ClaimTypes.Email, u => u.Email);
            IncludeInClaims(ClaimTypes.Role, u => u.RoleName);
        }
    }
}
