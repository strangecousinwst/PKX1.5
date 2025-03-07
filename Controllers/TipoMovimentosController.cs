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
    public class TipoMovimentosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TipoMovimentosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TipoMovimentos
        public async Task<IActionResult> Index()
        {
            return View(await _context.TiposMovimentos.ToListAsync());
        }

        // GET: TipoMovimentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoMovimento = await _context.TiposMovimentos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoMovimento == null)
            {
                return NotFound();
            }

            return View(tipoMovimento);
        }

        // GET: TipoMovimentos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoMovimentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Designacao")] TipoMovimento tipoMovimento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoMovimento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoMovimento);
        }

        // GET: TipoMovimentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoMovimento = await _context.TiposMovimentos.FindAsync(id);
            if (tipoMovimento == null)
            {
                return NotFound();
            }
            return View(tipoMovimento);
        }

        // POST: TipoMovimentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Designacao")] TipoMovimento tipoMovimento)
        {
            if (id != tipoMovimento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoMovimento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoMovimentoExists(tipoMovimento.Id))
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
            return View(tipoMovimento);
        }

        // GET: TipoMovimentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoMovimento = await _context.TiposMovimentos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoMovimento == null)
            {
                return NotFound();
            }

            return View(tipoMovimento);
        }

        // POST: TipoMovimentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoMovimento = await _context.TiposMovimentos.FindAsync(id);
            if (tipoMovimento != null)
            {
                _context.TiposMovimentos.Remove(tipoMovimento);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoMovimentoExists(int id)
        {
            return _context.TiposMovimentos.Any(e => e.Id == id);
        }
    }
}
