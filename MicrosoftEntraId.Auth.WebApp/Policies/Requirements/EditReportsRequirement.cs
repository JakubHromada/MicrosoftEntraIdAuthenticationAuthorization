using Microsoft.AspNetCore.Authorization;
using MicrosoftEntraId.Auth.WebApp.Constants;
using MicrosoftEntraId.Auth.WebApp.Policies.Handlers;

namespace MicrosoftEntraId.Auth.WebApp.Policies.Requirements
{
    public class EditReportsRequirement : IAuthorizationRequirement, IRoleRequirement
    {
        public List<string> Roles => new() {
            AuthorizationConstants.Roles.DocumentManager,
            AuthorizationConstants.Roles.DocumentEditor
        };
    }
}