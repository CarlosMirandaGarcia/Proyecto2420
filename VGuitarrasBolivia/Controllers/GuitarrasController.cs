﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VGuitarrasBolivia.Context;
using VGuitarrasBolivia.Models;

namespace VGuitarrasBolivia.Controllers
{
    public class GuitarrasController : Controller
    {
        private readonly MiContext _context;

        public GuitarrasController(MiContext context)
        {
            _context = context;
        }

        // GET: Guitarras
        public async Task<IActionResult> Index()
        {
              return _context.Guitarra != null ? 
                          View(await _context.Guitarra.ToListAsync()) :
                          Problem("Entity set 'MiContext.Guitarra'  is null.");
        }

        // GET: Guitarras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Guitarra == null)
            {
                return NotFound();
            }

            var guitarra = await _context.Guitarra
                .FirstOrDefaultAsync(m => m.Id == id);
            if (guitarra == null)
            {
                return NotFound();
            }

            return View(guitarra);
        }

        // GET: Guitarras/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Guitarras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Modelo,Cuerdas,Precio")] Guitarra guitarra)
        {
            if (ModelState.IsValid)
            {
                _context.Add(guitarra);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(guitarra);
        }

        // GET: Guitarras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Guitarra == null)
            {
                return NotFound();
            }

            var guitarra = await _context.Guitarra.FindAsync(id);
            if (guitarra == null)
            {
                return NotFound();
            }
            return View(guitarra);
        }

        // POST: Guitarras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Modelo,Cuerdas,Precio")] Guitarra guitarra)
        {
            if (id != guitarra.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(guitarra);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GuitarraExists(guitarra.Id))
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
            return View(guitarra);
        }

        // GET: Guitarras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Guitarra == null)
            {
                return NotFound();
            }

            var guitarra = await _context.Guitarra
                .FirstOrDefaultAsync(m => m.Id == id);
            if (guitarra == null)
            {
                return NotFound();
            }

            return View(guitarra);
        }

        // POST: Guitarras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Guitarra == null)
            {
                return Problem("Entity set 'MiContext.Guitarra'  is null.");
            }
            var guitarra = await _context.Guitarra.FindAsync(id);
            if (guitarra != null)
            {
                _context.Guitarra.Remove(guitarra);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GuitarraExists(int id)
        {
          return (_context.Guitarra?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
