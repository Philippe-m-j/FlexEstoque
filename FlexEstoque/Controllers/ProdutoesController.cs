﻿using System;
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
    public class ProdutoesController : Controller
    {
        private readonly FlexEstoqueContext _context;

        public ProdutoesController(FlexEstoqueContext context)
        {
            _context = context;
        }
        
        public async Task<IActionResult> Index(string query, string tipoPesquisa)
        {
            if (string.IsNullOrEmpty(query))
            {
                return View(_context.Produto.Include(a => a.Categoria).ToList());
            }
            else if(tipoPesquisa == "Todos")
            {
                return View(_context.Produto.Where(a => a.DescricaoProduto.Contains(query)).Include(a => a.Categoria));
            }
            else
            {
                return View(_context.Produto.Include(a => a.Categoria).ToList());
            }

              return _context.Produto != null ? 
                          View(await _context.Produto.ToListAsync()) :
                          Problem("Entity set 'FlexEstoqueContext.Produto'  is null.");
        }

       
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Produto == null)
            {
                return NotFound();
            }

            var produto = await _context.Produto
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        
        public IActionResult Create()
        {
            ProdutosModel model = new ProdutosModel();
            model.ListaCategoria = _context.CategoriaProduto.ToList();
            return View(model);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomeProduto,CodigoProduto,DescricaoProduto,ValorProduto,ValidadeProduto,EstoqueMinimo,EstoqueMaximo")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(produto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(produto);
        }

        
        public async Task<IActionResult> Edit(int? id)
        {


            if (id == null || _context.Produto == null)
            {
                return NotFound();
            }

            var produto = await _context.Produto.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }
            return View(produto);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomeProduto,CodigoProduto,DescricaoProduto,ValorProduto,ValidadeProduto,EstoqueMinimo,EstoqueMaximo")] Produto produto)
        {
            if (id != produto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutoExists(produto.Id))
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
            return View(produto);
        }

       
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Produto == null)
            {
                return NotFound();
            }

            var produto = await _context.Produto
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Produto == null)
            {
                return Problem("Entity set 'FlexEstoqueContext.Produto'  is null.");
            }
            var produto = await _context.Produto.FindAsync(id);
            if (produto != null)
            {
                _context.Produto.Remove(produto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdutoExists(int id)
        {
          return (_context.Produto?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
