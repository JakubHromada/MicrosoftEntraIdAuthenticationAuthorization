using Microsoft.AspNetCore.Authorization;
using MicrosoftEntraId.Auth.WebApp.Policies.Handlers;
using MicrosoftEntraId.Auth.WebApp.Constants;

namespace MicrosoftEntraId.Auth.WebApp.Policies.Requirements;

public class ReportsListingRequirement : IAuthorizationRequirement, IRoleRequirement
{
    public List<string> Roles => new() {
        AuthorizationConstants.Roles.DocumentReader,
        AuthorizationConstants.Roles.DocumentManager,
        AuthorizationConstants.Roles.DocumentContributor,
        AuthorizationConstants.Roles.DocumentEditor 
    };
}