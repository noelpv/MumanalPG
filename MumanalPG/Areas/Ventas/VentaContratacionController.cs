using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MumanalPG.Data;
using MumanalPG.Models.Ventas;

namespace MumanalPG.Areas.Ventas
{
    [Area("Ventas")]
    public class VentaContratacionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VentaContratacionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Ventas/VentaContratacion
        public async Task<IActionResult> Index()
        {
            return View(await _context.VentaContratacion.ToListAsync());
        }

        // GET: Ventas/VentaContratacion/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventaContratacion = await _context.VentaContratacion
                .FirstOrDefaultAsync(m => m.IdVentaContratacion == id);
            if (ventaContratacion == null)
            {
                return NotFound();
            }

            return View(ventaContratacion);
        }

        // GET: Ventas/VentaContratacion/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ventas/VentaContratacion/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdVentaContratacion,IdVentaSolicitud,IdProcesoNivel2,Gestion,IdUnidadEjecutora,CorrelativoUnidad,IdDepartamento,FechaVenta,IdBeneficiario,IdBeneficiarioGarante,IdBeneficiarioResponsable,IdVentaTarifario,Concepto,Observaciones,CiteTramite,IdAsrSiver,MesNumero,FechaInicio,FechaFinal,CantidadTotal,TotalBs,TotalDolares,IdTipoMoneda,TipoCambio,TotalPrevisionBs,Literal,PlazoMeses,MesInicioCronograma,IdPoa,IdProceso,IdDocumentoRespaldo,NumeroDocumento,ArchivoRespaldo,ArchivoRespaldoCargado,IdEstadoRegistro,IdUsuario,IdUsuarioAprueba,FechaRegistro,FechaAprueba")] VentaContratacion ventaContratacion)
        {
            if (ModelState.IsValid)
            {
				ventaContratacion.IdVentaSolicitud = 0;
				ventaContratacion.IdProcesoNivel2 = 0;
				ventaContratacion.Gestion = DateTime.Now.Year.ToString();
				ventaContratacion.IdDepartamento = 2;
				ventaContratacion.IdBeneficiarioResponsable = 0;
				ventaContratacion.IdVentaTarifario = 0;
				ventaContratacion.Concepto = "Solicitud de Reposición de Ayuda Social reversible";
				ventaContratacion.Observaciones = "Digitalización";
				ventaContratacion.MesNumero = DateTime.Now.Month;
				ventaContratacion.FechaInicio = DateTime.Now.Date;
				ventaContratacion.FechaFinal = DateTime.Now.Date;
				ventaContratacion.CantidadTotal = 1;
				ventaContratacion.TotalBs = 0;
				ventaContratacion.TotalDolares = 0;
				ventaContratacion.IdTipoMoneda = 1;
				ventaContratacion.TipoCambio = 0;
				ventaContratacion.TotalPrevisionBs = 0;
				ventaContratacion.IdUsuario = 1;
				ventaContratacion.FechaRegistro= DateTime.Now.Date;

				_context.Add(ventaContratacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ventaContratacion);
        }

        // GET: Ventas/VentaContratacion/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventaContratacion = await _context.VentaContratacion.FindAsync(id);
            if (ventaContratacion == null)
            {
                return NotFound();
            }
            return View(ventaContratacion);
        }

        // POST: Ventas/VentaContratacion/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdVentaContratacion,IdVentaSolicitud,IdProcesoNivel2,Gestion,IdUnidadEjecutora,CorrelativoUnidad,IdDepartamento,FechaVenta,IdBeneficiario,IdBeneficiarioGarante,IdBeneficiarioResponsable,IdVentaTarifario,Concepto,Observaciones,CiteTramite,IdAsrSiver,MesNumero,FechaInicio,FechaFinal,CantidadTotal,TotalBs,TotalDolares,IdTipoMoneda,TipoCambio,TotalPrevisionBs,Literal,PlazoMeses,MesInicioCronograma,IdPoa,IdProceso,IdDocumentoRespaldo,NumeroDocumento,ArchivoRespaldo,ArchivoRespaldoCargado,IdEstadoRegistro,IdUsuario,IdUsuarioAprueba,FechaRegistro,FechaAprueba")] VentaContratacion ventaContratacion)
        {
            if (id != ventaContratacion.IdVentaContratacion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ventaContratacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VentaContratacionExists(ventaContratacion.IdVentaContratacion))
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
            return View(ventaContratacion);
        }

        // GET: Ventas/VentaContratacion/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventaContratacion = await _context.VentaContratacion
                .FirstOrDefaultAsync(m => m.IdVentaContratacion == id);
            if (ventaContratacion == null)
            {
                return NotFound();
            }

            return View(ventaContratacion);
        }

        // POST: Ventas/VentaContratacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ventaContratacion = await _context.VentaContratacion.FindAsync(id);
            _context.VentaContratacion.Remove(ventaContratacion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VentaContratacionExists(int id)
        {
            return _context.VentaContratacion.Any(e => e.IdVentaContratacion == id);
        }
    }
}
