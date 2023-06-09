namespace parcial1_hospitales.Services;

using Hospitals.Data;
using parcial1_hospitales.Models;

public interface IHospitalService {
    void Create(Hospital obj);
    List<Hospital> GetAll(string? filter);
    void Update(Hospital obj, int id);
    void Delete(Hospital obj);
    Task<Hospital?> GetById(int? id);
    ApplicationDbContext getContext();
}