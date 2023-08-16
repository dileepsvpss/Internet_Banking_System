using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using online_internet_banking.Data;
using online_internet_banking.Models;

namespace online_internet_banking.Controllers
{
    public class ManagersController : Controller
    {
        private readonly online_internet_bankingContext _context;

        public ManagersController(online_internet_bankingContext context)
        {
            _context = context;
        }

        // GET: Managers
        public async Task<IActionResult> Index()
        {
              return _context.Manager != null ? 
                          View(await _context.Manager.ToListAsync()) :
                          Problem("Entity set 'online_internet_bankingContext.Manager'  is null.");
        }

        // GET: Managers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Manager == null)
            {
                return NotFound();
            }

            var manager = await _context.Manager
                .FirstOrDefaultAsync(m => m.BMID == id);
            if (manager == null)
            {
                return NotFound();
            }

            return View(manager);
        }

        // GET: Managers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Managers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BMID,password,branchcode,branchcity")] Manager manager)
        {
            if (ModelState.IsValid)
            {
                _context.Add(manager);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(manager);
        }

        // GET: Managers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Manager == null)
            {
                return NotFound();
            }

            var manager = await _context.Manager.FindAsync(id);
            if (manager == null)
            {
                return NotFound();
            }
            return View(manager);
        }

        // POST: Managers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BMID,password,branchcode,branchcity")] Manager manager)
        {
            if (id != manager.BMID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(manager);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ManagerExists(manager.BMID))
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
            return View(manager);
        }

        // GET: Managers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Manager == null)
            {
                return NotFound();
            }

            var manager = await _context.Manager
                .FirstOrDefaultAsync(m => m.BMID == id);
            if (manager == null)
            {
                return NotFound();
            }

            return View(manager);
        }

        // POST: Managers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Manager == null)
            {
                return Problem("Entity set 'online_internet_bankingContext.Manager'  is null.");
            }
            var manager = await _context.Manager.FindAsync(id);
            if (manager != null)
            {
                _context.Manager.Remove(manager);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ManagerExists(int id)
        {
          return (_context.Manager?.Any(e => e.BMID == id)).GetValueOrDefault();
        }
    }
}
