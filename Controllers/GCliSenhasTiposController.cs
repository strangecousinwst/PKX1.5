﻿using System;
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
    public class GCliSenhasTiposController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GCliSenhasTiposController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Tipoes
        public async Task<IActionResult> Index()
        {
              return View(await _context.Tipos.ToListAsync());
        }

        // GET: Tipoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Tipos == null)
            {
                return NotFound();
            }

            var tipo = await _context.Tipos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipo == null)
            {
                return NotFound();
            }

            return View(tipo);
        }

        // GET: Tipoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tipoes/Create
        // To protect from overposting aTacks, enable the specific properties you want to bind to.
        // For more details, see hTp://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Designacao")] Tipo tipo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipo);
        }

        // GET: Tipoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Tipos == null)
            {
                return NotFound();
            }

            var tipo = await _context.Tipos.FindAsync(id);
            if (tipo == null)
            {
                return NotFound();
            }
            return View(tipo);
        }

        // POST: Tipoes/Edit/5
        // To protect from overposting aTacks, enable the specific properties you want to bind to.
        // For more details, see hTp://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Designacao")] Tipo tipo)
        {
            if (id != tipo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoExists(tipo.Id))
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
            return View(tipo);
        }

        // GET: Tipoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Tipos == null)
            {
                return NotFound();
            }

            //quantos itens tem este tipo?
            if (id > 0)
            {
                ViewBag.CONTAGEM = _context.Itens.Where(m => m.TipoId == id).Count();
            }
            else
            {
                ViewBag.CONTAGEM = 0;
            }


            var tipo = await _context.Tipos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipo == null)
            {
                return NotFound();
            }

            return View(tipo);
        }

        // POST: Tipoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Tipos == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Tipos'  is null.");
            }
            var tipo = await _context.Tipos.FindAsync(id);
            if (tipo != null)
            {
                _context.Tipos.Remove(tipo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoExists(int id)
        {
          return _context.Tipos.Any(e => e.Id == id);
        }
    }
}
