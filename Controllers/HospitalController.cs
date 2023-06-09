using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hospitals.Data;
using parcial1_hospitales.Models;
using parcial1_hospitales.ViewModels;
using parcial1_hospitales.Services;

namespace Hospitals.Controllers
{
    public class HospitalController : Controller
    {

        private IHospitalService _hostpitalService;

        public HospitalController(IHospitalService hospitalService)
        {
            _hostpitalService = hospitalService;
        }

        // GET: Hospital
        public async Task<IActionResult> Index(string? filter)
        {
            var queryready = _hostpitalService.GetAll(filter);
            
            var viewModel = new HospitalViewModel();
            viewModel.hospitals = queryready;

            return View(viewModel);
        }

        // GET: Hospital/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var hospital = _hostpitalService.GetById(id);
            return View(await hospital);
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
        public async Task<IActionResult> Create([Bind("Id,Name,Address")] Hospital hospital)
        {
            if (ModelState.IsValid)
            {
                _hostpitalService.Create(hospital);
                return RedirectToAction(nameof(Index));
            }
            return View(hospital);
        }

        // GET: Hospital/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var hospital = await _hostpitalService.GetById(id);
     
            return View(hospital);
        }

        // POST: Hospital/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Address")] Hospital hospital)
        {
            if (id != hospital.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _hostpitalService.Update(hospital,id);
                return RedirectToAction(nameof(Index));
            }
            
            return View(hospital);
        }

        // GET: Hospital/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {

            var hospital = await _hostpitalService.GetById(id);
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
            var hospital = await _hostpitalService.GetById(id);
            if (hospital != null)
            {
                _hostpitalService.Delete(hospital);
            }
            
            return RedirectToAction(nameof(Index));
        }
    }
}
