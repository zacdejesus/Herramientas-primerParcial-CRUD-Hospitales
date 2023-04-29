namespace parcial1_hospitales.Models;
public class Hospital
{
    public int id { set; get; }
    public string? name { get; set; }
    public string? address { get; set; }
    public List<Doctor>? Doctors { get; set; }
}