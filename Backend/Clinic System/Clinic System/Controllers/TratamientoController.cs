using Clinic_System.Data;
using Clinic_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Clinic_System.Controllers
{
    public class TratamientoController : Controller
    {
        private readonly AppDbContext _contexto;

        public TratamientoController(AppDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _contexto.Tratamientos.Include(t => t.Atencion).ToListAsync());
        }

        public IActionResult Create()
        {
            ViewBag.Atenciones = _contexto.Atenciones.ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Tratamiento entity)
        {
            if (ModelState.IsValid)
            {
                _contexto.Tratamientos.Add(entity);
                await _contexto.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(entity);
        }

        public async Task<Tratamiento?> GetID(int id)
            => await _contexto.Tratamientos.FindAsync(id);

        public async Task<IActionResult> Edit(int id)
        {
            var entity = await GetID(id);
            return entity == null ? RedirectToAction("Error404", "Home") : View(entity);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Tratamiento entity)
        {
            if (ModelState.IsValid)
            {
                _contexto.Tratamientos.Update(entity);
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

            _contexto.Tratamientos.Remove(entity);
            await _contexto.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
