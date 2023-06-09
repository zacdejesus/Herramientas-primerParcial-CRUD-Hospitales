using parcial1_hospitales.Models;

namespace parcial1_hospitales.ViewModels;
public class AppointmentViewModel
{
    public List<Appointment>? appointments { get; set; }
    public string? filter { get; set; }
    public bool isAvailable { get; set; }
}