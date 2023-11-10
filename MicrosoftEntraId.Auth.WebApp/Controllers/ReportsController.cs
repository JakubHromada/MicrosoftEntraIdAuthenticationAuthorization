using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static MicrosoftEntraId.Auth.WebApp.Constants.AuthorizationConstants;

namespace MicrosoftEntraId.Auth.WebApp.Controllers;

public class ReportsController : Controller
{
    [HttpGet]
    [Authorize(Policy.ReportsListing)]
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    [Authorize(Policy.CreateReports)]
    public IActionResult Add()
    {
        return View();
    }

    [HttpGet]
    [Authorize(Policy.EditReports)]
    public IActionResult Edit()
    {
        return View();
    }

    [HttpGet]
    [Authorize(Policy.ReadReports)]
    public IActionResult Read()
    {
        return View();
    }
}