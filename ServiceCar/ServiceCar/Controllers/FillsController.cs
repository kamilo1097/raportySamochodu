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
    public class FillsController : Controller
    {
        private readonly CarServiceContext _context;

        public FillsController(CarServiceContext context)
        {
            _context = context;
        }

        // GET: Fills
        public async Task<IActionResult> Index()
        {
            var carServiceContext = _context.Fills.Include(f => f.Car);
            return View(await carServiceContext.ToListAsync());
        }

        // GET: Fills/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fills = await _context.Fills
                .Include(f => f.Car)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fills == null)
            {
                return NotFound();
            }

            return View(fills);
        }

        // GET: Fills/Create
        public IActionResult Create()
        {
            ViewData["CarId"] = new SelectList(_context.Car, "Id", "Name");
            return View();
        }

        // POST: Fills/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CarId,Kilometers,Cost,Litres")] Fills fills)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fills);
                await _context.SaveChangesAsync();
                return Redirect("/Cars");
            }
            ViewData["CarId"] = new SelectList(_context.Car, "Id", "Name", fills.CarId);
            return View(fills);
        }

        // GET: Fills/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fills = await _context.Fills.FindAsync(id);
            if (fills == null)
            {
                return NotFound();
            }
            ViewData["CarId"] = new SelectList(_context.Car, "Id", "Name", fills.CarId);
            return View(fills);
        }

        // POST: Fills/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CarId,Kilometers,Cost,Litres")] Fills fills)
        {
            if (id != fills.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fills);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FillsExists(fills.Id))
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
            ViewData["CarId"] = new SelectList(_context.Car, "Id", "Name", fills.CarId);
            return View(fills);
        }

        // GET: Fills/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fills = await _context.Fills
                .Include(f => f.Car)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fills == null)
            {
                return NotFound();
            }

            return View(fills);
        }

        // POST: Fills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fills = await _context.Fills.FindAsync(id);
            _context.Fills.Remove(fills);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FillsExists(int id)
        {
            return _context.Fills.Any(e => e.Id == id);
        }
    }
}
