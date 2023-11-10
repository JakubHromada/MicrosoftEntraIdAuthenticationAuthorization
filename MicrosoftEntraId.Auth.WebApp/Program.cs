using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Identity.Web;
using MicrosoftEntraId.Auth.WebApp.Policies.Handlers;
using MicrosoftEntraId.Auth.WebApp.Policies.Requirements;
using System.IdentityModel.Tokens.Jwt;
using static MicrosoftEntraId.Auth.WebApp.Constants.AuthorizationConstants;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// This is required to be instantiated before the OpenIdConnectOptions starts getting configured.
// By default, the claims mapping will map claim names in the old format to accommodate older SAML applications.
// For instance, 'http://schemas.microsoft.com/ws/2008/06/identity/claims/role' instead of 'roles' claim.
// This flag ensures that the ClaimsIdentity claims collection will be built from the claims in the token
JwtSecurityTokenHandler.DefaultMapInboundClaims = false;

// Sign-in users with the Microsoft identity platform
builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme) // test using AzureADDefaults from the AzureAD.Ui package
    .AddMicrosoftIdentityWebApp(builder.Configuration)
    .EnableTokenAcquisitionToCallDownstreamApi()
    .AddInMemoryTokenCaches();

builder.Services.AddControllersWithViews();

// this is to use the built-in automatic authentication inside Microsoft.Identity.Web.UI package
// when enabled the user will be automatically redirected to login screen upon accessing the application
//builder.Services.AddControllersWithViews(options =>
//{
//    var policy = new AuthorizationPolicyBuilder()
//        .RequireAuthenticatedUser()
//        .Build();
//    options.Filters.Add(new AuthorizeFilter(policy));
//}).AddMicrosoftIdentityUI();

ConfigureCustomPolicies(builder.Services);

builder.Services.AddSingleton<IAuthorizationHandler, PermissionHandler<ReportsListingRequirement>>();
builder.Services.AddSingleton<IAuthorizationHandler, PermissionHandler<EditReportsRequirement>>();
builder.Services.AddSingleton<IAuthorizationHandler, PermissionHandler<CreateReportsRequirement>>();
builder.Services.AddSingleton<IAuthorizationHandler, PermissionHandler<ReadReportsRequirement>>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

void ConfigureCustomPolicies(IServiceCollection services)
{
    builder.Services.AddAuthorization(options =>
    {
        // Func based implementation
        //options.AddPolicy("DocumentEditorPolicy", policy =>
        //    policy.RequireAssertion(context => context.User.HasClaim(c =>
        //        c.Value == Roles.DocumentEditor)));

        // basic implementation
        //options.AddPolicy("DocumentEditorPolicy", policy => {
        //    policy.RequireClaim("roles", Roles.DocumentEditor);
        //});

        options.AddPolicy(
                Policy.ReportsListing,
                policyBuilder => policyBuilder.AddRequirements(
                    new ReportsListingRequirement()));

        options.AddPolicy(
                Policy.EditReports,
                policyBuilder => policyBuilder.AddRequirements(
                    new EditReportsRequirement()));

        options.AddPolicy(
                Policy.CreateReports,
                policyBuilder => policyBuilder.AddRequirements(
                    new CreateReportsRequirement()));
        
        options.AddPolicy(
                Policy.ReadReports,
                policyBuilder => policyBuilder.AddRequirements(
                    new ReadReportsRequirement()));
    });
}