namespace parcial1_hospitales.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

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
}