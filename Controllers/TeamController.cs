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
    public class TeamController : Controller
    {
        private readonly MvcProjectContext _context;

        public TeamController(MvcProjectContext context)
        {
            _context = context;
        }

        // GET: League
        public async Task<IActionResult> Index()
        {
            var mvcProjectContext = _context.Team.Include(r => r.Seazon);
            return View(await mvcProjectContext.ToListAsync());
        }
        
        public async Task<IActionResult> OrderBySeason()
        {
            var teams = from t in _context.Team
                    .Include(r => r.Seazon)
                orderby t.Seazon.Name.Substring(t.Seazon.Name.Length - 4), t.Seazon.Name.Substring(0, 2) descending
                select t;
            
            return View(teams);
        }
        
        public async Task<IActionResult> OrderByName()
        {
            var teams = from t in _context.Team
                    .Include(r => r.Seazon)
                orderby t.Name ascending
                select t;
            
            return View(teams);
        }
        
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team = await _context.Team
                .Include(r => r.Seazon)
                .FirstOrDefaultAsync(m => m.TeamId == id);
            if (team == null)
            {
                return NotFound();
            }

            return View(team);
        }
        
        [Authorize(Roles = "Manager, Admin, Developer")]
        public IActionResult Create()
        {
            ViewData["PlayerId"] = new SelectList(_context.Player, "PlayerId", "DataTextFieldLabel");
            ViewData["SeazonId"] = new SelectList(_context.Seazon, "SeazonId", "DataTextFieldLabel");
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TeamId,Name,SeazonId,Classification,TopPlayerId,JungPlayerId,MidPlayerId,AdcPlayerId,SuppPlayerId")] Team team)
        {
            if (ModelState.IsValid)
            {
                _context.Add(team);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SeazonId"] = new SelectList(_context.Seazon, "SeazonId", "DataTextFieldLabel", team.SeazonId);
            ViewData["PlayerId"] = new SelectList(_context.Player, "PlayerId", "DataTextFieldLabel");
            return View(team);
        }
        
        [Authorize(Roles = "Manager, Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team = await _context.Team.FindAsync(id);
            if (team == null)
            {
                return NotFound();
            }
            ViewData["SeazonId"] = new SelectList(_context.Seazon, "SeazonId", "DataTextFieldLabel", team.SeazonId);
            ViewData["PlayerId"] = new SelectList(_context.Player, "PlayerId", "DataTextFieldLabel");
            return View(team);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TeamId,Name,SeazonId,Classification,TopPlayerId,JungPlayerId,MidPlayerId,AdcPlayerId,SuppPlayerId")] Team team)
        {
            if (id != team.TeamId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(team);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeamExists(team.TeamId))
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
            ViewData["SeazonId"] = new SelectList(_context.Seazon, "SeazonId", "DataTextFieldLabel", team.SeazonId);
            ViewData["PlayerId"] = new SelectList(_context.Player, "PlayerId", "DataTextFieldLabel");
            return View(team);
        }
        
        [Authorize(Roles = "Manager, Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team = await _context.Team
                .Include(r => r.Seazon)
                .FirstOrDefaultAsync(m => m.TeamId == id);
            if (team == null)
            {
                return NotFound();
            }

            return View(team);
        }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var team = await _context.Team.FindAsync(id);
            _context.Team.Remove(team);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeamExists(int id)
        {
            return _context.Team.Any(e => e.TeamId == id);
        }
    }
}
