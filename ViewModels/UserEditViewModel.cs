using Microsoft.AspNetCore.Mvc.Rendering;

namespace parcial1_hospitales.Views.Users.ViewModels;

public class UserEditViewModel
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }
    public SelectList Roles { get; set; }
}