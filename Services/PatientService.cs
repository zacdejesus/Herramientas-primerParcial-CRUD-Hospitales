namespace parcial1_hospitales.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Hospitals.Data;
using parcial1_hospitales.Models;

public class PatientService : IPatientService
{

    private readonly ApplicationDbContext _context;

    public PatientService(ApplicationDbContext context)
    {
        _context = context;
    }

    public ApplicationDbContext getContext()
    {
        return _context;
    }

    public void Create(Patient obj)
    {
        _context.Add(obj);
        _context.SaveChangesAsync();
    }

    public List<Patient> GetAll(string? filter)
    {
        var query = from Patient in _context.Patients select Patient;

        if (!string.IsNullOrEmpty(filter))
        {
            query = query.Where(x => x.Name.ToLower().Contains(filter.ToLower()) || x.Age.ToString().ToLower().Contains(filter.ToLower()));
        }

        return query.ToList();
    }

    public void Update(Patient obj, int id)
    {
        _context.Update(obj);
        _context.SaveChangesAsync();
    }

    public void Delete(Patient obj)
    {
        _context.Patients.Remove(obj);
        _context.SaveChangesAsync();
    }

    public async Task<Patient?> GetById(int? id)
    {
        var task = await _context.Patients.FirstOrDefaultAsync(m => m.Id == id);

        return task;
    }
}