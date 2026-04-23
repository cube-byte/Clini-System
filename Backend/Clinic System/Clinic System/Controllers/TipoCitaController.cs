using Clinic_System.Data;
using Clinic_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Clinic_System.Controllers
{
    public class TipoCitaController : Controller
    {
        private readonly AppDbContext _contexto;

        public TipoCitaController(AppDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<IActionResult> Index()
        {
            var listar = await _contexto.TipoCitas
                .Include(m => m.Especialidad)
                .ToListAsync();
            return View(listar);
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
        public async Task<IActionResult> Create(TipoCita entity)
        {
            if (ModelState.IsValid)
            {
                _contexto.TipoCitas.Add(entity);
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
    }
}
