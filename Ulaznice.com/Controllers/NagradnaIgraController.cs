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
    public class NagradnaIgraController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NagradnaIgraController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: NagradnaIgra
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.NagradnaIgra.Include(n => n.Nagrada).Include(n => n.Poruka);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: NagradnaIgra/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nagradnaIgra = await _context.NagradnaIgra
                .Include(n => n.Nagrada)
                .Include(n => n.Poruka)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nagradnaIgra == null)
            {
                return NotFound();
            }

            return View(nagradnaIgra);
        }

        // GET: NagradnaIgra/Create
        [Authorize(Roles = "Administrator")]
        public IActionResult Create()
        {
            ViewData["NagradaId"] = new SelectList(_context.Nagrada, "Id", "Id");
            ViewData["PorukaDobitnikId"] = new SelectList(_context.PorukaDobitnik, "Id", "Id");
            return View();
        }

        // POST: NagradnaIgra/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Create([Bind("Id,OpisNagradneIgre,NagradaId,InformacijeODobitniku,PorukaDobitnikId")] NagradnaIgra nagradnaIgra)
        {
            //if (ModelState.IsValid)
            //{
                _context.Add(nagradnaIgra);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            //}
            //ViewData["NagradaId"] = new SelectList(_context.Nagrada, "Id", "Id", nagradnaIgra.NagradaId);
            //ViewData["PorukaDobitnikId"] = new SelectList(_context.PorukaDobitnik, "Id", "Id", nagradnaIgra.PorukaDobitnikId);
            //return View(nagradnaIgra);
        }

        // GET: NagradnaIgra/Edit/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nagradnaIgra = await _context.NagradnaIgra.FindAsync(id);
            if (nagradnaIgra == null)
            {
                return NotFound();
            }
            ViewData["NagradaId"] = new SelectList(_context.Nagrada, "Id", "Id", nagradnaIgra.NagradaId);
            ViewData["PorukaDobitnikId"] = new SelectList(_context.PorukaDobitnik, "Id", "Id", nagradnaIgra.PorukaDobitnikId);
            return View(nagradnaIgra);
        }

        // POST: NagradnaIgra/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,OpisNagradneIgre,NagradaId,InformacijeODobitniku,PorukaDobitnikId")] NagradnaIgra nagradnaIgra)
        {
            if (id != nagradnaIgra.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nagradnaIgra);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NagradnaIgraExists(nagradnaIgra.Id))
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
            ViewData["NagradaId"] = new SelectList(_context.Nagrada, "Id", "Id", nagradnaIgra.NagradaId);
            ViewData["PorukaDobitnikId"] = new SelectList(_context.PorukaDobitnik, "Id", "Id", nagradnaIgra.PorukaDobitnikId);
            return View(nagradnaIgra);
        }

        // GET: NagradnaIgra/Delete/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nagradnaIgra = await _context.NagradnaIgra
                .Include(n => n.Nagrada)
                .Include(n => n.Poruka)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nagradnaIgra == null)
            {
                return NotFound();
            }

            return View(nagradnaIgra);
        }

        // POST: NagradnaIgra/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nagradnaIgra = await _context.NagradnaIgra.FindAsync(id);
            _context.NagradnaIgra.Remove(nagradnaIgra);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NagradnaIgraExists(int id)
        {
            return _context.NagradnaIgra.Any(e => e.Id == id);
        }
    }
}
