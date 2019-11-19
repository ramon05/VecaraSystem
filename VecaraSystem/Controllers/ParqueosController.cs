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
    public class ParqueosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ParqueosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Parqueos
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Parqueos.Include(p => p.TipoParqueoId);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Parqueos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parqueos = await _context.Parqueos
                .Include(p => p.TipoParqueoId)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (parqueos == null)
            {
                return NotFound();
            }

            return View(parqueos);
        }

        // GET: Parqueos/Create
        public IActionResult Create()
        {
            ViewData["IdTipoParqueo"] = new SelectList(_context.TipoParqueos, "Id", "Longitud");
            return View();
        }

        // POST: Parqueos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdTipoParqueo,Disponibilidad")] Parqueos parqueos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(parqueos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdTipoParqueo"] = new SelectList(_context.TipoParqueos, "Id", "Longitud", parqueos.IdTipoParqueo);
            return View(parqueos);
        }

        // GET: Parqueos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parqueos = await _context.Parqueos.SingleOrDefaultAsync(m => m.Id == id);
            if (parqueos == null)
            {
                return NotFound();
            }
            ViewData["IdTipoParqueo"] = new SelectList(_context.TipoParqueos, "Id", "Longitud", parqueos.IdTipoParqueo);
            return View(parqueos);
        }

        // POST: Parqueos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdTipoParqueo,Disponibilidad")] Parqueos parqueos)
        {
            if (id != parqueos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(parqueos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParqueosExists(parqueos.Id))
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
            ViewData["IdTipoParqueo"] = new SelectList(_context.TipoParqueos, "Id", "Longitud", parqueos.IdTipoParqueo);
            return View(parqueos);
        }

        // GET: Parqueos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parqueos = await _context.Parqueos
                .Include(p => p.TipoParqueoId)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (parqueos == null)
            {
                return NotFound();
            }

            return View(parqueos);
        }

        // POST: Parqueos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var parqueos = await _context.Parqueos.SingleOrDefaultAsync(m => m.Id == id);
            _context.Parqueos.Remove(parqueos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParqueosExists(int id)
        {
            return _context.Parqueos.Any(e => e.Id == id);
        }
    }
}
