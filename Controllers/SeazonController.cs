#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcProject.Models;

namespace MvcProject.Controllers
{
    public class SeazonController : Controller
    {
        private readonly MvcProjectContext _context;

        public SeazonController(MvcProjectContext context)
        {
            _context = context;
        }

        public ActionResult Index(string year)
        {
            ViewBag.YearSearchParm = String.IsNullOrEmpty(year) ? "year" : "";
            var season = from s in _context.Seazon
                    .Include(l => l.League)
                select s;
            if (!String.IsNullOrEmpty(year))
            {
                season = season.Where(s => s.Name.Substring(s.Name.Length - 4).Equals(year));
            }
            switch (year)
            {
                case "year":
                    season = season.Where(s => s.Name.Substring(s.Name.Length - 4).Equals(year));
                    break;
            }
            return View(season.ToList());
        }
        
        public async Task<IActionResult> OrderByLeague()
        {
            var seazons = from s in _context.Seazon
                    .Include(r => r.League)
                orderby s.League.Name ascending
                select s;
            
            return View(seazons);
        }
        
        public async Task<IActionResult> OrderByYear()
        {
            var seazons = from s in _context.Seazon
                    .Include(r => r.League)
                orderby s.Name.Substring(s.Name.Length - 4) descending
                select s;
            
            return View(seazons);
        }

        [HttpPost]
        public ActionResult SezFromYear(string year)
        {
            var seazons = from s in _context.Seazon
                     .Include(r => r.League)
                 select s;
            
             if (!String.IsNullOrEmpty(year))
             {
                 seazons = seazons.Where(s => s.Name.Substring(s.Name.Length - 4).Equals(year));
             }
             
             return PartialView("SezFromYear", seazons.ToList() );            
        }
        
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seazon = await _context.Seazon
                .Include(r => r.League)
                .FirstOrDefaultAsync(m => m.SeazonId == id);
            if (seazon == null)
            {
                return NotFound();
            }

            return View(seazon);
        }
        
        [Authorize(Roles = "Manager, Admin, Developer")]
        public IActionResult Create()
        {
            ViewData["LeagueId"] = new SelectList(_context.League, "LeagueId", "Name");
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SeazonId,Name,LeagueId")] Seazon seazon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(seazon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LeagueId"] = new SelectList(_context.Seazon, "LeagueId", "Name", seazon.LeagueId);
            return View(seazon);
        }
        
        [Authorize(Roles = "Manager, Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seazon = await _context.Seazon.FindAsync(id);
            if (seazon == null)
            {
                return NotFound();
            }
            ViewData["LeagueId"] = new SelectList(_context.League, "LeagueId", "Name", seazon.LeagueId);
            return View(seazon);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SeazonId,Name,LeagueId")] Seazon seazon)
        {
            if (id != seazon.SeazonId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(seazon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SeazonExists(seazon.SeazonId))
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
            ViewData["LeagueId"] = new SelectList(_context.League, "LeagueId", "Name", seazon.LeagueId);
            return View(seazon);
        }
        
        [Authorize(Roles = "Manager, Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seazon = await _context.Seazon
                .Include(r => r.League)
                .FirstOrDefaultAsync(m => m.SeazonId == id);
            if (seazon == null)
            {
                return NotFound();
            }

            return View(seazon);
        }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var seazon = await _context.Seazon.FindAsync(id);
            _context.Seazon.Remove(seazon);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SeazonExists(int id)
        {
            return _context.Seazon.Any(e => e.SeazonId == id);
        }
    }
}
