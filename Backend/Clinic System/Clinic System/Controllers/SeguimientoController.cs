using Clinic_System.Data;
using Clinic_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Clinic_System.Controllers
{
    public class SeguimientoController : Controller
    {
        private readonly AppDbContext _contexto;

        public SeguimientoController(AppDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _contexto.Seguimientos.Include(s => s.Tratamiento).ToListAsync());
        }

        public IActionResult Create()
        {
            ViewBag.Tratamientos = _contexto.Tratamientos.ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Seguimiento entity)
        {
            if (ModelState.IsValid)
            {
                _contexto.Seguimientos.Add(entity);
                await _contexto.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(entity);
        }

        public async Task<Seguimiento?> GetID(int id)
            => await _contexto.Seguimientos.FindAsync(id);

        public async Task<IActionResult> Edit(int id)
        {
            var entity = await GetID(id);
            return entity == null ? RedirectToAction("Error404", "Home") : View(entity);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Seguimiento entity)
        {
            if (ModelState.IsValid)
            {
                _contexto.Seguimientos.Update(entity);
                await _contexto.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(entity);
        }

        public async Task<IActionResult> Delete(int id)
            => View(await GetID(id));

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> Confirm_Delete(int id)
        {
            var entity = await GetID(id);
            if (entity == null) return RedirectToAction("Error404", "Home");

            _contexto.Seguimientos.Remove(entity);
            await _contexto.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
