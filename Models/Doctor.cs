namespace parcial1_hospitales.Models;

public class Doctor
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public bool IsAvailable { get; set; }
    public string Specialty { get; set; }
    public int? HospitalId { get; set; }
    public virtual Hospital? Hospital { get; set; }
    public virtual ICollection<Appointment> Appointments { get; set; }
}