using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MumanalPG.Data;
using MumanalPG.Models.Administra;

namespace MumanalPG.Areas.Administra
{
    [Area("Administra")]
    public class CompraContratacionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CompraContratacionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Administra/CompraContratacion
        public async Task<IActionResult> Index()
        {
            return View(await _context.CompraContratacion.ToListAsync());
        }

        // GET: Administra/CompraContratacion/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compraContratacion = await _context.CompraContratacion
                .FirstOrDefaultAsync(m => m.IdCompraContratacion == id);
            if (compraContratacion == null)
            {
                return NotFound();
            }

            return View(compraContratacion);
        }

        // GET: Administra/CompraContratacion/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Administra/CompraContratacion/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCompraContratacion,IdCompraSolicitud,Gestion,FechaCompra,IdBeneficiario,IdBeneficiarioResponsable,Concepto,Observaciones,CiteTramite,IdModalidadContratacion,MesNumero,IdDepartamento,FechaInicio,FechaFinal,IdPoa,IdProceso,IdDocumentoRespaldo,NumeroDocumento,ArchivoRespaldo,ArchivoRespaldoCargado,IdEstadoRegistro,IdUsuario,IdUsuarioAprueba,FechaRegistro,FechaAprueba")] CompraContratacion compraContratacion)
        {
            if (ModelState.IsValid)
            {
                compraContratacion.FechaRegistro = DateTime.Now;
                compraContratacion.FechaAprueba = DateTime.Now;
                compraContratacion.IdEstadoRegistro = '1';

                _context.Add(compraContratacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(compraContratacion);
        }

        // GET: Administra/CompraContratacion/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compraContratacion = await _context.CompraContratacion.FindAsync(id);
            if (compraContratacion == null)
            {
                return NotFound();
            }
            return View(compraContratacion);
        }

        // POST: Administra/CompraContratacion/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCompraContratacion,IdCompraSolicitud,Gestion,FechaCompra,IdBeneficiario,IdBeneficiarioResponsable,Concepto,Observaciones,CiteTramite,IdModalidadContratacion,MesNumero,IdDepartamento,FechaInicio,FechaFinal,IdPoa,IdProceso,IdDocumentoRespaldo,NumeroDocumento,ArchivoRespaldo,ArchivoRespaldoCargado,IdEstadoRegistro,IdUsuario,IdUsuarioAprueba,FechaRegistro,FechaAprueba")] CompraContratacion compraContratacion)
        {
            if (id != compraContratacion.IdCompraContratacion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(compraContratacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompraContratacionExists(compraContratacion.IdCompraContratacion))
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
            return View(compraContratacion);
        }

        // GET: Administra/CompraContratacion/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compraContratacion = await _context.CompraContratacion
                .FirstOrDefaultAsync(m => m.IdCompraContratacion == id);
            if (compraContratacion == null)
            {
                return NotFound();
            }

            return View(compraContratacion);
        }

        // POST: Administra/CompraContratacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var compraContratacion = await _context.CompraContratacion.FindAsync(id);
            _context.CompraContratacion.Remove(compraContratacion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompraContratacionExists(int id)
        {
            return _context.CompraContratacion.Any(e => e.IdCompraContratacion == id);
        }
    }
}
