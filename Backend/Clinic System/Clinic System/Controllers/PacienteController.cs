using System.Diagnostics;
using System.Diagnostics.Metrics;
using Clinic_System.Data;
using Clinic_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Clinic_System.Controllers
{
    public class PacienteController : Controller
    {
        private readonly AppDbContext _contexto;

        public PacienteController(AppDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<IActionResult> Index()
        {
            var listado = await _contexto.Pacientes.ToListAsync();
            return View(listado);
        }

        public async Task<IActionResult> Create()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Paciente entity)
        {
            if (!ModelState.IsValid)
            {
                var errores = ModelState.Values.SelectMany(v => v.Errors);
            }

            if (ModelState.IsValid)
            {
                _contexto.Pacientes.Add(entity);
                await _contexto.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View(entity);
        }

        public async Task<Paciente?> GetID(int id)
        {
            return await _contexto.Pacientes.FindAsync(id);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var entity = await GetID(id);
            if (entity == null)
            {
                return RedirectToAction("Error404", "Home");
            }

            return View(entity);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Paciente entity)
        {
            if (ModelState.IsValid)
            {
                _contexto.Pacientes.Update(entity);
                await _contexto.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(entity);
        }

        public async Task<IActionResult> Read(int id)
        {
            var entity = await GetID(id);
            return View(entity);
        }

        public async Task<IActionResult> Delete(int id)
        {

            var entity = await GetID(id);
            return View(entity);

        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> Confirm_Delete(int id)
        {
            var entity = await GetID(id);
            if (entity == null)
            {
                return RedirectToAction("Error404", "Home");
            }
            _contexto.Pacientes.Remove(entity);
            await _contexto.SaveChangesAsync();
            return RedirectToAction("Index");

        }
    }
}
