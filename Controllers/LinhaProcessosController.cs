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
    public class LinhaProcessosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LinhaProcessosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: LinhaProcessos
        public async Task<IActionResult> Index()
        {
            return View(await _context.LinhasProcessos.ToListAsync());
        }

        // GET: LinhaProcessos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var linhaProcesso = await _context.LinhasProcessos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (linhaProcesso == null)
            {
                return NotFound();
            }

            return View(linhaProcesso);
        }

        // GET: LinhaProcessos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LinhaProcessos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Data,Texto,ProcessoId,FuncionarioId")] LinhaProcesso linhaProcesso)
        {
            if (ModelState.IsValid)
            {
                _context.Add(linhaProcesso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(linhaProcesso);
        }

        // GET: LinhaProcessos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var linhaProcesso = await _context.LinhasProcessos.FindAsync(id);
            if (linhaProcesso == null)
            {
                return NotFound();
            }
            return View(linhaProcesso);
        }

        // POST: LinhaProcessos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Data,Texto,ProcessoId,FuncionarioId")] LinhaProcesso linhaProcesso)
        {
            if (id != linhaProcesso.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(linhaProcesso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LinhaProcessoExists(linhaProcesso.Id))
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
            return View(linhaProcesso);
        }

        // GET: LinhaProcessos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var linhaProcesso = await _context.LinhasProcessos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (linhaProcesso == null)
            {
                return NotFound();
            }

            return View(linhaProcesso);
        }

        // POST: LinhaProcessos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var linhaProcesso = await _context.LinhasProcessos.FindAsync(id);
            if (linhaProcesso != null)
            {
                _context.LinhasProcessos.Remove(linhaProcesso);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LinhaProcessoExists(int id)
        {
            return _context.LinhasProcessos.Any(e => e.Id == id);
        }
    }
}
