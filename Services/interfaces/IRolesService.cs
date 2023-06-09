namespace parcial1_hospitales.Services;
using parcial1_hospitales.Models;
using Microsoft.AspNetCore.Identity;

public interface IRolesService
{

    List<IdentityRole> GetAll();
    bool roleExists(string roleName);
    void create(string roleName);

}