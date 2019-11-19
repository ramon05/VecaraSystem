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
    public class TipoPagosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TipoPagosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TipoPagos
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoPagos.ToListAsync());
        }

        // GET: TipoPagos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoPagos = await _context.TipoPagos
                .SingleOrDefaultAsync(m => m.Id == id);
            if (tipoPagos == null)
            {
                return NotFound();
            }

            return View(tipoPagos);
        }

        // GET: TipoPagos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoPagos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre")] TipoPagos tipoPagos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoPagos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoPagos);
        }

        // GET: TipoPagos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoPagos = await _context.TipoPagos.SingleOrDefaultAsync(m => m.Id == id);
            if (tipoPagos == null)
            {
                return NotFound();
            }
            return View(tipoPagos);
        }

        // POST: TipoPagos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre")] TipoPagos tipoPagos)
        {
            if (id != tipoPagos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoPagos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoPagosExists(tipoPagos.Id))
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
            return View(tipoPagos);
        }

        // GET: TipoPagos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoPagos = await _context.TipoPagos
                .SingleOrDefaultAsync(m => m.Id == id);
            if (tipoPagos == null)
            {
                return NotFound();
            }

            return View(tipoPagos);
        }

        // POST: TipoPagos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoPagos = await _context.TipoPagos.SingleOrDefaultAsync(m => m.Id == id);
            _context.TipoPagos.Remove(tipoPagos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoPagosExists(int id)
        {
            return _context.TipoPagos.Any(e => e.Id == id);
        }
    }
}
