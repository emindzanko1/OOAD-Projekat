﻿using System;
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
    public class LokacijaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LokacijaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Lokacija
        public async Task<IActionResult> Index()
        {
            return View(await _context.Lokacija.ToListAsync());
        }

        // GET: Lokacija/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lokacija = await _context.Lokacija
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lokacija == null)
            {
                return NotFound();
            }

            return View(lokacija);
        }

        // GET: Lokacija/Create
        [Authorize(Roles = "Administrator")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Lokacijas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Create([Bind("Id,MjestoDogađaja,GeografskaŠirina,GeografskaDužina,OpisMjesta")] Lokacija lokacija)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lokacija);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lokacija);
        }

        // GET: Lokacija/Edit/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lokacija = await _context.Lokacija.FindAsync(id);
            if (lokacija == null)
            {
                return NotFound();
            }
            return View(lokacija);
        }

        // POST: Lokacija/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MjestoDogađaja,GeografskaŠirina,GeografskaDužina,OpisMjesta")] Lokacija lokacija)
        {
            if (id != lokacija.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lokacija);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LokacijaExists(lokacija.Id))
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
            return View(lokacija);
        }

        // GET: Lokacija/Delete/5
        [Authorize(Roles = "Administrator")]

        public async Task<IActionResult> Delete(int? id)
            {
            if (id == null)
            {
                return NotFound();
            }

            var lokacija = await _context.Lokacija
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lokacija == null)
            {
                return NotFound();
            }

            return View(lokacija);
        }

        // POST: Lokacija/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lokacija = await _context.Lokacija.FindAsync(id);
            _context.Lokacija.Remove(lokacija);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LokacijaExists(int id)
        {
            return _context.Lokacija.Any(e => e.Id == id);
        }
    }
}
