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

        // LISTADO
        public async Task<IActionResult> Index()
        {
            var listado = await _contexto.Medicos
                .Include(m => m.Especialidad)
                .ToListAsync();

            return View(listado);
        }

        // CARGAR ESPECIALIDADES (REUTILIZABLE)
        private async Task CargarEspecialidades()
        {
            ViewBag.IdEspecialidad = new SelectList(
                await _contexto.Especialidades.ToListAsync(),
                "IdEspecialidad",
                "NombreEspecialidad"
            );
        }

        // CREATE GET
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            await CargarEspecialidades();
            return View();
        }

        // CREATE POST
        [HttpPost]
        public async Task<IActionResult> Create(Medico entity)
        {
            if (!ModelState.IsValid)
            {
                await CargarEspecialidades();
                return View(entity);
            }

            _contexto.Medicos.Add(entity);
            await _contexto.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // EDIT GET
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var entity = await _contexto.Medicos.FindAsync(id);

            if (entity == null)
                return RedirectToAction("Error404", "Home");

            await CargarEspecialidades();

            return View(entity);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Medico entity)
        {
            if (!ModelState.IsValid)
            {
                await CargarEspecialidades();
                return View(entity);
            }

            _contexto.Medicos.Update(entity);
            await _contexto.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Read(int id)
        {
            var entity = await _contexto.Medicos
                .Include(m => m.Especialidad)
                .FirstOrDefaultAsync(m => m.IdMedico == id);

            if (entity == null)
                return RedirectToAction("Error404", "Home");

            return View(entity);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _contexto.Medicos
                .Include(m => m.Especialidad)
                .FirstOrDefaultAsync(m => m.IdMedico == id);

            if (entity == null)
                return RedirectToAction("Error404", "Home");

            return View(entity);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> Confirm_Delete(int id)
        {
            var entity = await _contexto.Medicos.FindAsync(id);

            if (entity == null)
                return RedirectToAction("Error404", "Home");

            _contexto.Medicos.Remove(entity);
            await _contexto.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}