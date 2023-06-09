using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hospitals.Data;
using parcial1_hospitales.Models;
using parcial1_hospitales.Services;
using parcial1_hospitales.ViewModels;

namespace Hospitals.Controllers
{
    public class AppointmentController : Controller
    {

        private IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        // GET: Appointment
        public async Task<IActionResult> Index(string? filter)
        {
            
            var appointments = _appointmentService.GetAll(filter);

            var viewModel = new AppointmentViewModel();
            viewModel.appointments = appointments;

            return View(viewModel);
        }


        // GET: Appointment/Details/5
        public async Task<IActionResult> Details(int? id)
        {

            var appo = await _appointmentService.GetById(id);
            return View(appo);
        }

        // GET: Appointment/Create
        public IActionResult Create()
        {
            ViewData["DoctorId"] = new SelectList(_appointmentService.getContext().Doctors, "Id", "Id");
            ViewData["PatientId"] = new SelectList(_appointmentService.getContext().Patients, "Id", "Id");
            return View();
        }

        // POST: Appointment/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description,DoctorId,PatientId")] Appointment appointment)
        {
            _appointmentService.Create(appointment);
            return RedirectToAction(nameof(Index));
        }

        // GET: Appointment/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _appointmentService.getContext().Appointments == null)
            {
                return NotFound();
            }

            var appointment = await _appointmentService.GetById(id);
            if (appointment == null)
            {
                return NotFound();
            }
            ViewData["DoctorId"] = new SelectList(_appointmentService.getContext().Doctors, "Id", "Id", appointment.DoctorId);
            ViewData["PatientId"] = new SelectList(_appointmentService.getContext().Patients, "Id", "Id", appointment.PatientId);
            return View(appointment);
        }

        // POST: Appointment/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description,DoctorId,PatientId")] Appointment appointment)
        {
            if (id != appointment.Id)
            {
                return NotFound();
            }

            _appointmentService.Update(appointment,id);
            return RedirectToAction(nameof(Index));
            
        }

        // GET: Appointment/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _appointmentService.getContext().Appointments == null)
            {
                return NotFound();
            }

            var appointment = await _appointmentService.GetById(id);

            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        // POST: Appointment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_appointmentService.getContext().Appointments == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Appointments'  is null.");
            }

            var appointment = await _appointmentService.GetById(id);
            if (appointment != null)
            {
                _appointmentService.Delete(appointment);
            }
            
            return RedirectToAction(nameof(Index));
        }

        private bool AppointmentExists(int id)
        {
          return (_appointmentService.getContext().Appointments?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        

        public IActionResult DeleteAllPatientAppointments() {

            ViewData["PatientId"] = new SelectList(_appointmentService.getContext().Patients.Where(a => a.Appointments.Count != 0), "Id", "Name");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteAllPatientAppointments(PatientsDeleteAllApointmentsViewModel model) {
            
            _appointmentService.DeleteAllAppointmentsByPatientId(model.PatientId);
            return RedirectToAction(nameof(Index));
        }
    }
}
