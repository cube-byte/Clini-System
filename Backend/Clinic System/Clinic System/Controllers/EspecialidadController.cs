using Clinic_System.Data;
using Clinic_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Clinic_System.Controllers
{
    public class EspecialidadController : Controller
    {
        private readonly AppDbContext _contexto;

        public EspecialidadController(AppDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<IActionResult> Index()
        {
            var listado = await _contexto.Especialidades.ToListAsync();
            return View(listado);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(Especialidad entity)
        {
            if (ModelState.IsValid)
            {
                _contexto.Especialidades.Add(entity);
                await _contexto.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(entity);
        }
        public async Task<Especialidad?> GetID(int id)
            => await _contexto.Especialidades.FindAsync(id);
        public async Task<IActionResult> Edit(int id)
        {
            var entity = await GetID(id);
            return entity == null ? RedirectToAction("Error404", "Home") : View(entity);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Especialidad entity)
        {
            if (ModelState.IsValid)
            {
                _contexto.Especialidades.Update(entity);
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

            _contexto.Especialidades.Remove(entity);
            await _contexto.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
