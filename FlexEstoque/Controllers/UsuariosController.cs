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
    public class UsuariosController : Controller
    {
        private readonly FlexEstoqueContext _context;

        public UsuariosController(FlexEstoqueContext context)
        {
            this._context = context;
        }


        // GET: Usuarios
        public async Task<IActionResult> Index()
        {
              return _context.Models != null ? 
                          View(await _context.Models.ToListAsync()) :
                          Problem("Entity set 'FlexEstoqueContext.Models'  is null.");
        }

        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Models == null)
            {
                return NotFound();
            }

            var usuario = await _context.Models
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email,Login,Perfil,Senha,DataCadastro,DataAtualizacao")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuario);
                usuario.DataCadastro = DateTime.Now;
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }

        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Models == null)
            {
                return NotFound();
            }

            var usuario = await _context.Models.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,Login,Perfil,Senha,DataCadastro,DataAtualizacao")] Usuario usuario)
        {
            if (id != usuario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuario.Id))
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
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Models == null)
            {
                return NotFound();
            }

            var usuario = await _context.Models
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Models == null)
            {
                return Problem("Entity set 'FlexEstoqueContext.Models'  is null.");
            }
            var usuario = await _context.Models.FindAsync(id);
            if (usuario != null)
            {
                _context.Models.Remove(usuario);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioExists(int id)
        {
          return (_context.Models?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
