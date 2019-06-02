using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MumanalPG.Data;
using MumanalPG.Models.RRHH;

namespace MumanalPG.Areas.RRHH
{
    [Area("RRHH")]
    public class VacacionProgramacionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VacacionProgramacionController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: RRHH/VacacionProgramacion
        public async Task<IActionResult> Index()
        {
            return View(await _context.VacacionProgramacion.ToListAsync());
        }

        // GET: RRHH/VacacionProgramacion/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vacacionProgramacion = await _context.VacacionProgramacion
                .FirstOrDefaultAsync(m => m.IdVacacionProgramacion == id);
            if (vacacionProgramacion == null)
            {
                return NotFound();
            }

            return View(vacacionProgramacion);
        }

        // GET: RRHH/VacacionProgramacion/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RRHH/VacacionProgramacion/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdVacacionProgramacion, IdActivoFijo, IdBeneficiarioOrigen, IdBeneficiario, IdUnidadEjecutora, IdUnidadEjecutoraDestino, IdEstadoRegistro, IdUsuario, FechaRegistro")] VacacionProgramacion vacacionProgramacion)
        {
            if (ModelState.IsValid)
            {
                vacacionProgramacion.FechaRegistro = DateTime.Now;
                vacacionProgramacion.IdEstadoRegistro = '1';

                _context.Add(vacacionProgramacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vacacionProgramacion);
        }

        // GET: RRHH/VacacionProgramacion/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vacacionProgramacion = await _context.VacacionProgramacion.FindAsync(id);
            if (vacacionProgramacion == null)
            {
                return NotFound();
            }
            return View(vacacionProgramacion);
        }

        // POST: RRHH/VacacionProgramacion/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdVacacionProgramacion, IdActivoFijo, IdBeneficiarioOrigen, IdBeneficiario, IdUnidadEjecutora, IdUnidadEjecutoraDestino, IdEstadoRegistro, IdUsuario, FechaRegistro")] VacacionProgramacion vacacionProgramacion)
        {
            if (id != vacacionProgramacion.IdVacacionProgramacion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vacacionProgramacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VacacionProgramacionExists(vacacionProgramacion.IdVacacionProgramacion))
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
            return View(vacacionProgramacion);
        }

        // GET: RRHH/VacacionProgramacion/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vacacionProgramacion = await _context.VacacionProgramacion
                .FirstOrDefaultAsync(m => m.IdVacacionProgramacion == id);
            if (vacacionProgramacion == null)
            {
                return NotFound();
            }

            return View(vacacionProgramacion);
        }

        // POST: RRHH/VacacionProgramacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vacacionProgramacion = await _context.VacacionProgramacion.FindAsync(id);
            _context.VacacionProgramacion.Remove(vacacionProgramacion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VacacionProgramacionExists(int id)
        {
            return _context.VacacionProgramacion.Any(e => e.IdVacacionProgramacion == id);
        }
    }
}
