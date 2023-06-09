namespace parcial1_hospitales.Services;
using parcial1_hospitales.Models;
using Microsoft.EntityFrameworkCore;
using Hospitals.Data;

public interface IPatientService {
    void Create(Patient obj);
    List<Patient> GetAll(string? filter);
    void Update(Patient obj, int id);
    void Delete(Patient obj);
    Task<Patient?> GetById(int? id);
    ApplicationDbContext getContext();
}