using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1_scaffoldViewsTest.Data;
using WebApplication1_scaffoldViewsTest.Models;

namespace WebApplication1_scaffoldViewsTest.Controllers
{
    public class TestClassesController : Controller
    {
        private readonly WebApplication1_scaffoldViewsTestContext _context;

        public TestClassesController(WebApplication1_scaffoldViewsTestContext context)
        {
            _context = context;
        }

        // GET: TestClasses
        public async Task<IActionResult> Index()
        {
            return _context.TestClass != null ?
                        View(await _context.TestClass.ToListAsync()) :
                        Problem("Entity set 'WebApplication1_scaffoldViewsTestContext.TestClass'  is null.");
        }

        // GET: TestClasses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TestClass == null)
            {
                return NotFound();
            }

            var testClass = await _context.TestClass
                .FirstOrDefaultAsync(m => m.Id == id);
            if (testClass == null)
            {
                return NotFound();
            }

            return View(testClass);
        }

        // GET: TestClasses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TestClasses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] TestClass testClass)
        {
            if (ModelState.IsValid)
            {
                _context.Add(testClass);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(testClass);
        }

        // GET: TestClasses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TestClass == null)
            {
                return NotFound();
            }

            var testClass = await _context.TestClass.FindAsync(id);
            if (testClass == null)
            {
                return NotFound();
            }
            return View(testClass);
        }

        // POST: TestClasses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] TestClass testClass)
        {
            if (id != testClass.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(testClass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TestClassExists(testClass.Id))
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
            return View(testClass);
        }

        // GET: TestClasses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TestClass == null)
            {
                return NotFound();
            }

            var testClass = await _context.TestClass
                .FirstOrDefaultAsync(m => m.Id == id);
            if (testClass == null)
            {
                return NotFound();
            }

            return View(testClass);
        }

        // POST: TestClasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TestClass == null)
            {
                return Problem("Entity set 'WebApplication1_scaffoldViewsTestContext.TestClass'  is null.");
            }
            var testClass = await _context.TestClass.FindAsync(id);
            if (testClass != null)
            {
                _context.TestClass.Remove(testClass);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TestClassExists(int id)
        {
            return (_context.TestClass?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
