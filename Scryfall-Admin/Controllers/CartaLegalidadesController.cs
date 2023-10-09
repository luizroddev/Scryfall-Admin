using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Scryfall_Admin.Data;
using Scryfall_Admin.Models;

namespace Scryfall_Admin.Controllers
{
    public class CartaLegalidadesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CartaLegalidadesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CartaLegalidades
        public async Task<IActionResult> Index()
        {
              return _context.Legalidades != null ? 
                          View(await _context.Legalidades.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Legalidades'  is null.");
        }

        // GET: CartaLegalidades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Legalidades == null)
            {
                return NotFound();
            }

            var cartaLegalidades = await _context.Legalidades
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cartaLegalidades == null)
            {
                return NotFound();
            }

            return View(cartaLegalidades);
        }

        // GET: CartaLegalidades/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CartaLegalidades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Standard,Modern,Legacy,Pauper,Duel,Predh")] CartaLegalidades cartaLegalidades)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cartaLegalidades);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cartaLegalidades);
        }

        // GET: CartaLegalidades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Legalidades == null)
            {
                return NotFound();
            }

            var cartaLegalidades = await _context.Legalidades.FindAsync(id);
            if (cartaLegalidades == null)
            {
                return NotFound();
            }
            return View(cartaLegalidades);
        }

        // POST: CartaLegalidades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Standard,Modern,Legacy,Pauper,Duel,Predh")] CartaLegalidades cartaLegalidades)
        {
            if (id != cartaLegalidades.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cartaLegalidades);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CartaLegalidadesExists(cartaLegalidades.Id))
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
            return View(cartaLegalidades);
        }

        // GET: CartaLegalidades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Legalidades == null)
            {
                return NotFound();
            }

            var cartaLegalidades = await _context.Legalidades
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cartaLegalidades == null)
            {
                return NotFound();
            }

            return View(cartaLegalidades);
        }

        // POST: CartaLegalidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Legalidades == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Legalidades'  is null.");
            }
            var cartaLegalidades = await _context.Legalidades.FindAsync(id);
            if (cartaLegalidades != null)
            {
                _context.Legalidades.Remove(cartaLegalidades);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CartaLegalidadesExists(int id)
        {
          return (_context.Legalidades?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
