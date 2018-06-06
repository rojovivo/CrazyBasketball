using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CrazyBasketball.Data;
using CrazyBasketball.Models;

namespace CrazyBasketball.Controllers
{
    public class SeasonController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SeasonController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Season
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Seasons.Include(s => s.Category).Include(s => s.Team);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Season/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var season = await _context.Seasons
                .Include(s => s.Category)
                .Include(s => s.Team)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (season == null)
            {
                return NotFound();
            }

            return View(season);
        }

        // GET: Season/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Set<Category>(), "Id", "Name");
            ViewData["TeamId"] = new SelectList(_context.Teams, "Id", "Name");
            return View();
        }

        // POST: Season/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,InitalYear,FinishYear,CategoryId,TeamId")] Season season)
        {
            if (ModelState.IsValid)
            {
                season.Id = Guid.NewGuid();
                _context.Add(season);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Set<Category>(), "Id", "Name", season.CategoryId);
            ViewData["TeamId"] = new SelectList(_context.Teams, "Id", "Name", season.TeamId);
            return View(season);
        }

        // GET: Season/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var season = await _context.Seasons.FindAsync(id);
            if (season == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Set<Category>(), "Id", "Name", season.CategoryId);
            ViewData["TeamId"] = new SelectList(_context.Teams, "Id", "Name", season.TeamId);
            return View(season);
        }

        // POST: Season/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,InitalYear,FinishYear,CategoryId,TeamId")] Season season)
        {
            if (id != season.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(season);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SeasonExists(season.Id))
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
            ViewData["CategoryId"] = new SelectList(_context.Set<Category>(), "Id", "Name", season.CategoryId);
            ViewData["TeamId"] = new SelectList(_context.Teams, "Id", "Name", season.TeamId);
            return View(season);
        }

        // GET: Season/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var season = await _context.Seasons
                .Include(s => s.Category)
                .Include(s => s.Team)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (season == null)
            {
                return NotFound();
            }

            return View(season);
        }

        // POST: Season/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var season = await _context.Seasons.FindAsync(id);
            _context.Seasons.Remove(season);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SeasonExists(Guid id)
        {
            return _context.Seasons.Any(e => e.Id == id);
        }
    }
}
