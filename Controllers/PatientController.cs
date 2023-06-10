using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hospitals.Data;
using parcial1_hospitales.Models;
using parcial1_hospitales.Services;
using parcial1_hospitales.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace Hospitals.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        // GET: Patient
        [Authorize]
        public async Task<IActionResult> Index(string? filter)
        {
            var patients = _patientService.GetAll(filter);

            var viewModel = new PatientViewModel();
            viewModel.patients = patients;

            return View(viewModel);
        }

        // GET: Patient/Details/5
        [Authorize(Roles = "senior,semisenior,junior")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _patientService.getContext().Patients == null)
            {
                return NotFound();
            }

            var patient = await _patientService.GetById(id);
            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }

        // GET: Patient/Create
        [Authorize(Roles = "senior,semisenior")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Patient/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "senior,semisenior")]
        public async Task<IActionResult> Create([Bind("Id,Name,Age")] Patient patient)
        {
           
                _patientService.Create(patient);
                return RedirectToAction(nameof(Index));
            
        }

        // GET: Patient/Edit/5
        [Authorize(Roles = "senior,semisenior")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _patientService.getContext().Patients == null)
            {
                return NotFound();
            }

            var patient = await _patientService.GetById(id);
            if (patient == null)
            {
                return NotFound();
            }
            return View(patient);
        }

        // POST: Patient/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "senior,semisenior")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Age")] Patient patient)
        {
            if (id != patient.Id)
            {
                return NotFound();
            }

             _patientService.Update(patient,id);
            return RedirectToAction(nameof(Index));
        }

        // GET: Patient/Delete/5
        [Authorize(Roles = "senior")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _patientService.getContext().Patients == null)
            {
                return NotFound();
            }

            var patient = await _patientService.getContext().Patients
                .FirstOrDefaultAsync(m => m.Id == id);
            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }

        // POST: Patient/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "senior")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_patientService.getContext().Patients == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Patients'  is null.");
            }

            var partient = await _patientService.GetById(id);
            if (partient != null)
            {
                _patientService.Delete(partient);
            }
            
            return RedirectToAction(nameof(Index));
        }

        private bool PatientExists(int id)
        {
          return (_patientService.getContext().Patients?.Any(e => e.Id == id)).GetValueOrDefault();
        }

    }
}
