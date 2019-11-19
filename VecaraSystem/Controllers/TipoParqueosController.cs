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
    public class TipoParqueosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TipoParqueosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TipoParqueos
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoParqueos.ToListAsync());
        }

        // GET: TipoParqueos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoParqueos = await _context.TipoParqueos
                .SingleOrDefaultAsync(m => m.Id == id);
            if (tipoParqueos == null)
            {
                return NotFound();
            }

            return View(tipoParqueos);
        }

        // GET: TipoParqueos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoParqueos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Longitud")] TipoParqueos tipoParqueos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoParqueos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoParqueos);
        }

        // GET: TipoParqueos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoParqueos = await _context.TipoParqueos.SingleOrDefaultAsync(m => m.Id == id);
            if (tipoParqueos == null)
            {
                return NotFound();
            }
            return View(tipoParqueos);
        }

        // POST: TipoParqueos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Longitud")] TipoParqueos tipoParqueos)
        {
            if (id != tipoParqueos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoParqueos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoParqueosExists(tipoParqueos.Id))
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
            return View(tipoParqueos);
        }

        // GET: TipoParqueos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoParqueos = await _context.TipoParqueos
                .SingleOrDefaultAsync(m => m.Id == id);
            if (tipoParqueos == null)
            {
                return NotFound();
            }

            return View(tipoParqueos);
        }

        // POST: TipoParqueos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoParqueos = await _context.TipoParqueos.SingleOrDefaultAsync(m => m.Id == id);
            _context.TipoParqueos.Remove(tipoParqueos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoParqueosExists(int id)
        {
            return _context.TipoParqueos.Any(e => e.Id == id);
        }
    }
}
