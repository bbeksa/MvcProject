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
    public class LeagueController : Controller
    {
        private readonly MvcProjectContext _context;

        public LeagueController(MvcProjectContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var query = from lague in _context.League
                select lague;
            var leagues = query.ToList();
            return View(leagues);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var league = await _context.League
                .FirstOrDefaultAsync(m => m.LeagueId == id);
            if (league == null)
            {
                return NotFound();
            }

            return View(league);
        }

        [Authorize(Roles = "Manager, Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LeagueId,Name,Localization")] League league)
        {
            if (ModelState.IsValid)
            {
                _context.Add(league);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(league);
        }

        [Authorize(Roles = "Manager, Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var league = await _context.League.FindAsync(id);
            if (league == null)
            {
                return NotFound();
            }

            return View(league);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LeagueId,Name,Localization")] League league)
        {
            if (id != league.LeagueId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(league);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeagueExists(league.LeagueId))
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

            return View(league);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var league = await _context.League
                .FirstOrDefaultAsync(m => m.LeagueId == id);
            if (league == null)
            {
                return NotFound();
            }

            return View(league);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var league = await _context.League.FindAsync(id);
            _context.League.Remove(league);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LeagueExists(int id)
        {
            return _context.League.Any(e => e.LeagueId == id);
        }
        
        [HttpPost]
        public PartialViewResult AddPartialToView(int id)
        {
            var season = from s in _context.Seazon
                    .Include(l => l.League)
                select s;
            if (id != null)
            {
                season = season.Where(s => s.LeagueId == id )
                    .OrderByDescending(s => s.Name.Substring(s.Name.Length - 4));
            }

            return PartialView(season.ToList());
        }
    }
}

