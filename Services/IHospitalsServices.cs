using parcial1_hospitales.Models;
namespace parcial1_hospitales.Services;

public interface IHospitalesServices
{
    void Create(Hospital hospital);
    List<Hospital> getAll();
}