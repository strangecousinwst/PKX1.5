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
    public class TemposController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TemposController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Tempos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tempos.ToListAsync());
        }

        // GET: Tempos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tempo = await _context.Tempos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tempo == null)
            {
                return NotFound();
            }

            return View(tempo);
        }

        // GET: Tempos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tempos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Data,Descritivo,Minutos,AtividadeId,FuncionarioId,ClienteId")] Tempo tempo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tempo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tempo);
        }

        // GET: Tempos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tempo = await _context.Tempos.FindAsync(id);
            if (tempo == null)
            {
                return NotFound();
            }
            return View(tempo);
        }

        // POST: Tempos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Data,Descritivo,Minutos,AtividadeId,FuncionarioId,ClienteId")] Tempo tempo)
        {
            if (id != tempo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tempo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TempoExists(tempo.Id))
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
            return View(tempo);
        }

        // GET: Tempos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tempo = await _context.Tempos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tempo == null)
            {
                return NotFound();
            }

            return View(tempo);
        }

        // POST: Tempos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tempo = await _context.Tempos.FindAsync(id);
            if (tempo != null)
            {
                _context.Tempos.Remove(tempo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TempoExists(int id)
        {
            return _context.Tempos.Any(e => e.Id == id);
        }
    }
}
