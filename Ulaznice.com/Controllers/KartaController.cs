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
    [Authorize(Roles = "Administrator, Korisnik")]
    public class KartaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KartaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Karta
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Karta.Include(k => k.Mail);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Karta/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var karta = await _context.Karta
                .Include(k => k.Mail)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (karta == null)
            {
                return NotFound();
            }

            return View(karta);
        }

        // GET: Karta/Create

        [Authorize(Roles = "Administrator")]
        public IActionResult Create()
        {
            ViewData["PovratniMailId"] = new SelectList(_context.PovratniMail, "Id", "Id");
            return View();
        }

        // POST: Karta/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Create([Bind("Id,MjestoDogađaja,DatumDogađaja,IzvođačiDogađaja,CijenaKarte,OpisDogađaja,PovratniMailId")] Karta karta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(karta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PovratniMailId"] = new SelectList(_context.PovratniMail, "Id", "Id", karta.PovratniMailId);
            return View(karta);
        }

        // GET: Karta/Edit/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var karta = await _context.Karta.FindAsync(id);
            if (karta == null)
            {
                return NotFound();
            }
            ViewData["PovratniMailId"] = new SelectList(_context.PovratniMail, "Id", "Id", karta.PovratniMailId);
            return View(karta);
        }

        // POST: Karta/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MjestoDogađaja,DatumDogađaja,IzvođačiDogađaja,CijenaKarte,OpisDogađaja,PovratniMailId")] Karta karta)
        {
            if (id != karta.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(karta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KartaExists(karta.Id))
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
            ViewData["PovratniMailId"] = new SelectList(_context.PovratniMail, "Id", "Id", karta.PovratniMailId);
            return View(karta);
        }

        // GET: Karta/Delete/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var karta = await _context.Karta
                .Include(k => k.Mail)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (karta == null)
            {
                return NotFound();
            }

            return View(karta);
        }

        // POST: Karta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var karta = await _context.Karta.FindAsync(id);
            _context.Karta.Remove(karta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KartaExists(int id)
        {
            return _context.Karta.Any(e => e.Id == id);
        }
    }
}
