using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hospitals.Data;
using parcial1_hospitales.Models;
using parcial1_hospitales.ViewModels;
using parcial1_hospitales.Services;
using Microsoft.AspNetCore.Authorization;

namespace Hospitals.Controllers
{
    public class DoctorController : Controller
    {

        private IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        // GET: Doctor
        [Authorize]
        public async Task<IActionResult> Index(string? filter, bool? isAvailable)
        {

            var doctors = _doctorService.GetAll(filter, isAvailable);

            var viewModel = new DoctorViewModel();
            viewModel.doctors = doctors;

            return View(viewModel);
        }
        
        // GET: Doctor/Details/5
        [Authorize(Roles = "senior,semisenior,junior")]
        public async Task<IActionResult> Details(int? id)
        {
            var doctor = await _doctorService.GetById(id);
            return View(doctor);
        }

        // GET: Doctor/Create
        [Authorize(Roles = "senior,semisenior")]
        public IActionResult Create()
        {
            ViewData["HospitalId"] = new SelectList(_doctorService.getContext().Hospitals, "Id", "Name");
            return View();
        }

        // POST: Doctor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Age,IsAvailable,Specialty,HospitalId")] Doctor doctor)
        {
            _doctorService.Create(doctor);
            return RedirectToAction(nameof(Index));
        }

        // GET: Doctor/Edit/5
        [Authorize(Roles = "senior,semisenior,junior")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _doctorService.getContext().Doctors == null)
            {
                return NotFound();
            }

            var doctor = await _doctorService.GetById(id);
            if (doctor == null)
            {
                return NotFound();
            }
            ViewData["HospitalId"] = new SelectList(_doctorService.getContext().Hospitals, "Id", "Name", doctor.HospitalId);
            return View(doctor);
        }

        // POST: Doctor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "senior,semisenior,junior")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Age,IsAvailable,Specialty,HospitalId")] Doctor doctor)
        {
            if (id != doctor.Id)
            {
                return NotFound();
            }

            _doctorService.Update(doctor,id);
            return RedirectToAction(nameof(Index));
        }

        // GET: Doctor/Delete/5
        [Authorize(Roles = "senior")]
        public async Task<IActionResult> Delete(int? id)
        {
            var doctor = await _doctorService.GetById(id);
            if (doctor == null)
            {
                return NotFound();
            }

            return View(doctor);
        }

        // POST: Doctor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "senior")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var doctor = await _doctorService.GetById(id);
            if (doctor != null)
            {
                _doctorService.Delete(doctor);
            }
            
            return RedirectToAction(nameof(Index));
        }
    }
}
