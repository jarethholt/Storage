using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Storage.Data;
using Storage.Models;

namespace Storage.Controllers
{
    public class ProductsController(StorageContext context) : Controller
    {
        private readonly StorageContext _context = context;
        private readonly IIncludableQueryable<Product, Category> _products
            = context.Product.Include(c => c.Category);

        // GET: Products
        // Shows all Products currently in the database
        public async Task<IActionResult> Index()
        {
            return View(await _products.ToListAsync());
        }

        // GET: Products/Details/5
        // Show details of the product; retrieve product based on id
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _products
                .FirstOrDefaultAsync(product => product.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        // Initial view of the create page
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        // Actual submission of the Creation request
        public async Task<IActionResult> Create(
            [Bind("ProductId,Name,Price,Orderdate,CategoryId,Category,Shelf,Count,Description")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));  // When successful, return to index
            }
            return View(product);
        }

        // GET: Products/Edit/5
        // Initial view of the edit page
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        // Actual submission of edits for an item
        public async Task<IActionResult> Edit(
            int id,
            [Bind("ProductId,Name,Price,Orderdate,CategoryId,Category,Shelf,Count,Description")] Product product)
        {
            if (id != product.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductId))
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
            return View(product);
        }

        // GET: Products/Delete/5
        // Initial view of delete page
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _products
                .FirstOrDefaultAsync(product => product.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        // Actual deletion of an item
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Product.FindAsync(id);
            if (product != null)
            {
                _context.Product.Remove(product);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // View a total over the entire inventory
        public async Task<IActionResult> Inventory()
        {
            var inventory = _products.Select(
                product => ProductViewModel.FromProduct(product));
            return View(await inventory.ToListAsync());
        }

        public async Task<IActionResult> SearchCategory(string? searchString)
        {
            if (String.IsNullOrWhiteSpace(searchString))
            {
                return View("Index", await _products.ToListAsync());
            }
            var products = _products.Where(
                product => product.Category.Name.Contains(searchString));
            return View("Index", await products.ToListAsync());
        }

        private bool ProductExists(int id)
        {
            return _context.Product.Any(product => product.ProductId == id);
        }
    }
}
