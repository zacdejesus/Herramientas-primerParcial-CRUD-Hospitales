namespace parcial1_hospitales.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Hospitals.Data;
using parcial1_hospitales.Models;

public class DoctorService : IDoctorService
{

    private readonly ApplicationDbContext _context;

    public DoctorService(ApplicationDbContext context)
    {
        _context = context;
    }

    public ApplicationDbContext getContext()
    {
        return _context;
    }

    public void Create(Doctor obj)
    {
        _context.Add(obj);
        _context.SaveChangesAsync();
    }

    public List<Doctor> GetAll(string? filter, bool? isAvailable)
    {
        var query = from Doctor in _context.Doctors select Doctor;

        if (isAvailable != null)
        {
            query = query.Where(x => x.IsAvailable == isAvailable);
        }

        if (!string.IsNullOrEmpty(filter))
        {
            query = query.Where(x => x.Name.ToLower().Contains(filter.ToLower()));
        }

        var queryready = query.Include(x => x.Hospital).ToList();
        return queryready;
    }

    public void Update(Doctor obj, int id)
    {
        _context.Update(obj);
        _context.SaveChangesAsync();
    }

    public void Delete(Doctor obj)
    {
        _context.Doctors.Remove(obj);
        _context.SaveChangesAsync();
    }

    public async Task<Doctor?> GetById(int? id)
    {
        var task = await _context.Doctors.FirstOrDefaultAsync(m => m.Id == id);

        return task;
    }
}