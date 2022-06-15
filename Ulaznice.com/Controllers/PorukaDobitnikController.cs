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
    public class PorukaDobitnikController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PorukaDobitnikController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PorukaDobitnik
        public async Task<IActionResult> Index()
        {
            return View(await _context.PorukaDobitnik.ToListAsync());
        }

        // GET: PorukaDobitnik/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var porukaDobitnik = await _context.PorukaDobitnik
                .FirstOrDefaultAsync(m => m.Id == id);
            if (porukaDobitnik == null)
            {
                return NotFound();
            }

            return View(porukaDobitnik);
        }

        // GET: PorukaDobitnik/Create
        [Authorize(Roles = "Administrator")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: PorukaDobitnik/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Create([Bind("Id,OdabirDobitnika")] PorukaDobitnik porukaDobitnik)
        {
            if (ModelState.IsValid)
            {
                _context.Add(porukaDobitnik);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(porukaDobitnik);
        }

        // GET: PorukaDobitnik/Edit/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var porukaDobitnik = await _context.PorukaDobitnik.FindAsync(id);
            if (porukaDobitnik == null)
            {
                return NotFound();
            }
            return View(porukaDobitnik);
        }

        // POST: PorukaDobitnik/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,OdabirDobitnika")] PorukaDobitnik porukaDobitnik)
        {
            if (id != porukaDobitnik.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(porukaDobitnik);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PorukaDobitnikExists(porukaDobitnik.Id))
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
            return View(porukaDobitnik);
        }

        // GET: PorukaDobitnik/Delete/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var porukaDobitnik = await _context.PorukaDobitnik
                .FirstOrDefaultAsync(m => m.Id == id);
            if (porukaDobitnik == null)
            {
                return NotFound();
            }

            return View(porukaDobitnik);
        }

        // POST: PorukaDobitnik/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var porukaDobitnik = await _context.PorukaDobitnik.FindAsync(id);
            _context.PorukaDobitnik.Remove(porukaDobitnik);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PorukaDobitnikExists(int id)
        {
            return _context.PorukaDobitnik.Any(e => e.Id == id);
        }
    }
}
