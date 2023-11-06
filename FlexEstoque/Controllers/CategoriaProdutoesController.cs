using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FlexEstoque.Data;
using FlexEstoque.Models;

namespace FlexEstoque.Controllers
{
    public class CategoriaProdutoesController : Controller
    {
        private readonly FlexEstoqueContext _context;

        public CategoriaProdutoesController(FlexEstoqueContext context)
        {
            _context = context;
        }

        // GET: CategoriaProdutoes
        public async Task<IActionResult> Index()
        {
              return _context.CategoriaProduto != null ? 
                          View(await _context.CategoriaProduto.ToListAsync()) :
                          Problem("Entity set 'FlexEstoqueContext.CategoriaProduto'  is null.");
        }

        // GET: CategoriaProdutoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CategoriaProduto == null)
            {
                return NotFound();
            }

            var categoriaProduto = await _context.CategoriaProduto
                .FirstOrDefaultAsync(m => m.Id == id);
            if (categoriaProduto == null)
            {
                return NotFound();
            }

            return View(categoriaProduto);
        }

        // GET: CategoriaProdutoes/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descricao")] CategoriaProduto categoriaProduto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categoriaProduto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categoriaProduto);
        }

        // GET: CategoriaProdutoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CategoriaProduto == null)
            {
                return NotFound();
            }

            var categoriaProduto = await _context.CategoriaProduto.FindAsync(id);
            if (categoriaProduto == null)
            {
                return NotFound();
            }
            return View(categoriaProduto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descricao")] CategoriaProduto categoriaProduto)
        {
            if (id != categoriaProduto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoriaProduto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoriaProdutoExists(categoriaProduto.Id))
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
            return View(categoriaProduto);
        }

        // GET: CategoriaProdutoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CategoriaProduto == null)
            {
                return NotFound();
            }

            var categoriaProduto = await _context.CategoriaProduto
                .FirstOrDefaultAsync(m => m.Id == id);
            if (categoriaProduto == null)
            {
                return NotFound();
            }

            return View(categoriaProduto);
        }

        // POST: CategoriaProdutoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CategoriaProduto == null)
            {
                return Problem("Entity set 'FlexEstoqueContext.CategoriaProduto'  is null.");
            }
            var categoriaProduto = await _context.CategoriaProduto.FindAsync(id);
            if (categoriaProduto != null)
            {
                _context.CategoriaProduto.Remove(categoriaProduto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoriaProdutoExists(int id)
        {
          return (_context.CategoriaProduto?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
