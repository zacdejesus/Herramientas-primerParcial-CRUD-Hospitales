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
        public async Task<IActionResult> Index(string? filter, bool? isAvailable)
        {

            var queryready = _doctorService.GetAll(filter);

            var viewModel = new DoctorViewModel();
            viewModel.doctors = queryready;

            return View(viewModel);
        }


        // GET: Doctor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var doctor = await _doctorService.GetById(id);
            return View(doctor);
        }

        // GET: Doctor/Create
        public IActionResult Create()
        {
            ViewData["HospitalId"] = new SelectList(_doctorService.getContext().Hospitals, "Id", "Id");
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
            ViewData["HospitalId"] = new SelectList(_doctorService.getContext().Hospitals, "Id", "Id", doctor.HospitalId);
            return View(doctor);
        }

        // POST: Doctor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
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
