using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Scryfall_Admin.Data;
using Scryfall_Admin.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Scryfall_Admin.Controllers
{
    public class CartasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CartasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Carta
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cartas.Include(c => c.ImageUris)
    .Include(c => c.Legalidades).ToListAsync());
        }

        // GET: Carta/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carta = await _context.Cartas.Include(c => c.ImageUris)
    .Include(c => c.Legalidades).FirstOrDefaultAsync(m => m.Id == id);
            if (carta == null)
            {
                return NotFound();
            }

            return View(carta);
        }

        // GET: Carta/Create
        public IActionResult Create()
        {

            return View();
        }

        // POST: Carta/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Mana,CustoDeMana,Tipo,Texto,Poder,Resistencia,Legalidades,ImageUris,Lealdade,Raridade,FlavorText")] Carta carta)
        {
            if (ModelState.IsValid)
            {
                carta.Legalidades = new Legalidades
                {
                    Standard = carta.Legalidades.Standard,
                    Modern = carta.Legalidades.Modern,
                    Legacy = carta.Legalidades.Legacy,
                    Pauper = carta.Legalidades.Pauper,
                    Duel = carta.Legalidades.Duel,
                    Predh = carta.Legalidades.Predh
                };
                _context.Add(carta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carta);
        }

        // GET: Carta/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carta = await _context.Cartas.FindAsync(id);
            if (carta == null)
            {
                return NotFound();
            }
            return View(carta);
        }

        // POST: Carta/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Mana,CustoDeMana,Tipo,Texto,Poder,Resistencia,Legalidades,ImageUris,Lealdade,Raridade,FlavorText")] Carta carta)
        {
            if (id != carta.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CartaExists(carta.Id))
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
            return View(carta);
        }

        // GET: Carta/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carta = await _context.Cartas.FirstOrDefaultAsync(m => m.Id == id);
            if (carta == null)
            {
                return NotFound();
            }

            return View(carta);
        }

        // POST: Carta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carta = await _context.Cartas.FindAsync(id);
            _context.Cartas.Remove(carta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CartaExists(int id)
        {
            return _context.Cartas.Any(e => e.Id == id);
        }
    }
}