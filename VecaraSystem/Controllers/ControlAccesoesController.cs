using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VecaraSystem.Data;
using VecaraSystem.Models;

namespace VecaraSystem.Controllers
{
    public class ControlAccesoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ControlAccesoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ControlAccesoes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ControlAcceso.Include(c => c.EmpleadoId).Include(c => c.ParqueoId).Include(c => c.VehiculoId);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ControlAccesoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var controlAcceso = await _context.ControlAcceso
                .Include(c => c.EmpleadoId)
                .Include(c => c.ParqueoId)
                .Include(c => c.VehiculoId)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (controlAcceso == null)
            {
                return NotFound();
            }

            return View(controlAcceso);
        }

        // GET: ControlAccesoes/Create
        public IActionResult Create()
        {
            ViewData["IdEmpleado"] = new SelectList(_context.Empleados, "Id", "Apellido");
            ViewData["IdParqueo"] = new SelectList(_context.Parqueos, "Id", "Disponibilidad");
            ViewData["IdVehiculo"] = new SelectList(_context.Vehiculos, "Id", "Anio");
            return View();
        }

        // POST: ControlAccesoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdEmpleado,IdVehiculo,IdParqueo,FechaEntrada,FechaSalida")] ControlAcceso controlAcceso)
        {
            if (ModelState.IsValid)
            {
                _context.Add(controlAcceso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEmpleado"] = new SelectList(_context.Empleados, "Id", "Apellido", controlAcceso.IdEmpleado);
            ViewData["IdParqueo"] = new SelectList(_context.Parqueos, "Id", "Disponibilidad", controlAcceso.IdParqueo);
            ViewData["IdVehiculo"] = new SelectList(_context.Vehiculos, "Id", "Anio", controlAcceso.IdVehiculo);
            return View(controlAcceso);
        }

        // GET: ControlAccesoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var controlAcceso = await _context.ControlAcceso.SingleOrDefaultAsync(m => m.Id == id);
            if (controlAcceso == null)
            {
                return NotFound();
            }
            ViewData["IdEmpleado"] = new SelectList(_context.Empleados, "Id", "Apellido", controlAcceso.IdEmpleado);
            ViewData["IdParqueo"] = new SelectList(_context.Parqueos, "Id", "Disponibilidad", controlAcceso.IdParqueo);
            ViewData["IdVehiculo"] = new SelectList(_context.Vehiculos, "Id", "Anio", controlAcceso.IdVehiculo);
            return View(controlAcceso);
        }

        // POST: ControlAccesoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdEmpleado,IdVehiculo,IdParqueo,FechaEntrada,FechaSalida")] ControlAcceso controlAcceso)
        {
            if (id != controlAcceso.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(controlAcceso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ControlAccesoExists(controlAcceso.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEmpleado"] = new SelectList(_context.Empleados, "Id", "Apellido", controlAcceso.IdEmpleado);
            ViewData["IdParqueo"] = new SelectList(_context.Parqueos, "Id", "Disponibilidad", controlAcceso.IdParqueo);
            ViewData["IdVehiculo"] = new SelectList(_context.Vehiculos, "Id", "Anio", controlAcceso.IdVehiculo);
            return View(controlAcceso);
        }

        // GET: ControlAccesoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var controlAcceso = await _context.ControlAcceso
                .Include(c => c.EmpleadoId)
                .Include(c => c.ParqueoId)
                .Include(c => c.VehiculoId)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (controlAcceso == null)
            {
                return NotFound();
            }

            return View(controlAcceso);
        }

        // POST: ControlAccesoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var controlAcceso = await _context.ControlAcceso.SingleOrDefaultAsync(m => m.Id == id);
            _context.ControlAcceso.Remove(controlAcceso);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ControlAccesoExists(int id)
        {
            return _context.ControlAcceso.Any(e => e.Id == id);
        }
    }
}
