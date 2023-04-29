//using parcial1_hospitales.Utils;

namespace parcial1_hospitales.Models;

public class Doctor
{
    public int id { get; set; }
    public string name { get; set; }
    public int Age { get; set; }
    public bool isAvailable { get; set; }
    public string specialty { get; set; }

    public int? hospitalId { get; set; }
    public virtual Hospital? hospital { get; set; }
}