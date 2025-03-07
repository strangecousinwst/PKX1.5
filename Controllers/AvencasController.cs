using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PKX.Data;
using PKX.Models;

namespace PKX.Controllers
{
    public class AvencasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AvencasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Avencas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Avencas.ToListAsync());
        }

        // GET: Avencas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var avenca = await _context.Avencas
                .FirstOrDefaultAsync(m => m.id == id);
            if (avenca == null)
            {
                return NotFound();
            }

            return View(avenca);
        }

        // GET: Avencas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Avencas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,clienteid,data,valor")] Avenca avenca)
        {
            if (ModelState.IsValid)
            {
                _context.Add(avenca);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(avenca);
        }

        // GET: Avencas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var avenca = await _context.Avencas.FindAsync(id);
            if (avenca == null)
            {
                return NotFound();
            }
            return View(avenca);
        }

        // POST: Avencas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,clienteid,data,valor")] Avenca avenca)
        {
            if (id != avenca.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(avenca);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AvencaExists(avenca.id))
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
            return View(avenca);
        }

        // GET: Avencas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var avenca = await _context.Avencas
                .FirstOrDefaultAsync(m => m.id == id);
            if (avenca == null)
            {
                return NotFound();
            }

            return View(avenca);
        }

        // POST: Avencas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var avenca = await _context.Avencas.FindAsync(id);
            if (avenca != null)
            {
                _context.Avencas.Remove(avenca);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AvencaExists(int id)
        {
            return _context.Avencas.Any(e => e.id == id);
        }
    }
}
