using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Teste_Tria_Software.Models;

namespace Teste_Tria_Software.Controllers
{
    public class ClienteEmpresasController : Controller
    {
        private readonly Contexto _context;

        public ClienteEmpresasController(Contexto context)
        {
            _context = context;
        }

        // GET: ClienteEmpresas
        public async Task<IActionResult> Index()
        {
            var contexto = _context.ClienteEmpresas.Include(c => c.Cliente).Include(c => c.Empresa);
            return View(await contexto.ToListAsync());
        }

        // GET: ClienteEmpresas/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienteEmpresa = await _context.ClienteEmpresas
                .Include(c => c.Cliente)
                .Include(c => c.Empresa)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (clienteEmpresa == null)
            {
                return NotFound();
            }

            return View(clienteEmpresa);
        }

        // GET: ClienteEmpresas/Create
        public IActionResult Create()
        {
            ViewData["ClienteID"] = new SelectList(_context.Clientes, "ClienteID", "NOME");
            ViewData["EmpresaID"] = new SelectList(_context.Empresas, "EmpresaID", "RAZAO_SOCIAL");
            return View();
        }

        // POST: ClienteEmpresas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ClienteID,EmpresaID")] ClienteEmpresa clienteEmpresa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clienteEmpresa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteID"] = new SelectList(_context.Clientes, "ClienteID", "NOME", clienteEmpresa.ClienteID);
            ViewData["EmpresaID"] = new SelectList(_context.Empresas, "EmpresaID", "RAZAO_SOCIAL", clienteEmpresa.EmpresaID);
            return View(clienteEmpresa);
        }

        // GET: ClienteEmpresas/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienteEmpresa = await _context.ClienteEmpresas.FindAsync(id);
            if (clienteEmpresa == null)
            {
                return NotFound();
            }
            ViewData["ClienteID"] = new SelectList(_context.Clientes, "ClienteID", "NOME", clienteEmpresa.ClienteID);
            ViewData["EmpresaID"] = new SelectList(_context.Empresas, "EmpresaID", "RAZAO_SOCIAL", clienteEmpresa.EmpresaID);
            return View(clienteEmpresa);
        }

        // POST: ClienteEmpresas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("ID,ClienteID,EmpresaID")] ClienteEmpresa clienteEmpresa)
        {
            if (id != clienteEmpresa.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clienteEmpresa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteEmpresaExists(clienteEmpresa.ID))
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
            ViewData["ClienteID"] = new SelectList(_context.Clientes, "ClienteID", "NOME", clienteEmpresa.ClienteID);
            ViewData["EmpresaID"] = new SelectList(_context.Empresas, "EmpresaID", "RAZAO_SOCIAL", clienteEmpresa.EmpresaID);
            return View(clienteEmpresa);
        }

        // GET: ClienteEmpresas/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienteEmpresa = await _context.ClienteEmpresas
                .Include(c => c.Cliente)
                .Include(c => c.Empresa)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (clienteEmpresa == null)
            {
                return NotFound();
            }

            return View(clienteEmpresa);
        }

        // POST: ClienteEmpresas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var clienteEmpresa = await _context.ClienteEmpresas.FindAsync(id);
            _context.ClienteEmpresas.Remove(clienteEmpresa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteEmpresaExists(long id)
        {
            return _context.ClienteEmpresas.Any(e => e.ID == id);
        }
    }
}
