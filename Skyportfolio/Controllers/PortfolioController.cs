using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Skyportfolio.Data;
using Skyportfolio.Models;

namespace Skyportfolio.Controllers
{
    public class PortfolioController : Controller
    {
        private readonly SkyportfolioContext _context;

        public PortfolioController(SkyportfolioContext context)
        {
            _context = context;
        }

        // GET: Portfolio
        public async Task<IActionResult> Index()
        {
            return View(await _context.Portfolios.ToListAsync());
        }

        public async Task<IActionResult> Front()
        {
            return View();
        }
        // GET: Portfolio/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var portfolio = await _context.Portfolios
                .FirstOrDefaultAsync(m => m.PortfolioID == id);
            if (portfolio == null)
            {
                return NotFound();
            }

            return View(portfolio);
        }

        // GET: Portfolio/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Portfolio/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PortfolioID,Img,Link,Tech,Cmt")] Portfolio portfolio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(portfolio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(portfolio);
        }

        // GET: Portfolio/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var portfolio = await _context.Portfolios.FindAsync(id);
            if (portfolio == null)
            {
                return NotFound();
            }
            return View(portfolio);
        }

        // POST: Portfolio/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PortfolioID,Img,Link,Tech,Cmt")] Portfolio portfolio)
        {
            if (id != portfolio.PortfolioID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(portfolio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PortfolioExists(portfolio.PortfolioID))
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
            return View(portfolio);
        }

        // GET: Portfolio/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var portfolio = await _context.Portfolios
                .FirstOrDefaultAsync(m => m.PortfolioID == id);
            if (portfolio == null)
            {
                return NotFound();
            }

            return View(portfolio);
        }

        // POST: Portfolio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var portfolio = await _context.Portfolios.FindAsync(id);
            _context.Portfolios.Remove(portfolio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PortfolioExists(int id)
        {
            return _context.Portfolios.Any(e => e.PortfolioID == id);
        }
    }
}
