using Clinic_System.Data;
using Clinic_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Clinic_System.Controllers
{
    public class CitaController : Controller
    {
        private readonly AppDbContext _contexto;

        public CitaController(AppDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<IActionResult> Index()
        {
            var listado = await _contexto.Citas
                .Include(c => c.Paciente)
                .Include(c => c.Medico)
                .Include(c => c.TipoCita)
                .ToListAsync();
            return View(listado);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Pacientes = new SelectList(
                await _contexto.Pacientes.ToListAsync(),
                "IdPaciente",
                "DNI"
            );
            ViewBag.Medico = new SelectList(
                await _contexto.Medicos.ToListAsync(),
                "IdMedico",
                "Nombre"
            );
            ViewBag.TipoCita = new SelectList(
                await _contexto.TipoCitas.ToListAsync(),
                "IdTipoCita",
                "NombreTipoCita"
            );
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Cita entity)
        {
            if (ModelState.IsValid)
            {
                _contexto.Citas.Add(entity);
                await _contexto.SaveChangesAsync();

                entity.CodigoCita = "C-" + DateTime.Now.Year + "-" + entity.IdCita.ToString("D3");

                _contexto.Citas.Update(entity);
                await _contexto.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            ViewBag.Pacientes = new SelectList(
                await _contexto.Pacientes.ToListAsync(),
                "IdPaciente",
                "DNI"
            );
            ViewBag.Medico = new SelectList(
                await _contexto.Medicos.ToListAsync(),
                "IdMedico",
                "Nombre"
            );
            ViewBag.TipoCita = new SelectList(
                await _contexto.TipoCitas.ToListAsync(),
                "IdTipoCita",
                "NombreTipoCita"
            );
            return View(entity);
        }

        public async Task<Cita?> GetID(int id)
            => await _contexto.Citas.Include(c => c.Paciente)
               .FirstOrDefaultAsync(c => c.IdCita == id);

        public async Task<IActionResult> Edit(int id)
        {
            var entity = await GetID(id);
            if (entity == null) return RedirectToAction("Error404", "Home");

            ViewBag.Pacientes = _contexto.Pacientes.ToList();
            return View(entity);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Cita entity)
        {
            if (ModelState.IsValid)
            {
                _contexto.Citas.Update(entity);
                await _contexto.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(entity);
        }

        public async Task<IActionResult> Read(int id)
            => View(await GetID(id));

        public async Task<IActionResult> Delete(int id)
            => View(await GetID(id));

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> Confirm_Delete(int id)
        {
            var entity = await GetID(id);
            if (entity == null) return RedirectToAction("Error404", "Home");

            _contexto.Citas.Remove(entity);
            await _contexto.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
