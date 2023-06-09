namespace parcial1_hospitales.Services;

using Hospitals.Data;
using parcial1_hospitales.Models;

public interface IAppointmentService {
    void Create(Appointment obj);
    List<Appointment> GetAll(string? filter);
    void Update(Appointment obj, int id);
    void Delete(Appointment obj);
    Task<Appointment?> GetById(int? id);
    ApplicationDbContext getContext();
    
    List<Patient> GetAllPatients();
    void DeleteAllAppointmentsByPatientId(int? id);
}