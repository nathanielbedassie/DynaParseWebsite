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
    public class GraveGrantsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GraveGrantsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GraveGrants
        public async Task<IActionResult> Index()
        {
            return View(await _context.GraveGrant.ToListAsync());
        }
        // Post: GraveGrants/SearchResults
        public async Task<IActionResult> SearchResults(String SearchPhrase)
        {
            return View("Index", await _context.GraveGrant.Where(k => k.Applicant.Contains(SearchPhrase) || k.Date.Contains(SearchPhrase) || k.Cemetery.Contains(SearchPhrase) || k.Address.Contains(SearchPhrase)).ToListAsync());
        }
        // GET: GraveGrants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var graveGrant = await _context.GraveGrant
                .FirstOrDefaultAsync(m => m.Id == id);
            if (graveGrant == null)
            {
                return NotFound();
            }

            return View(graveGrant);
        }

        // GET: GraveGrants/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GraveGrants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Applicant,Date,Cemetery,No,Address,Receipt")] GraveGrant graveGrant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(graveGrant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(graveGrant);
        }

        // GET: GraveGrants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var graveGrant = await _context.GraveGrant.FindAsync(id);
            if (graveGrant == null)
            {
                return NotFound();
            }
            return View(graveGrant);
        }

        // POST: GraveGrants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Applicant,Date,Cemetery,No,Address,Receipt")] GraveGrant graveGrant)
        {
            if (id != graveGrant.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(graveGrant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GraveGrantExists(graveGrant.Id))
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
            return View(graveGrant);
        }

        // GET: GraveGrants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var graveGrant = await _context.GraveGrant
                .FirstOrDefaultAsync(m => m.Id == id);
            if (graveGrant == null)
            {
                return NotFound();
            }

            return View(graveGrant);
        }

        // POST: GraveGrants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var graveGrant = await _context.GraveGrant.FindAsync(id);
            _context.GraveGrant.Remove(graveGrant);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GraveGrantExists(int id)
        {
            return _context.GraveGrant.Any(e => e.Id == id);
        }
    }
}
