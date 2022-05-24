using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CuaHangTheThao.Data;
using CuaHangTheThao.Models;

namespace CuaHangTheThao.Controllers
{
    public class DoTheThaosController : Controller
    {
        private readonly CuaHangTheThaoContext _context;

        public DoTheThaosController(CuaHangTheThaoContext context)
        {
            _context = context;
        }

        // GET: DoTheThaos
        public async Task<IActionResult> Index(string DoTheThaoGenre, string searchString)
        {
            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from b in _context.DoTheThao
                                            orderby b.Genre
                                            select b.Genre;
            var DoTheThaos = from b in _context.DoTheThao
                        select b;
            if (!string.IsNullOrEmpty(searchString))
            {
                DoTheThaos = DoTheThaos.Where(s => s.Title!.Contains(searchString));
            }
            if (!string.IsNullOrEmpty(DoTheThaoGenre))
            {
                DoTheThaos = DoTheThaos.Where(x => x.Genre == DoTheThaoGenre);
            }
            var DoTheThaoGenreVM = new DothethaoGenreViewModel
            {
                Genres = new SelectList(await
           genreQuery.Distinct().ToListAsync()),
                DoTheThaos = await DoTheThaos.ToListAsync()
            };
            return View(DoTheThaoGenreVM);
        }

        // GET: DoTheThaos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doTheThao = await _context.DoTheThao
                .FirstOrDefaultAsync(m => m.Id == id);
            if (doTheThao == null)
            {
                return NotFound();
            }

            return View(doTheThao);
        }

        // GET: DoTheThaos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DoTheThaos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ReleaseDate,Genre,Price,Rating")] DoTheThao doTheThao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(doTheThao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(doTheThao);
        }

        // GET: DoTheThaos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doTheThao = await _context.DoTheThao.FindAsync(id);
            if (doTheThao == null)
            {
                return NotFound();
            }
            return View(doTheThao);
        }

        // POST: DoTheThaos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseDate,Genre,Price,Rating")] DoTheThao doTheThao)
        {
            if (id != doTheThao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doTheThao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoTheThaoExists(doTheThao.Id))
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
            return View(doTheThao);
        }

        // GET: DoTheThaos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doTheThao = await _context.DoTheThao
                .FirstOrDefaultAsync(m => m.Id == id);
            if (doTheThao == null)
            {
                return NotFound();
            }

            return View(doTheThao);
        }

        // POST: DoTheThaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var doTheThao = await _context.DoTheThao.FindAsync(id);
            _context.DoTheThao.Remove(doTheThao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DoTheThaoExists(int id)
        {
            return _context.DoTheThao.Any(e => e.Id == id);
        }
    }
}
