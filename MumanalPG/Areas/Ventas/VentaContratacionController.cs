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

        public async Task<IActionResult> Index()
        {
			return View(await _context.vContratacion.ToListAsync());
        }

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
		
		//----------------------------------------------------------
        public IActionResult Create()
        {
			var items = new List<SelectListItem>();

			items = _context.RRHH_Beneficiario.
				   Where(f => f.DepartamentoSigla == "LPZ").
				   //OrderBy(x => new {x.Denominacion}).
				   Select(c => new SelectListItem()
							{
								Text = c.Denominacion,
								Value = c.IdBeneficiario.ToString()
							}).
				   ToList();
			ViewBag.Beneficiarios = items;

			var items2 = new List<SelectListItem>();

			items2 = _context.RRHH_UnidadEjecutora.
				   Select(c => new SelectListItem()
				   {
					   Text = c.Descripcion,
					   Value = c.IdUnidadEjecutora.ToString()
				   }).
				   ToList();
			ViewBag.UnidadesEjecutoras = items2;

			return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdVentaContratacion,IdVentaSolicitud,IdProcesoNivel2,Gestion,IdUnidadEjecutora,CorrelativoUnidad,IdDepartamento,FechaVenta,IdBeneficiario,IdBeneficiarioGarante,IdBeneficiarioResponsable,IdVentaTarifario,Concepto,Observaciones,CiteTramite,IdAsrSiver,MesNumero,FechaInicio,FechaFinal,CantidadTotal,TotalBs,TotalDolares,IdTipoMoneda,TipoCambio,TotalPrevisionBs,Literal,PlazoMeses,MesInicioCronograma,IdPoa,IdProceso,IdDocumentoRespaldo,NumeroDocumento,ArchivoRespaldo,ArchivoRespaldoCargado,IdEstadoRegistro,IdUsuario,IdUsuarioAprueba,FechaRegistro,FechaAprueba")] VentaContratacion ventaContratacion, string Beneficiarios, string UnidadesEjecutoras)
        {
            if (ModelState.IsValid)
            {
				ventaContratacion.IdUnidadEjecutora = Convert.ToInt32(UnidadesEjecutoras);
				ventaContratacion.IdVentaSolicitud = 0;
				ventaContratacion.IdProcesoNivel2 = 0;
				ventaContratacion.Gestion = DateTime.Now.Year.ToString();
				ventaContratacion.IdDepartamento = 2;
				ventaContratacion.IdBeneficiario = Convert.ToInt32(Beneficiarios);
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

		//----------------------------------------------------------
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
		
		//----------------------------------------------------------
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

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ventaContratacion = await _context.VentaContratacion.FindAsync(id);
            _context.VentaContratacion.Remove(ventaContratacion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
		
		//----------------------------------------------------------
		public async Task<IActionResult> Requisitos(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			TempData["IdContratacion"] = id;
			return RedirectToAction("Index", "VentaRequisito", new { Id = id });

			//MumanalPG.Areas.Ventas.VentaRequisitoController.
			//return View("NameOfView", Model);
			//return View(ventaContratacion);
		}

		private bool VentaContratacionExists(int id)
        {
            return _context.VentaContratacion.Any(e => e.IdVentaContratacion == id);
        }
    }
}
