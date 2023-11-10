using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace MicrosoftEntraId.Auth.WebApp.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult SignIn(string scheme, string redirectUri)
        {
            scheme ??= OpenIdConnectDefaults.AuthenticationScheme;
            string redirect = !string.IsNullOrEmpty(redirectUri) && Url.IsLocalUrl(redirectUri) ? redirectUri : Url.Content("~/");
            return Challenge(new AuthenticationProperties { RedirectUri = redirect }, scheme);
        }

        [HttpGet]
        public IActionResult SignOut(string scheme)
        {
            scheme ??= OpenIdConnectDefaults.AuthenticationScheme;
            var callbackUrl = Url.Page("/Account/SignedOut", pageHandler: null, values: null, protocol: Request.Scheme);
            return SignOut(new AuthenticationProperties { RedirectUri = callbackUrl }, CookieAuthenticationDefaults.AuthenticationScheme, scheme);
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }

}
