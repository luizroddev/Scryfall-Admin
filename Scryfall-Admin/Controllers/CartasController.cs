using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Scryfall_Admin.Data;
using Scryfall_Admin.Enums;
using Scryfall_Admin.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Scryfall_Admin.Controllers
{
    public class CartasController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMemoryCache _memoryCache;
        public CartasController(ApplicationDbContext context, IMemoryCache memoryCache)
        {
            _context = context;
            _memoryCache = memoryCache;
        }

        // GET: Carta
        public async Task<IActionResult> Index()
        {
            if (!_memoryCache.TryGetValue("cachedCardList", out List<Carta> cachedCardList))
            {
                cachedCardList = await _context.Cartas.Include(c => c.ImagemUris)
                .Include(c => c.Legalidades).ToListAsync();

                _memoryCache.Set("cachedCardList", cachedCardList, TimeSpan.FromMinutes(10));
            }
            return View(cachedCardList);
        }

        // GET: Carta/Details/{id}
        public async Task<IActionResult> Details(int? id)   
        {
            var cacheValue = $"cachedCardDetails_{id}";

            if (id == null || _context.Cartas == null)
            {
                return NotFound();
            }

            if (!_memoryCache.TryGetValue(cacheValue, out Carta carta))
            {
                carta = await _context.Cartas.Include(c => c.ImagemUris)
    .Include(c => c.Legalidades).FirstOrDefaultAsync(m => m.Id == id);

                if (carta != null)
                {
                    _memoryCache.Set(cacheValue, carta, TimeSpan.FromMinutes(10));
                }
            }

            if (carta == null)
            {
                return NotFound();
            }

            return View(carta);
        }

        // GET: Carta/Create
        public IActionResult Create()
        {
            var cacheValue = "createSelectList";

            if (!_memoryCache.TryGetValue(cacheValue, out (IEnumerable<SelectListItem> ImagesList, IEnumerable<SelectListItem> LegalidadeList, IEnumerable<SelectListItem> RaridadeList) selectLists))
            {
                var ImageList = _context.ImageUris.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Id.ToString() }).ToList();
                var LegalidadeList = _context.Legalidades.Select(p => new SelectListItem { Value = p.Id.ToString(), Text = p.Id.ToString() }).ToList();
                var RaridadeList = Enum.GetValues(typeof(CartaRaridade))
                    .Cast<CartaRaridade>()
                    .Select(e => new SelectListItem
                    {
                        Value = ((int)e).ToString(),
                        Text = e.ToString()
                    })
                    .ToList();
                selectLists = (ImageList, LegalidadeList, RaridadeList);
                _memoryCache.Set(cacheValue, selectLists, TimeSpan.FromMinutes(10));
            }
            ViewData["LegalidadesId"] = new SelectList(selectLists.LegalidadeList, "Value", "Text");
            ViewData["ImagemUrisId"] = new SelectList(selectLists.ImagesList, "Value", "Text");
            ViewData["Raridade"] = new SelectList(selectLists.RaridadeList, "Value", "Text");
            return View();
        }

        // POST: Carta/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Mana,CustoDeMana,Tipo,Texto,Poder,Resistencia,Lealdade,FlavorText,Raridade,LegalidadesId,ImagemUrisId")] Carta carta)
        {
            if (ModelState.IsValid)
            {
                carta.ImagemUris = _context.ImageUris.Find(carta.ImagemUrisId);
                carta.Legalidades = _context.Legalidades.Find(carta.LegalidadesId);
                _context.Add(carta);
                await _context.SaveChangesAsync();

                var cacheValue = "createSelectList";

                if (!_memoryCache.TryGetValue(cacheValue, out (IEnumerable<SelectListItem> ImagesList, IEnumerable<SelectListItem> LegalidadeList, IEnumerable<SelectListItem> RaridadeList) selectLists))
                {
                    var ImageList = _context.ImageUris.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Id.ToString() }).ToList();
                    var LegalidadeList = _context.Legalidades.Select(p => new SelectListItem { Value = p.Id.ToString(), Text = p.Id.ToString() }).ToList();
                    var RaridadeList = Enum.GetValues(typeof(CartaRaridade))
                        .Cast<CartaRaridade>()
                        .Select(e => new SelectListItem
                        {
                            Value = ((int)e).ToString(),
                            Text = e.ToString()
                        })
                        .ToList();
                    selectLists = (ImageList, LegalidadeList, RaridadeList);
                    _memoryCache.Set(cacheValue, selectLists, TimeSpan.FromMinutes(10));
                }

                if (_memoryCache.TryGetValue("cachedCardList", out List<Carta> cachedCardList))
                {
                    cachedCardList = await _context.Cartas.Include(c => c.ImagemUris)
                    .Include(c => c.Legalidades).ToListAsync();

                    _memoryCache.Set("cachedCardList", cachedCardList, TimeSpan.FromMinutes(10));
                }

                ViewData["LegalidadesId"] = new SelectList(selectLists.LegalidadeList, "Value", "Text");
                ViewData["ImagemUrisId"] = new SelectList(selectLists.ImagesList, "Value", "Text");
                ViewData["Raridade"] = new SelectList(selectLists.RaridadeList, "Value", "Text");
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(carta);
            }
        }

        // GET: Carta/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carta = await _context.Cartas.FindAsync(id);
            carta.ImagemUris = _context.ImageUris.Find(carta.ImagemUrisId);
            carta.Legalidades = _context.Legalidades.Find(carta.LegalidadesId);
            var ImageList = _context.ImageUris.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Id.ToString() }).ToList();
            var LegalidadeList = _context.Legalidades.Select(p => new SelectListItem { Value = p.Id.ToString(), Text = p.Id.ToString() }).ToList();
            var RaridadeList = Enum.GetValues(typeof(CartaRaridade))
                    .Cast<CartaRaridade>()
                    .Select(e => new SelectListItem
                    {
                        Value = ((int)e).ToString(),
                        Text = e.ToString()
                    })
                    .ToList();
            ViewData["LegalidadesId"] = new SelectList(LegalidadeList, "Value", "Text");
            ViewData["ImagemUrisId"] = new SelectList(ImageList, "Value", "Text");
            ViewData["Raridade"] = new SelectList(RaridadeList, "Value", "Text");
            if (carta == null)
            {
                return NotFound();
            }
            return View(carta);
        }

        // POST: Carta/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Mana,CustoDeMana,Tipo,Texto,Poder,Resistencia,Lealdade,FlavorText,Raridade,LegalidadesId,ImagemUrisId")] Carta carta)
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

                    if (_memoryCache.TryGetValue("cachedCardList", out List<Carta> cachedCardList))
                    {
                        cachedCardList = await _context.Cartas.Include(c => c.ImagemUris)
                        .Include(c => c.Legalidades).ToListAsync();

                        _memoryCache.Set("cachedCardList", cachedCardList, TimeSpan.FromMinutes(10));
                    }
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

            if (_memoryCache.TryGetValue("cachedCardList", out List<Carta> cachedCardList))
            {
                cachedCardList = await _context.Cartas.Include(c => c.ImagemUris)
                .Include(c => c.Legalidades).ToListAsync();

                _memoryCache.Set("cachedCardList", cachedCardList, TimeSpan.FromMinutes(10));
            }
            return RedirectToAction(nameof(Index));
        }

        private bool CartaExists(int id)
        {
            return _context.Cartas.Any(e => e.Id == id);
        }
    }
}