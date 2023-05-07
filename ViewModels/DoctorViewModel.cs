using parcial1_hospitales.Models;
namespace parcial1_hospitales.ViewModels;
public class DoctorViewModel
{
    public List<Doctor>? doctors { get; set; }
    public string? filter { get; set; }
}