using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Hospitals.Models;
using Microsoft.AspNetCore.Identity;

namespace Hospitals.Controllers;

public class UsersController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly UserManager<IdentityUser> _userManager;

    public UsersController(ILogger<HomeController> logger,  UserManager<IdentityUser> userManager)
    {
        _logger = logger;
        _userManager = userManager;
    }

    public IActionResult Index()
    {
        var users = _userManager.Users.ToList();
        return View(users);
    }
}