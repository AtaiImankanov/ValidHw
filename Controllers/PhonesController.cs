using LabAspMvc.Models;
using LabAspMvc.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LabAspMvc.Controllers
{
    public class PhonesController : Controller
    {
        private readonly MobileContext _context;

        public PhonesController(MobileContext context)
        {
            _context = context;
        }

        // GET: Phones
        public async Task<IActionResult> Index()
        {
            var mobileContext = _context.Phones.Include(p => p.Brand).Include(p => p.Categories);
            return View(await mobileContext.ToListAsync());
        }

        // GET: Phones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phone = await _context.Phones
                .Include(p => p.Brand)
                .Include(p => p.Categories)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (phone == null)
            {
                return NotFound();
            }

            return View(phone);
        }

        // GET: Phones/Create
        public IActionResult Create()
        {
           
            var viewModel = new PhonesNCategoriesNBrandsViewModel
            {
                Brands = _context.Brands.ToList(),
                Categories = _context.Categories.ToList()
            };
            ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "Id");
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Id");
            return View(viewModel);
        }

        // POST: Phones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PhonesNCategoriesNBrandsViewModel model)
        {
            
            if (ModelState.IsValid)
            {
                _context.Add(model.Phone);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "Id", model.Phone.BrandId);
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Id", model.Phone.CategoryId);
            return View(model.Phone);
        }

        // GET: Phones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phone = await _context.Phones.FindAsync(id);
            var model = new PhonesNCategoriesNBrandsViewModel
            {
                Phone = phone,
                Brands = _context.Brands.ToList(),
                Categories = _context.Categories.ToList()
            };
            if (phone == null)
            {
                return NotFound();
            }
            ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "Id", phone.BrandId);
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Id", phone.CategoryId);
            return View(model);
        }

        // POST: Phones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PhonesNCategoriesNBrandsViewModel model)
        {
            
            _context.Phones.Update(model.Phone);
            _context.SaveChanges();
            ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "Id", model.Phone.BrandId);
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Id", model.Phone.CategoryId);
            return RedirectToAction("Index");
        }

        // GET: Phones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phone = await _context.Phones
                .Include(p => p.Brand)
                .Include(p => p.Categories)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (phone == null)
            {
                return NotFound();
            }

            return View(phone);
        }

        // POST: Phones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var phone = await _context.Phones.FindAsync(id);
            _context.Phones.Remove(phone);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhoneExists(int id)
        {
            return _context.Phones.Any(e => e.Id == id);
        }
    }
}
