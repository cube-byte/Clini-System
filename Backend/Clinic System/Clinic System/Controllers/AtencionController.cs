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
        ViewBag.Citas = new SelectList(
            await _contexto.Citas.ToListAsync(),
            "IdCita",
            "CodigoCita"
        );
        return View();
    }

 
    [HttpPost]
    public async Task<IActionResult> Create(Atencion entity)
    {
        if (ModelState.IsValid)
        {
            _contexto.Atenciones.Add(entity);
            await _contexto.SaveChangesAsync();

            return RedirectToAction("Index");
        }
        ViewBag.Citas = new SelectList(
            await _contexto.Citas.ToListAsync(),
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
        var entity = await GetID(id);

        if (entity == null)
        {
            return RedirectToAction("Error404", "Home");
        }

        ViewBag.Citas = _contexto.Citas.ToList();
        return View(entity);
    }

    
    [HttpPost]
    public async Task<IActionResult> Edit(Atencion entity)
    {
        if (ModelState.IsValid)
        {
            _contexto.Atenciones.Update(entity);
            await _contexto.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        ViewBag.Citas = _contexto.Citas.ToList();
        return View(entity);
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
