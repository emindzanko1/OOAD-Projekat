using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ulaznice.com.Data;
using Ulaznice.com.Models;

namespace Ulaznice.com.Controllers
{
    public class SlobodnaMjestaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SlobodnaMjestaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SlobodnaMjesta
        public async Task<IActionResult> Index()
        {
            return View(await _context.SlobodnaMjesta.ToListAsync());
        }

        // GET: SlobodnaMjesta/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slobodnaMjesta = await _context.SlobodnaMjesta
                .FirstOrDefaultAsync(m => m.Id == id);
            if (slobodnaMjesta == null)
            {
                return NotFound();
            }

            return View(slobodnaMjesta);
        }

        // GET: SlobodnaMjesta/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SlobodnaMjesta/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BrojSlobodnihMjesta,BrojMjesta,PrikazMjesta")] SlobodnaMjesta slobodnaMjesta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(slobodnaMjesta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(slobodnaMjesta);
        }

        // GET: SlobodnaMjesta/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slobodnaMjesta = await _context.SlobodnaMjesta.FindAsync(id);
            if (slobodnaMjesta == null)
            {
                return NotFound();
            }
            return View(slobodnaMjesta);
        }

        // POST: SlobodnaMjesta/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BrojSlobodnihMjesta,BrojMjesta,PrikazMjesta")] SlobodnaMjesta slobodnaMjesta)
        {
            if (id != slobodnaMjesta.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(slobodnaMjesta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SlobodnaMjestaExists(slobodnaMjesta.Id))
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
            return View(slobodnaMjesta);
        }

        // GET: SlobodnaMjesta/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slobodnaMjesta = await _context.SlobodnaMjesta
                .FirstOrDefaultAsync(m => m.Id == id);
            if (slobodnaMjesta == null)
            {
                return NotFound();
            }

            return View(slobodnaMjesta);
        }

        // POST: SlobodnaMjesta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var slobodnaMjesta = await _context.SlobodnaMjesta.FindAsync(id);
            _context.SlobodnaMjesta.Remove(slobodnaMjesta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SlobodnaMjestaExists(int id)
        {
            return _context.SlobodnaMjesta.Any(e => e.Id == id);
        }
    }
}
