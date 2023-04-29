using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using parcial1_hospitales.Models;

namespace Hospitales.Data
{
    public class HospitalesContext : DbContext
    {
        public HospitalesContext (DbContextOptions<HospitalesContext> options)
            : base(options)
        {
        }

        public DbSet<parcial1_hospitales.Models.Hospital> Hospital { get; set; } = default!;

        public DbSet<parcial1_hospitales.Models.Doctor> Doctor { get; set; } = default!;
    }
}
