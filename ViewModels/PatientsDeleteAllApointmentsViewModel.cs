using parcial1_hospitales.Models;

namespace parcial1_hospitales.ViewModels;
public class PatientsDeleteAllApointmentsViewModel
{
    public int PatientId { get; set; }
    public List<Patient>? patients { get; set; }
}