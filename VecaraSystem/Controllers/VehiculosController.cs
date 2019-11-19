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
    public class VehiculosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VehiculosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Vehiculos
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Vehiculos.Include(v => v.ClienteId).Include(v => v.ModeloId);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Vehiculos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehiculos = await _context.Vehiculos
                .Include(v => v.ClienteId)
                .Include(v => v.ModeloId)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (vehiculos == null)
            {
                return NotFound();
            }

            return View(vehiculos);
        }

        // GET: Vehiculos/Create
        public IActionResult Create()
        {
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "Id", "Apellido");
            ViewData["IdModelo"] = new SelectList(_context.Modelos, "Id", "Nombre");
            return View();
        }

        // POST: Vehiculos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdCliente,IdModelo,Anio,Placa")] Vehiculos vehiculos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehiculos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "Id", "Apellido", vehiculos.IdCliente);
            ViewData["IdModelo"] = new SelectList(_context.Modelos, "Id", "Nombre", vehiculos.IdModelo);
            return View(vehiculos);
        }

        // GET: Vehiculos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehiculos = await _context.Vehiculos.SingleOrDefaultAsync(m => m.Id == id);
            if (vehiculos == null)
            {
                return NotFound();
            }
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "Id", "Apellido", vehiculos.IdCliente);
            ViewData["IdModelo"] = new SelectList(_context.Modelos, "Id", "Nombre", vehiculos.IdModelo);
            return View(vehiculos);
        }

        // POST: Vehiculos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdCliente,IdModelo,Anio,Placa")] Vehiculos vehiculos)
        {
            if (id != vehiculos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehiculos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehiculosExists(vehiculos.Id))
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
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "Id", "Apellido", vehiculos.IdCliente);
            ViewData["IdModelo"] = new SelectList(_context.Modelos, "Id", "Nombre", vehiculos.IdModelo);
            return View(vehiculos);
        }

        // GET: Vehiculos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehiculos = await _context.Vehiculos
                .Include(v => v.ClienteId)
                .Include(v => v.ModeloId)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (vehiculos == null)
            {
                return NotFound();
            }

            return View(vehiculos);
        }

        // POST: Vehiculos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vehiculos = await _context.Vehiculos.SingleOrDefaultAsync(m => m.Id == id);
            _context.Vehiculos.Remove(vehiculos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehiculosExists(int id)
        {
            return _context.Vehiculos.Any(e => e.Id == id);
        }
    }
}
