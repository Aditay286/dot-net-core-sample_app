using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using sample_app.Data;
using sample_app.Models;

namespace sample_app.Controllers
{
    public class demo_appController : Controller
    {
        private readonly sampleContext _context;

        public demo_appController(sampleContext context)
        {
            _context = context;
        }

        // GET: demo_app
        public async Task<IActionResult> Index()
        {
            return View(await _context.Movie.ToListAsync());
        }

        // GET: demo_app/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var demo_app = await _context.Movie
                .FirstOrDefaultAsync(m => m.id == id);
            if (demo_app == null)
            {
                return NotFound();
            }

            return View(demo_app);
        }

        // GET: demo_app/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: demo_app/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Title,ReleaseDate,Genre,Price")] demo_app demo_app)
        {
            if (ModelState.IsValid)
            {
                _context.Add(demo_app);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(demo_app);
        }

        // GET: demo_app/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var demo_app = await _context.Movie.FindAsync(id);
            if (demo_app == null)
            {
                return NotFound();
            }
            return View(demo_app);
        }

        // POST: demo_app/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Title,ReleaseDate,Genre,Price")] demo_app demo_app)
        {
            if (id != demo_app.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(demo_app);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!demo_appExists(demo_app.id))
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
            return View(demo_app);
        }

        // GET: demo_app/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var demo_app = await _context.Movie
                .FirstOrDefaultAsync(m => m.id == id);
            if (demo_app == null)
            {
                return NotFound();
            }

            return View(demo_app);
        }

        // POST: demo_app/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var demo_app = await _context.Movie.FindAsync(id);
            _context.Movie.Remove(demo_app);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool demo_appExists(int id)
        {
            return _context.Movie.Any(e => e.id == id);
        }
    }
}
