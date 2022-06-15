using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ulaznice.com.Data;
using Ulaznice.com.Models;

namespace Ulaznice.com.Controllers
{
    public class ManifestacijaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ManifestacijaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Manifestacija
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Manifestacija.Include(m => m.Karta).Include(m => m.Lokacija).Include(m => m.NacinPlacanja).Include(m => m.NagradnaIgra).Include(m => m.SlobodnaMjesta);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Manifestacija/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manifestacija = await _context.Manifestacija
                .Include(m => m.Karta)
                .Include(m => m.Lokacija)
                .Include(m => m.NacinPlacanja)
                .Include(m => m.NagradnaIgra)
                .Include(m => m.SlobodnaMjesta)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (manifestacija == null)
            {
                return NotFound();
            }

            return View(manifestacija);
        }

        // GET: Manifestacija/Create
        [Authorize(Roles = "Administrator")]
        public IActionResult Create()
        {
            ViewData["KartaId"] = new SelectList(_context.Karta, "Id", "Id");
            ViewData["LokacijaId"] = new SelectList(_context.Lokacija, "Id", "Id");
            ViewData["NacinPlacanjaId"] = new SelectList(_context.NacinPlacanjata, "Id", "Id");
            ViewData["NagradnaIgraId"] = new SelectList(_context.NagradnaIgra, "Id", "Id");
            ViewData["SlobodnaMjestaId"] = new SelectList(_context.SlobodnaMjesta, "Id", "Id");
            return View();
        }

        // POST: Manifestacija/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Create([Bind("Id,KartaId,OpisKupnjeKarte,NacinPlacanjaId,NagradnaIgraId,Legenda,SlobodnaMjestaId,VrijemeOdržavanja,LokacijaId,Tip")] Manifestacija manifestacija)
        {
            if (ModelState.IsValid)
            {
                _context.Add(manifestacija);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KartaId"] = new SelectList(_context.Karta, "Id", "Id", manifestacija.KartaId);
            ViewData["LokacijaId"] = new SelectList(_context.Lokacija, "Id", "Id", manifestacija.LokacijaId);
            ViewData["NacinPlacanjaId"] = new SelectList(_context.NacinPlacanjata, "Id", "Id", manifestacija.NacinPlacanjaId);
            ViewData["NagradnaIgraId"] = new SelectList(_context.NagradnaIgra, "Id", "Id", manifestacija.NagradnaIgraId);
            ViewData["SlobodnaMjestaId"] = new SelectList(_context.SlobodnaMjesta, "Id", "Id", manifestacija.SlobodnaMjestaId);
            return View(manifestacija);
        }

        // GET: Manifestacija/Edit/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manifestacija = await _context.Manifestacija.FindAsync(id);
            if (manifestacija == null)
            {
                return NotFound();
            }
            ViewData["KartaId"] = new SelectList(_context.Karta, "Id", "Id", manifestacija.KartaId);
            ViewData["LokacijaId"] = new SelectList(_context.Lokacija, "Id", "Id", manifestacija.LokacijaId);
            ViewData["NacinPlacanjaId"] = new SelectList(_context.NacinPlacanjata, "Id", "Id", manifestacija.NacinPlacanjaId);
            ViewData["NagradnaIgraId"] = new SelectList(_context.NagradnaIgra, "Id", "Id", manifestacija.NagradnaIgraId);
            ViewData["SlobodnaMjestaId"] = new SelectList(_context.SlobodnaMjesta, "Id", "Id", manifestacija.SlobodnaMjestaId);
            return View(manifestacija);
        }

        // POST: Manifestacija/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,KartaId,OpisKupnjeKarte,NacinPlacanjaId,NagradnaIgraId,Legenda,SlobodnaMjestaId,VrijemeOdržavanja,LokacijaId,Tip")] Manifestacija manifestacija)
        {
            if (id != manifestacija.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(manifestacija);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ManifestacijaExists(manifestacija.Id))
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
            ViewData["KartaId"] = new SelectList(_context.Karta, "Id", "Id", manifestacija.KartaId);
            ViewData["LokacijaId"] = new SelectList(_context.Lokacija, "Id", "Id", manifestacija.LokacijaId);
            ViewData["NacinPlacanjaId"] = new SelectList(_context.NacinPlacanjata, "Id", "Id", manifestacija.NacinPlacanjaId);
            ViewData["NagradnaIgraId"] = new SelectList(_context.NagradnaIgra, "Id", "Id", manifestacija.NagradnaIgraId);
            ViewData["SlobodnaMjestaId"] = new SelectList(_context.SlobodnaMjesta, "Id", "Id", manifestacija.SlobodnaMjestaId);
            return View(manifestacija);
        }

        // GET: Manifestacija/Delete/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manifestacija = await _context.Manifestacija
                .Include(m => m.Karta)
                .Include(m => m.Lokacija)
                .Include(m => m.NacinPlacanja)
                .Include(m => m.NagradnaIgra)
                .Include(m => m.SlobodnaMjesta)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (manifestacija == null)
            {
                return NotFound();
            }

            return View(manifestacija);
        }

        // POST: Manifestacija/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var manifestacija = await _context.Manifestacija.FindAsync(id);
            _context.Manifestacija.Remove(manifestacija);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ManifestacijaExists(int id)
        {
            return _context.Manifestacija.Any(e => e.Id == id);
        }
    }
}
