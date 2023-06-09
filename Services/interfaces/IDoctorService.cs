namespace parcial1_hospitales.Services;
using parcial1_hospitales.Models;
using Microsoft.EntityFrameworkCore;
using Hospitals.Data;

public interface IDoctorService {
    void Create(Doctor obj);
    List<Doctor> GetAll(string? filter);
    void Update(Doctor obj, int id);
    void Delete(Doctor obj);
    Task<Doctor?> GetById(int? id);
    ApplicationDbContext getContext();
}