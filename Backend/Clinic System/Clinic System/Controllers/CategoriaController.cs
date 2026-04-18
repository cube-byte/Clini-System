using Clinic_System.Data;
using Clinic_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Clinic_System.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly AppDbContext _contexto;

        public CategoriaController(AppDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _contexto.Categorias.ToListAsync());
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(Categoria entity)
        {
            if (ModelState.IsValid)
            {
                _contexto.Categorias.Add(entity);
                await _contexto.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(entity);
        }

        public async Task<Categoria?> GetID(int id)
            => await _contexto.Categorias.FindAsync(id);

        public async Task<IActionResult> Edit(int id)
        {
            var entity = await GetID(id);
            return entity == null ? RedirectToAction("Error404", "Home") : View(entity);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Categoria entity)
        {
            if (ModelState.IsValid)
            {
                _contexto.Categorias.Update(entity);
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

            _contexto.Categorias.Remove(entity);
            await _contexto.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
