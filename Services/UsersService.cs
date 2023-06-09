namespace parcial1_hospitales.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Hospitals.Data;

public class UsersService : IUsersService
{

    private readonly UserManager<IdentityUser> _userManager;

    public UsersService(UserManager<IdentityUser> userM)
    {
        _userManager = userM;
    }

    public List<IdentityUser> GetAll()
    {
        return _userManager.Users.ToList();
    }

    public async  Task<IdentityUser?> findId(string? id)
    {
        return await _userManager.FindByIdAsync(id);
    }

    public UserManager<IdentityUser> getManager()
    {
        return _userManager;
    }
}