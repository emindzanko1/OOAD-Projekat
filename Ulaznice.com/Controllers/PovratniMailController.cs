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
    public class PovratniMailController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PovratniMailController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PovratniMail
        public async Task<IActionResult> Index()
        {
            return View(await _context.PovratniMail.ToListAsync());
        }

        // GET: PovratniMail/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var povratniMail = await _context.PovratniMail
                .FirstOrDefaultAsync(m => m.Id == id);
            if (povratniMail == null)
            {
                return NotFound();
            }

            return View(povratniMail);
        }

        // GET: PovratniMail/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PovratniMail/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Zahvalnica,PrikazKarte")] PovratniMail povratniMail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(povratniMail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(povratniMail);
        }

        // GET: PovratniMail/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var povratniMail = await _context.PovratniMail.FindAsync(id);
            if (povratniMail == null)
            {
                return NotFound();
            }
            return View(povratniMail);
        }

        // POST: PovratniMail/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Zahvalnica,PrikazKarte")] PovratniMail povratniMail)
        {
            if (id != povratniMail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(povratniMail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PovratniMailExists(povratniMail.Id))
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
            return View(povratniMail);
        }

        // GET: PovratniMail/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var povratniMail = await _context.PovratniMail
                .FirstOrDefaultAsync(m => m.Id == id);
            if (povratniMail == null)
            {
                return NotFound();
            }

            return View(povratniMail);
        }

        // POST: PovratniMail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var povratniMail = await _context.PovratniMail.FindAsync(id);
            _context.PovratniMail.Remove(povratniMail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PovratniMailExists(int id)
        {
            return _context.PovratniMail.Any(e => e.Id == id);
        }
    }
}
