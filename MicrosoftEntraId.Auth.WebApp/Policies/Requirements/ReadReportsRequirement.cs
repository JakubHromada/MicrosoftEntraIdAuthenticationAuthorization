using Microsoft.AspNetCore.Authorization;
using MicrosoftEntraId.Auth.WebApp.Constants;
using MicrosoftEntraId.Auth.WebApp.Policies.Handlers;

namespace MicrosoftEntraId.Auth.WebApp.Policies.Requirements
{
    public class ReadReportsRequirement : IAuthorizationRequirement, IRoleRequirement
    {
        public List<string> Roles => new() {
            AuthorizationConstants.Roles.DocumentManager,
            AuthorizationConstants.Roles.DocumentReader,
            AuthorizationConstants.Roles.DocumentEditor,
        };
    }
}