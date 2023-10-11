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
    public class ColecaosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ColecaosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Colecaos
        public async Task<IActionResult> Index()
        {
              return _context.Colecao != null ? 
                          View(await _context.Colecao.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Colecao'  is null.");
        }

        // GET: Colecaos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Colecao == null)
            {
                return NotFound();
            }

            var colecao = await _context.Colecao
                .FirstOrDefaultAsync(m => m.ColecaoId == id);
            if (colecao == null)
            {
                return NotFound();
            }

            return View(colecao);
        }

        // GET: Colecaos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Colecaos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ColecaoId,Nome,Descricao")] Colecao colecao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(colecao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(colecao);
        }

        // GET: Colecaos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Colecao == null)
            {
                return NotFound();
            }

            var colecao = await _context.Colecao.FindAsync(id);
            if (colecao == null)
            {
                return NotFound();
            }
            return View(colecao);
        }

        // POST: Colecaos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ColecaoId,Nome,Descricao")] Colecao colecao)
        {
            if (id != colecao.ColecaoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(colecao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ColecaoExists(colecao.ColecaoId))
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
            return View(colecao);
        }

        // GET: Colecaos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Colecao == null)
            {
                return NotFound();
            }

            var colecao = await _context.Colecao
                .FirstOrDefaultAsync(m => m.ColecaoId == id);
            if (colecao == null)
            {
                return NotFound();
            }

            return View(colecao);
        }

        // POST: Colecaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Colecao == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Colecao'  is null.");
            }
            var colecao = await _context.Colecao.FindAsync(id);
            if (colecao != null)
            {
                _context.Colecao.Remove(colecao);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public bool ColecaoExists(int id)
        {
          return (_context.Colecao?.Any(e => e.ColecaoId == id)).GetValueOrDefault();
        }
    }
}
