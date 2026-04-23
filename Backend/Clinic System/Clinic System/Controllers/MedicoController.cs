using Clinic_System.Data;
using Clinic_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Clinic_System.Controllers
{
    public class MedicoController : Controller
    {
        private readonly AppDbContext _contexto;

        public MedicoController(AppDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<IActionResult> Index()
        {
            var listado = await _contexto.Medicos
                .Include(a => a.Especialidad)
                .ToListAsync();
            return View(listado);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Especialidad = new SelectList(
                await _contexto.Especialidades.ToListAsync(),
                "IdEspecialidad",
                "NombreEspecialidad"
            );
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Medico entity)
        {
            if (!ModelState.IsValid)
            {
                var errores = ModelState.Values.SelectMany(v => v.Errors);
            }

            if (ModelState.IsValid)
            {
                _contexto.Medicos.Add(entity);
                await _contexto.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            ViewBag.Especialidad = new SelectList(
                await _contexto.Especialidades.ToListAsync(),
                "IdEspecialidad",
                "NombreEspecialidad"
            );
            return View(entity);
        }

        public async Task<Medico?> GetID(int id)
        {
            return await _contexto.Medicos.FindAsync(id);
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
        public async Task<IActionResult> Edit(Medico entity)
        {
            if (ModelState.IsValid)
            {
                _contexto.Medicos.Update(entity);
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
            _contexto.Medicos.Remove(entity);
            await _contexto.SaveChangesAsync();
            return RedirectToAction("Index");

        }
    }
}
