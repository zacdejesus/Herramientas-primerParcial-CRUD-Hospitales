using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Hospitals.Models;
using Microsoft.AspNetCore.Identity;
using parcial1_hospitales.Services;

namespace Hospitals.Controllers;

public class RolesController : Controller
{

    private IRolesService _roleService;

    public RolesController(IRolesService service)
    {
        _roleService = service;
    }

    public IActionResult Index()
    {
        var users = _roleService.GetAll();
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
            var roleExists = _roleService.roleExists(roleName);
            if (!roleExists)
            {
                _roleService.create(roleName);
            }
        }
        return RedirectToAction("Index");
    }
}