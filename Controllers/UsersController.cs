using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Hospitals.Models;
using Microsoft.AspNetCore.Identity;
using parcial1_hospitales.Services;

namespace Hospitals.Controllers;

public class UsersController : Controller
{
    
    private IUsersService _userService;

    public UsersController(IUsersService userService)
    {
        _userService = userService;
    }

    public IActionResult Index()
    {
        var users = _userService.GetAll();
        return View(users);
    }
}