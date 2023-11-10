using Microsoft.AspNetCore.Authorization;

namespace MicrosoftEntraId.Auth.WebApp.Policies.Handlers
{
    public interface IRoleRequirement : IAuthorizationRequirement
    {
        public List<string> Roles { get; }
    }
}
