
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

using Resturant.Data;
using Resturant.Models;

using Newtonsoft.Json.Linq;
using System.Text.Json;

namespace Resturant.Controllers
{
    [ApiController]
    [Route("API/")]
    public class FoodsControllerAPI : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FoodsControllerAPI(ApplicationDbContext context)
        {
            _context = context;
        }
        
                // GET: Foods
                [HttpGet]
                public List<Food> Index()
                {
                    List<Food> list = _context.FoodModel.ToList();
                    return list ;

                }
                [HttpGet("Details/{id}")]
                public Food Details(int? id)
                {
                    if (id == null) { 

                        return null;
                    }
                    var food = _context.FoodModel
                        .FirstOrDefault(m => m.Id == id);
                    if (food == null)
                    {
                        return null;
                    }

                    return food;
                }

        /*
                [HttpGet("searchFood/{searchTerm}")]
                public Food SearchFood(string searchTerm) { 
                    var food =_context.FoodModel 
                    .Where(f => f.Name.Contains(searchTerm))
                    .ToList();

                    return food[0];
                }

        /*

                [HttpPost("Create/{j}")]

                public void Create(JObject json)
                {

                    _context.FoodModel.Add(Food(json[JPropertyDes],json[JPropertyDescriptor]
                public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Price,PhotoLocation")] Food food)
                {
                    if (id != food.Id)
                    {
                        return NotFound();
                    }

                    if (ModelState.IsValid)
                    {
                        try
                        {
                            _context.Update(food);
                            await _context.SaveChangesAsync();
                        }
                        catch (DbUpdateConcurrencyException)
                        {
                            if (!FoodExists(food.Id))
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
                    return View(food);
                }

                // GET: Foods/Delete/5
                public async Task<IActionResult> Delete(int? id)
                {
                    if (id == null)
                    {
                        return NotFound();
                    }

                    var food = await _context.FoodModel
                        .FirstOrDefaultAsync(m => m.Id == id);
                    if (food == null)
                    {
                        return NotFound();
                    }

                    return View(food);
                }

                // POST: Foods/Delete/5
                [HttpPost, ActionName("Delete")]
                [ValidateAntiForgeryToken]
                public async Task<IActionResult> DeleteConfirmed(int id)
                {
                    var food = await _context.FoodModel.FindAsync(id);
                    _context.FoodModel.Remove(food);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }

                private bool FoodExists(int id)
                {
                    return _context.FoodModel.Any(e => e.Id == id);
               
    }*/
    }
}
