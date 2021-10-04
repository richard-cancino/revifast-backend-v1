using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Revifast.Models;

namespace Revifast.Controllers
{
    public class ConductoresController : Controller
    {
        private readonly DbRevifastContext _context;

        public ConductoresController(DbRevifastContext context)
        {
            _context = context;
        }

        // GET: Conductores
        public async Task<IActionResult> Index()
        {
            Conductor conductor = _context.Conductor.FirstOrDefault(u => u.Usuario == User.Identity.Name);
            return View(conductor);
        }

        // GET: Conductores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conductor = await _context.Conductor
                .FirstOrDefaultAsync(m => m.ConductorId == id);
            if (conductor == null)
            {
                return NotFound();
            }

            return View(conductor);
        }

        // GET: Conductores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Conductores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ConductorId,Usuario,Nombres,Apellidos,Dni,Correo,Celular")] Conductor conductor)
        {
            var other = _context.Conductor.FirstOrDefault(u=>u.Usuario == conductor.Usuario);
            if (ModelState.IsValid && other == null)
            {
                _context.Add(conductor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(conductor);
        }
        // GET: Conductores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conductor = await _context.Conductor.FindAsync(id);
            if (conductor == null)
            {
                return NotFound();
            }
            return View(conductor);
        }

        // POST: Conductores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ConductorId,Usuario,Nombres,Apellidos,Dni,Correo,Celular")] Conductor conductor)
        {
            if (id != conductor.ConductorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(conductor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConductorExists(conductor.ConductorId))
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
            return View(conductor);
        }

        // GET: Conductores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conductor = await _context.Conductor
                .FirstOrDefaultAsync(m => m.ConductorId == id);
            if (conductor == null)
            {
                return NotFound();
            }

            return View(conductor);
        }

        // POST: Conductores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var conductor = await _context.Conductor.FindAsync(id);
            _context.Conductor.Remove(conductor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public bool ConductorExists(int id)
        {
            return _context.Conductor.Any(e => e.ConductorId == id);
        }
        // For test
        public Conductor GetConductor(int id)
        {
            return _context.Conductor.FirstOrDefault(e => e.ConductorId == id);
        }
    }
}
