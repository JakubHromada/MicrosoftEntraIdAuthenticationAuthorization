using Microsoft.AspNetCore.Authorization;
using MicrosoftEntraId.Auth.WebApp.Constants;

namespace MicrosoftEntraId.Auth.WebApp.Policies.Handlers
{
    public class PermissionHandler<T> : AuthorizationHandler<T> where T : IRoleRequirement
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, T requirement) 
        {
            if (context.User.HasClaim(claim => claim.Type == AuthorizationConstants.ClaimType.Role) 
                    && context.User.HasClaim(claim => requirement.Roles.Any(role => claim.Value == role)))
            {
                context.Succeed(requirement);
            }
            return Task.FromResult(0);
        }
    }
}
