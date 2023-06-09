namespace parcial1_hospitales.Services;
using parcial1_hospitales.Models;
using Microsoft.AspNetCore.Identity;
using Hospitals.Data;

public interface IUsersService
{

    List<IdentityUser> GetAll();
    Task<IdentityUser?> findId(string? id);
    UserManager<IdentityUser> getManager();
}