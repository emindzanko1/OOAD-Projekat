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
    public class NagradaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NagradaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Nagrada
        public async Task<IActionResult> Index()
        {
            return View(await _context.Nagrada.ToListAsync());
        }

        // GET: Nagrada/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nagrada = await _context.Nagrada
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nagrada == null)
            {
                return NotFound();
            }

            return View(nagrada);
        }

        // GET: Nagrada/Create
        [Authorize(Roles = "Administrator")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Nagrada/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Create([Bind("Id,SlikaNagrade")] Nagrada nagrada)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nagrada);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nagrada);
        }

        // GET: Nagrada/Edit/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nagrada = await _context.Nagrada.FindAsync(id);
            if (nagrada == null)
            {
                return NotFound();
            }
            return View(nagrada);
        }

        // POST: Nagrada/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SlikaNagrade")] Nagrada nagrada)
        {
            if (id != nagrada.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nagrada);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NagradaExists(nagrada.Id))
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
            return View(nagrada);
        }

        // GET: Nagrada/Delete/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nagrada = await _context.Nagrada
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nagrada == null)
            {
                return NotFound();
            }

            return View(nagrada);
        }

        // POST: Nagrada/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nagrada = await _context.Nagrada.FindAsync(id);
            _context.Nagrada.Remove(nagrada);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NagradaExists(int id)
        {
            return _context.Nagrada.Any(e => e.Id == id);
        }
    }
}
