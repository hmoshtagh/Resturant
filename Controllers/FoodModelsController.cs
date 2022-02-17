using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Resturant.Data;
using Resturant.Models;

namespace Resturant.Controllers
{
    public class FoodModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FoodModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FoodModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.FoodModel.ToListAsync());
        }

        // GET: FoodModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodModel = await _context.FoodModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (foodModel == null)
            {
                return NotFound();
            }

            return View(foodModel);
        }

        // GET: FoodModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FoodModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Price")] Food foodModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(foodModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(foodModel);
        }

        // GET: FoodModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodModel = await _context.FoodModel.FindAsync(id);
            if (foodModel == null)
            {
                return NotFound();
            }
            return View(foodModel);
        }

        // POST: FoodModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Price")] Food foodModel)
        {
            if (id != foodModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(foodModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FoodModelExists(foodModel.Id))
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
            return View(foodModel);
        }

        // GET: FoodModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodModel = await _context.FoodModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (foodModel == null)
            {
                return NotFound();
            }

            return View(foodModel);
        }

        // POST: FoodModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var foodModel = await _context.FoodModel.FindAsync(id);
            _context.FoodModel.Remove(foodModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FoodModelExists(int id)
        {
            return _context.FoodModel.Any(e => e.Id == id);
        }
    }
}
