using Clinic_System.Data;
using Clinic_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

public class AtencionController : Controller
{
    private readonly AppDbContext _contexto;

    public AtencionController(AppDbContext contexto)
    {
        _contexto = contexto;
    }

    public async Task<IActionResult> Index()
    {
        var listado = await _contexto.Atenciones
            .Include(a => a.Cita)
            .ToListAsync();

        return View(listado);
    }

    public async Task<IActionResult> Create()
    {
        var citasDisponibles = await _contexto.Citas
            .Where(c => !_contexto.Atenciones.Any(a => a.IdCita == c.IdCita))
            .ToListAsync();

        ViewBag.Citas = new SelectList(
            citasDisponibles,
            "IdCita",
            "CodigoCita"
        );

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Atencion entity)
    {
        var yaExiste = await _contexto.Atenciones
            .AnyAsync(a => a.IdCita == entity.IdCita);

        if (yaExiste)
        {
            ModelState.AddModelError("", "Esta cita ya fue atendida.");
        }

        if (ModelState.IsValid)
        {
            _contexto.Atenciones.Add(entity);
            await _contexto.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        var citasDisponibles = await _contexto.Citas
            .Where(c => !_contexto.Atenciones.Any(a => a.IdCita == c.IdCita))
            .ToListAsync();

        ViewBag.Citas = new SelectList(
            citasDisponibles,
            "IdCita",
            "CodigoCita"
        );

        return View(entity);
    }

    public async Task<Atencion?> GetID(int id)
    {
        return await _contexto.Atenciones
            .Include(a => a.Cita)
            .FirstOrDefaultAsync(a => a.IdAtencion == id);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var atencion = await _contexto.Atenciones
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.IdAtencion == id);

        if (atencion == null)
            return RedirectToAction("Error404", "Home");

        ViewBag.IdCita = await _contexto.Citas
            .AsNoTracking()
            .Where(c => !_contexto.Atenciones.Any(a => a.IdCita == c.IdCita)
                        || c.IdCita == atencion.IdCita) // ✅ mantiene la cita actual
            .Select(c => new SelectListItem
            {
                Value = c.IdCita.ToString(),
                Text = c.CodigoCita
            })
            .ToListAsync();

        return View(atencion);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Atencion atencion)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.IdCita = await _contexto.Citas
                .AsNoTracking()
                .Where(c => !_contexto.Atenciones.Any(a => a.IdCita == c.IdCita)
                            || c.IdCita == atencion.IdCita)
                .Select(c => new SelectListItem
                {
                    Value = c.IdCita.ToString(),
                    Text = c.CodigoCita
                })
                .ToListAsync();

            return View(atencion);
        }

        _contexto.Atenciones.Update(atencion);
        await _contexto.SaveChangesAsync();

        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Read(int id)
    {
        var entity = await _contexto.Atenciones
            .Include(a => a.Cita)
            .Include(a => a.Diagnosticos)
            .Include(a => a.Tratamientos)
            .FirstOrDefaultAsync(a => a.IdAtencion == id);

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

        _contexto.Atenciones.Remove(entity);
        await _contexto.SaveChangesAsync();

        return RedirectToAction("Index");
    }
}