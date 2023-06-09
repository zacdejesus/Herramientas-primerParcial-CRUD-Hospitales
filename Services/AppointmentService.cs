namespace parcial1_hospitales.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using parcial1_hospitales.Models;
using Hospitals.Data;
using Microsoft.EntityFrameworkCore;

public class AppointmentService : IAppointmentService
{

    private readonly ApplicationDbContext _context;

    public AppointmentService(ApplicationDbContext context)
    {
        _context = context;
    }

    public ApplicationDbContext getContext()
    {
        return _context;
    }

    public void Create(Appointment obj)
    {
        _context.Add(obj);
        _context.SaveChangesAsync();
    }

    public List<Appointment> GetAll(string? filter)
    {
        if (!string.IsNullOrEmpty(filter))
        {
            return _context.Appointments
                .Include(a => a.Doctor)
                .Include(a => a.Patient)
                .Where(a => a.Description.Contains(filter.ToLower())).ToList();
        }

        return _context.Appointments
               .Include(a => a.Doctor)
               .Include(a => a.Patient).ToList();
    }

    public void Update(Appointment obj, int id)
    {
        _context.Update(obj);
        _context.SaveChangesAsync();
    }

    public void Delete(Appointment hospital)
    {
        _context.Appointments.Remove(hospital);
        _context.SaveChangesAsync();
    }

    public async Task<Appointment?> GetById(int? id)
    {
        var hospitalTask = await _context.Appointments
                                    .Include(a => a.Doctor)
                                    .Include(a => a.Patient)
                                    .FirstOrDefaultAsync(m => m.Id == id);

        return hospitalTask;
    }

    public List<Patient> GetAllPatients()
    {
        var query = from Patient in _context.Patients select Patient;
        return query.ToList();
    }

    public void DeleteAllAppointmentsByPatientId(int? id) {
        var appointments = GetAll("");

            var filteredAppointments = appointments.Where(a => a.PatientId == id).ToList();

            _context.RemoveRange(filteredAppointments);
            _context.SaveChanges();
    }
}