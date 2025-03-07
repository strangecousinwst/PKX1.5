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
    public class GClientesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GClientesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Clientes
        public async Task<IActionResult> Index(string sort, string stringFiltro)
        {
            List<Cliente> list =_context.Clientes.ToList();

            if ( !string.IsNullOrEmpty(stringFiltro) )
            {
                list = list.Where(m => m.NomeCliente.ToLower().Contains(stringFiltro.ToLower())).ToList();
                ViewBag.STRINGFILTRO = stringFiltro;
            }
                
                    
            if ( string.IsNullOrEmpty(sort) )
            {
                sort = "nome_asc";
                ViewBag.SORTID = "id_asc";
                ViewBag.SORTREF = "ref_asc";
            }
           
            switch (sort)
            {
                case "nome_asc":
                    ViewBag.SORTNOME = "nome_desc";
                    list = list.OrderBy(m => m.NomeCliente).ToList();
                    break;
                case "nome_desc":
                    ViewBag.SORTNOME = "nome_asc";
                    list = list.OrderByDescending(m => m.NomeCliente).ToList();
                    break;
                case "id_asc":
                    ViewBag.SORTID = "id_desc";
                    list = list.OrderBy(m => m.Id).ToList();
                    break;
                case "id_desc":
                    ViewBag.SORTID = "id_asc";
                    list = list.OrderByDescending(m => m.Id).ToList();
                    break;

                case "ref_asc":
                    ViewBag.SORTREF = "ref_desc";
                    list = list.OrderBy(m => m.Referencia).ToList();
                    break;
                case "ref_desc":
                    ViewBag.SORTREF = "ref_asc";
                    list = list.OrderByDescending(m => m.Referencia).ToList();
                    break;
            }
            ViewBag.CONTAGEM = list.Count();
            return View(list.ToList());

        }

        // GET: Clientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Clientes == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // GET: Clientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomeCliente,Referencia")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Clientes == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomeCliente,Referencia")] Cliente cliente)
        {
            if (id != cliente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteExists(cliente.Id))
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
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Clientes == null)
            {
                return NotFound();
            }

            //quantos itens tem este cliente?
            if (id>0)
            {
                ViewBag.CONTAGEM = _context.Itens.Where(m => m.ClienteId == id).Count();
            }
            else
            {
                ViewBag.CONTAGEM = 0;
            }
            
            


            var cliente = await _context.Clientes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Clientes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.TClientes'  is null.");
            }
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteExists(int id)
        {
          return _context.Clientes.Any(e => e.Id == id);
        }
    }
}
