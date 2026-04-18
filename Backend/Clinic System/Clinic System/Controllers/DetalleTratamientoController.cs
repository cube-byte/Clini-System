using Clinic_System.Data;
using Clinic_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Clinic_System.Controllers
{
    public class DetalleTratamientoController : Controller
    {
        private readonly AppDbContext _contexto;

        public DetalleTratamientoController(AppDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<IActionResult> Index()
        {
            var listado = await _contexto.DetalleTratamientos
                .Include(d => d.Tratamiento)
                .Include(d => d.Medicamento)
                .ToListAsync();
            return View(listado);
        }

        public IActionResult Create()
        {
            ViewBag.Tratamientos = _contexto.Tratamientos.ToList();
            ViewBag.Medicamentos = _contexto.Medicamentos.ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(DetalleTratamiento entity)
        {
            if (ModelState.IsValid)
            {
                _contexto.DetalleTratamientos.Add(entity);
                await _contexto.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(entity);
        }

        public async Task<DetalleTratamiento?> GetID(int id)
            => await _contexto.DetalleTratamientos.FindAsync(id);

        public async Task<IActionResult> Edit(int id)
        {
            var entity = await GetID(id);
            if (entity == null) return RedirectToAction("Error404", "Home");

            ViewBag.Tratamientos = _contexto.Tratamientos.ToList();
            ViewBag.Medicamentos = _contexto.Medicamentos.ToList();
            return View(entity);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(DetalleTratamiento entity)
        {
            if (ModelState.IsValid)
            {
                _contexto.DetalleTratamientos.Update(entity);
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

            _contexto.DetalleTratamientos.Remove(entity);
            await _contexto.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
