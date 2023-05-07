using parcial1_hospitales.Models;

namespace parcial1_hospitales.ViewModels;
public class HospitalViewModel
{
    public List<Hospital>? hospitals { get; set; }
    public string? filter { get; set; }
}