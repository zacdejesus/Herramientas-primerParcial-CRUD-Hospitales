using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Hospitals.Models;
using Microsoft.AspNetCore.Identity;
using parcial1_hospitales.Services;
using parcial1_hospitales.Views.Users.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace Hospitals.Controllers;

public class UsersController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public UsersController(
        ILogger<HomeController> logger,
        UserManager<IdentityUser> userManager,
        RoleManager<IdentityRole> roleManager)
    {
        _logger = logger;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public IActionResult Index()
    {
        //listar todos los usuarios
        var users = _userManager.Users.ToList();
        return View(users);
    }

    public async Task<IActionResult> Edit(string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        
        var userViewModel = new UserEditViewModel();
        userViewModel.UserName = user.UserName ?? string.Empty;
        userViewModel.Email = user.Email ?? string.Empty;
        userViewModel.Roles = new SelectList(_roleManager.Roles.ToList());

        return View(userViewModel);
    }

[HttpPost]
public async Task<IActionResult> Edit(UserEditViewModel model)
{
    var user = await _userManager.FindByNameAsync(model.UserName);
    
    if (user != null)
    {
        if (model.Role == null)
        {
            Console.WriteLine("model.Role is null");
        }

        await _userManager.AddToRoleAsync(user, model.Role);
    }
    else
    {
        Console.WriteLine("user is null");
    }

    return RedirectToAction("Index");
}

}