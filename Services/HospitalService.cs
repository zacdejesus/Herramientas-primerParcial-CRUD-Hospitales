namespace parcial1_hospitales.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Hospitals.Data;
using parcial1_hospitales.Models;

public class HospitalService : IHospitalService
{
    private readonly ApplicationDbContext _context;

    public HospitalService(ApplicationDbContext context)
    {
        _context = context;
    }

    public ApplicationDbContext getContext()
    {
        return _context;
    }

    public void Create(Hospital obj)
    {
        _context.Add(obj);
        _context.SaveChangesAsync();
    }

    public List<Hospital> GetAll(string? filter)
    {

        if (!string.IsNullOrEmpty(filter))
        {
            return _context.Hospitals
                .Include(a => a.Doctors)
                .Where(a => a.Name.Contains(filter.ToLower()) || a.Address.Contains(filter.ToLower())).ToList();
        }

        return _context.Hospitals
               .Include(a => a.Doctors).ToList();
    }

    public void Update(Hospital obj, int id)
    {
        _context.Update(obj);
        _context.SaveChangesAsync();
    }

    public void Delete(Hospital hospital)
    {
        _context.Hospitals.Remove(hospital);
        _context.SaveChangesAsync();
    }

    public async Task<Hospital?> GetById(int? id)
    {
        var hospitalTask = await _context.Hospitals.FirstOrDefaultAsync(m => m.Id == id);

        return hospitalTask;
    }
}