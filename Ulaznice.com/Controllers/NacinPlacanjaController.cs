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
    public class NacinPlacanjaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NacinPlacanjaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: NacinPlacanja
        public async Task<IActionResult> Index()
        {
            return View(await _context.NacinPlacanjata.ToListAsync());
        }

        // GET: NacinPlacanja/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nacinPlacanja = await _context.NacinPlacanjata
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nacinPlacanja == null)
            {
                return NotFound();
            }

            return View(nacinPlacanja);
        }

        // GET: NacinPlacanja/Create
        [Authorize(Roles = "Administrator")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: NacinPlacanja/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Create([Bind("Id,Plaćanje")] NacinPlacanja nacinPlacanja)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nacinPlacanja);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nacinPlacanja);
        }

        // GET: NacinPlacanja/Edit/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nacinPlacanja = await _context.NacinPlacanjata.FindAsync(id);
            if (nacinPlacanja == null)
            {
                return NotFound();
            }
            return View(nacinPlacanja);
        }

        // POST: NacinPlacanja/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Plaćanje")] NacinPlacanja nacinPlacanja)
        {
            if (id != nacinPlacanja.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nacinPlacanja);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NacinPlacanjaExists(nacinPlacanja.Id))
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
            return View(nacinPlacanja);
        }

        // GET: NacinPlacanja/Delete/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nacinPlacanja = await _context.NacinPlacanjata
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nacinPlacanja == null)
            {
                return NotFound();
            }

            return View(nacinPlacanja);
        }

        // POST: NacinPlacanja/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nacinPlacanja = await _context.NacinPlacanjata.FindAsync(id);
            _context.NacinPlacanjata.Remove(nacinPlacanja);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NacinPlacanjaExists(int id)
        {
            return _context.NacinPlacanjata.Any(e => e.Id == id);
        }
    }
}
