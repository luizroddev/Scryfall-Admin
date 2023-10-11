using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Scryfall_Admin.Data;
using Scryfall_Admin.Models;

namespace Scryfall_Admin.Controllers
{
    public class CartaImagensUrisController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CartaImagensUrisController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CartaImagensUris
        public async Task<IActionResult> Index()
        {
              return _context.ImageUris != null ? 
                          View(await _context.ImageUris.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.ImageUris'  is null.");
        }

        // GET: CartaImagensUris/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ImageUris == null)
            {
                return NotFound();
            }

            var cartaImagensUris = await _context.ImageUris
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cartaImagensUris == null)
            {
                return NotFound();
            }

            return View(cartaImagensUris);
        }

        // GET: CartaImagensUris/Create
        public IActionResult Create()
        {
            return View();
        }

        private void AddErrorsFromModel(ModelStateDictionary.ValueEnumerable values)
        {
            foreach (ModelStateEntry modelState in values)
                foreach (ModelError error in modelState.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.ErrorMessage.ToString());

                }
        }

        // POST: CartaImagensUris/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Small,Normal,Large")] CartaImagensUris cartaImagensUris)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cartaImagensUris);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            } else
            {
                AddErrorsFromModel(ModelState.Values);
                return View(cartaImagensUris);
            }
        }

        // GET: CartaImagensUris/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ImageUris == null)
            {
                return NotFound();
            }

            var cartaImagensUris = await _context.ImageUris.FindAsync(id);
            if (cartaImagensUris == null)
            {
                return NotFound();
            }
            return View(cartaImagensUris);
        }

        // POST: CartaImagensUris/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Small,Normal,Large")] CartaImagensUris cartaImagensUris)
        {
            if (id != cartaImagensUris.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cartaImagensUris);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CartaImagensUrisExists(cartaImagensUris.Id))
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
            return View(cartaImagensUris);
        }

        // GET: CartaImagensUris/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ImageUris == null)
            {
                return NotFound();
            }

            var cartaImagensUris = await _context.ImageUris
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cartaImagensUris == null)
            {
                return NotFound();
            }

            return View(cartaImagensUris);
        }

        // POST: CartaImagensUris/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ImageUris == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ImageUris'  is null.");
            }
            var cartaImagensUris = await _context.ImageUris.FindAsync(id);
            if (cartaImagensUris != null)
            {
                _context.ImageUris.Remove(cartaImagensUris);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public bool CartaImagensUrisExists(int id)
        {
          return (_context.ImageUris?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
