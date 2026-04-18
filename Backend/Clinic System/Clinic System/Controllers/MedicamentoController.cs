using Clinic_System.Data;
using Clinic_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Clinic_System.Controllers
{
    public class MedicamentoController : Controller
    {
        private readonly AppDbContext _contexto;

        public MedicamentoController(AppDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _contexto.Medicamentos.Include(m => m.Categoria).ToListAsync());
        }

        public IActionResult Create()
        {
            ViewBag.Categorias = _contexto.Categorias.ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Medicamento entity)
        {
            if (ModelState.IsValid)
            {
                _contexto.Medicamentos.Add(entity);
                await _contexto.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(entity);
        }

        public async Task<Medicamento?> GetID(int id)
            => await _contexto.Medicamentos.FindAsync(id);

        public async Task<IActionResult> Edit(int id)
        {
            var entity = await GetID(id);
            return entity == null ? RedirectToAction("Error404", "Home") : View(entity);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Medicamento entity)
        {
            if (ModelState.IsValid)
            {
                _contexto.Medicamentos.Update(entity);
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

            _contexto.Medicamentos.Remove(entity);
            await _contexto.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
