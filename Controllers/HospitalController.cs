using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hospitales.Data;
using parcial1_hospitales.Models;

namespace Hospitales.Controllers
{
    public class HospitalController : Controller
    {
        private readonly HospitalesContext _context;

        public HospitalController(HospitalesContext context)
        {
            _context = context;
        }

        // GET: Hospital
        public async Task<IActionResult> Index()
        {
            var model = await _context.Hospital.Include(x => x.Doctors).ToListAsync();
            
            return _context.Hospital != null ? 
                          View(model) :
                          Problem("Entity set 'HospitalesContext.Hospital'  is null.");
        }

        // GET: Hospital/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Hospital == null)
            {
                return NotFound();
            }

            var hospital = await _context.Hospital
                .FirstOrDefaultAsync(m => m.id == id);
            if (hospital == null)
            {
                return NotFound();
            }

            return View(hospital);
        }

        // GET: Hospital/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hospital/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name,address")] Hospital hospital)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hospital);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hospital);
        }

        // GET: Hospital/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Hospital == null)
            {
                return NotFound();
            }

            var hospital = await _context.Hospital.FindAsync(id);
            if (hospital == null)
            {
                return NotFound();
            }
            return View(hospital);
        }

        // POST: Hospital/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,name,address")] Hospital hospital)
        {
            if (id != hospital.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hospital);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HospitalExists(hospital.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(hospital);
        }

        // GET: Hospital/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Hospital == null)
            {
                return NotFound();
            }

            var hospital = await _context.Hospital
                .FirstOrDefaultAsync(m => m.id == id);
            if (hospital == null)
            {
                return NotFound();
            }

            return View(hospital);
        }

        // POST: Hospital/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Hospital == null)
            {
                return Problem("Entity set 'HospitalesContext.Hospital'  is null.");
            }
            var hospital = await _context.Hospital.FindAsync(id);
            if (hospital != null)
            {
                _context.Hospital.Remove(hospital);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HospitalExists(int id)
        {
          return (_context.Hospital?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
