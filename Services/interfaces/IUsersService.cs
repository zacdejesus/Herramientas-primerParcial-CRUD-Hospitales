namespace parcial1_hospitales.Services;
using parcial1_hospitales.Models;
using Microsoft.AspNetCore.Identity;

public interface IUsersService
{

    List<IdentityUser> GetAll();

}