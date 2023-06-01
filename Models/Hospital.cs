namespace parcial1_hospitales.Models;
public class Hospital
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public List<Doctor>? Doctors { get; set; }
}