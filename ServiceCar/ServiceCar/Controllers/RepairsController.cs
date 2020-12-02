using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ServiceCar.Data;
using ServiceCar.Models;

namespace ServiceCar.Controllers
{
    public class RepairsController : Controller
    {
        private readonly CarServiceContext _context;

        public RepairsController(CarServiceContext context)
        {
            _context = context;
        }

        // GET: Repairs
        public async Task<IActionResult> Index()
        {
            var carServiceContext = _context.Repairs.Include(r => r.Car);
            return View(await carServiceContext.ToListAsync());
        }

        // GET: Repairs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var repairs = await _context.Repairs
                .Include(r => r.Car)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (repairs == null)
            {
                return NotFound();
            }

            return View(repairs);
        }

        // GET: Repairs/Create
        public IActionResult Create()
        {
            ViewData["CarId"] = new SelectList(_context.Car, "Id", "Name");
            return View();
        }

        // POST: Repairs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CarId,Kilometers,Cost,WhatFixed,WhenFixed")] Repairs repairs)
        {
            if (ModelState.IsValid)
            {
                _context.Add(repairs);
                await _context.SaveChangesAsync();
                return Redirect("/Cars");
            }
            ViewData["CarId"] = new SelectList(_context.Car, "Id", "Name", repairs.CarId);
            return View(repairs);
        }

        // GET: Repairs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var repairs = await _context.Repairs.FindAsync(id);
            if (repairs == null)
            {
                return NotFound();
            }
            ViewData["CarId"] = new SelectList(_context.Car, "Id", "Name", repairs.CarId);
            return View(repairs);
        }

        // POST: Repairs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CarId,Kilometers,Cost,WhatFixed,WhenFixed")] Repairs repairs)
        {
            if (id != repairs.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(repairs);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RepairsExists(repairs.Id))
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
            ViewData["CarId"] = new SelectList(_context.Car, "Id", "Name", repairs.CarId);
            return View(repairs);
        }

        // GET: Repairs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var repairs = await _context.Repairs
                .Include(r => r.Car)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (repairs == null)
            {
                return NotFound();
            }

            return View(repairs);
        }

        // POST: Repairs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var repairs = await _context.Repairs.FindAsync(id);
            _context.Repairs.Remove(repairs);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RepairsExists(int id)
        {
            return _context.Repairs.Any(e => e.Id == id);
        }
    }
}
