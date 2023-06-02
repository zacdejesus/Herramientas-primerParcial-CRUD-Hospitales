namespace parcial1_hospitales.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Hospitals.Data;
using parcial1_hospitales.Models;
using parcial1_hospitales.ViewModels;

public class HospitalService : IHospitalService
{

    private readonly ApplicationDbContext _context;

    public HospitalService(ApplicationDbContext context)
    {
        _context = context;
    }

    public void Create(Hospital obj)
    {
        throw new NotImplementedException();
    }

    public List<Hospital> GetAll(string? filter)
    {
        var query = from Hospital in _context.Hospitals select Hospital;

        if (!string.IsNullOrEmpty(filter))
        {
            query = query.Where(x => x.Name.Contains(filter.ToLower()));
        }

        return query.Include(x => x.Doctors).ToList();
    }

    public void Update(Hospital obj, int id)
    {
        throw new NotImplementedException();
    }

    public void Delete(Hospital obj)
    {
        throw new NotImplementedException();
    }

    public Hospital GetById(int id)
    {
        throw new NotImplementedException();
    }
}