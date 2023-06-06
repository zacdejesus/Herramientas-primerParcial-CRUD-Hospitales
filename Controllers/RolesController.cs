using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Hospitals.Models;
using Microsoft.AspNetCore.Identity;

namespace Hospitals.Controllers;

public class RolesController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly RoleManager<IdentityRole> _roleManager;

    public RolesController(ILogger<HomeController> logger,  RoleManager<IdentityRole> roleManager)
    {
        _logger = logger;
        _roleManager = roleManager;
    }

    public IActionResult Index()
    {
        var users = _roleManager.Roles.ToList();
        return View(users);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(string roleName)
    {
        if (!string.IsNullOrEmpty(roleName)) {
            var roleExists = _roleManager.RoleExistsAsync(roleName).Result;
            if (!roleExists)
            {
                var role = new IdentityRole(roleName);
                _roleManager.CreateAsync(role);
            }
        }
        return RedirectToAction("Index");
    }
}