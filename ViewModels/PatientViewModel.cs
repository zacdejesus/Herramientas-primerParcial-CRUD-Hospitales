using parcial1_hospitales.Models;

namespace parcial1_hospitales.ViewModels;
public class PatientViewModel
{
    public List<Patient>? patients { get; set; }
    public string? filter { get; set; }
    public bool isAvailable { get; set; }
}