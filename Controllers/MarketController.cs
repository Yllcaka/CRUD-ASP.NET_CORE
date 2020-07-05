using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SQLitePCL;
using VisionMVC.Data;
using VisionMVC.Models;

namespace VisionMVC.Controllers
{
    public class MarketController : Controller
    {
        private readonly MarketContext _context;
        public bool Show = true;
        public MarketController(MarketContext context) {
            _context = context;
        
        }
        public async Task<IActionResult> Index(string productType, string searchString)
        {

              IQueryable<string> typeQuery = _context.Product
                .OrderBy(p => p.Type)
                .Select(p => p.Type);

            var products = from p in _context.Product
                           select p;
            if (!string.IsNullOrEmpty(searchString))
            {
                products = products.Where(s => s.Name.Contains(searchString));
            }
            if (!string.IsNullOrEmpty(productType))
            {
                products = products.Where(p => p.Type == productType);
            }

            var productSearchVM = new ProductSearch
            {
                Types = new SelectList(await typeQuery.Distinct()
                                .ToListAsync()
                ),
                Products = await products.ToListAsync()
            };

            return View(productSearchVM);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Type,Amount,Price,AddedOn")] Product product) {
            if (ModelState.IsValid) {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            var products = from p in _context.Product
                           select p;
            var productSearchVM = new ProductSearch
            {
                Types = new SelectList(await products.Distinct()
                                .ToListAsync()
                ),
                Products = await products.ToListAsync()
            };

            return View(nameof(Index), productSearchVM);
        }

        public IActionResult Edit(int? id) { 
            if (id == null) {
                return NotFound();
            }
            var product = _context.Product.FirstOrDefault(p => p.Id == id);
            if (product == null) {
                return NotFound();
            }
            return View(product);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Type,Amount,Price,AddedOn")] Product product) { 
            
            if(product.Id != id) {
                return NotFound();
            }
            if (ModelState.IsValid) {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                    
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductInStock(id)) return NotFound();
                    else throw;
                }
            }
            return View();

        }

        public async Task<IActionResult> Delete(int?id) {
            var movie = await _context.Product.FindAsync(id);
            _context.Product.Remove(movie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        
        }
        private bool ProductInStock(int id) {
            return _context.Product.Any(d => d.Id == id);
        }
    }
}
