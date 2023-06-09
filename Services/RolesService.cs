namespace parcial1_hospitales.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

public class RolesService : IRolesService
{

    private readonly RoleManager<IdentityRole> _roleManager;

    public RolesService(RoleManager<IdentityRole> roleManager)
    {
        _roleManager = roleManager;
    }

    public List<IdentityRole> GetAll()
    {
        return _roleManager.Roles.ToList();
    }

    public bool roleExists(string roleName)
    {
        return _roleManager.RoleExistsAsync(roleName).Result;
    }

    public void create(string roleName)
    {
        var role = new IdentityRole(roleName);
        _roleManager.CreateAsync(role);
    }
}