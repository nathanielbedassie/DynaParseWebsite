using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DynaParseWebsite.Data;
using DynaParseWebsite.Models;

namespace DynaParseWebsite.Controllers
{
    public class CorrespondencesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CorrespondencesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Correspondences
        public async Task<IActionResult> Index()
        {
            return View(await _context.Correspondence.ToListAsync());
        }
        // Post: Correspondences/SearchResults
        public async Task<IActionResult> SearchResults(String SearchPhrase)
        {
            return View("Index", await _context.Correspondence.Where(j => j.Ref.Contains(SearchPhrase) || j.Re.Contains(SearchPhrase) || j.To.Contains(SearchPhrase) || j.Date.Contains(SearchPhrase)).ToListAsync());
        }

        // GET: Correspondences/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var correspondence = await _context.Correspondence
                .FirstOrDefaultAsync(m => m.Id == id);
            if (correspondence == null)
            {
                return NotFound();
            }

            return View(correspondence);
        }

        // GET: Correspondences/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Correspondences/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ref,To,Re,Date")] Correspondence correspondence)
        {
            if (ModelState.IsValid)
            {
                _context.Add(correspondence);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(correspondence);
        }

        // GET: Correspondences/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var correspondence = await _context.Correspondence.FindAsync(id);
            if (correspondence == null)
            {
                return NotFound();
            }
            return View(correspondence);
        }

        // POST: Correspondences/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ref,To,Re,Date")] Correspondence correspondence)
        {
            if (id != correspondence.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(correspondence);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CorrespondenceExists(correspondence.Id))
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
            return View(correspondence);
        }

        // GET: Correspondences/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var correspondence = await _context.Correspondence
                .FirstOrDefaultAsync(m => m.Id == id);
            if (correspondence == null)
            {
                return NotFound();
            }

            return View(correspondence);
        }

        // POST: Correspondences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var correspondence = await _context.Correspondence.FindAsync(id);
            _context.Correspondence.Remove(correspondence);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CorrespondenceExists(int id)
        {
            return _context.Correspondence.Any(e => e.Id == id);
        }
    }
}
