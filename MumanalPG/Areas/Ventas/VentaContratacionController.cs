using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MumanalPG.Data;
using MumanalPG.Models.Ventas;

namespace MumanalPG.Areas.Ventas
{
    [Area("Ventas")]
    public class VentaContratacionController : BaseController
    {
        //private readonly ApplicationDbContext _context;

        public VentaContratacionController(ApplicationDbContext db) : base(db)
        {
            //_context = context;
        }

        public async Task<IActionResult> Index()
        {
			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

			return View(await DB.Ventas_vContratacion.FromSql($"SELECT * FROM \"Ventas\".\"pContratacion\"({userId})").ToListAsync());

			//SELECT * FROM "Ventas"."pContratacion"('0eb3655e-dc53-4950-9414-455d8d1329be');
			//return View(await DB.Ventas_vContratacion.ToListAsync());
        }

		public async Task<IActionResult> BuscaPersona()
		{
			//var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

			//return RedirectToAction("BuscaPersona", "VentaContratacion", new { Id = 1 });
			return View("BuscaPersona");
		}
		public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventaContratacion = await DB.Ventas_VentaContratacion.FirstOrDefaultAsync(m => m.IdVentaContratacion == id);
            if (ventaContratacion == null)
            {
                return NotFound();
            }

            return View(ventaContratacion);
        }
		
		//----------------------------------------------------------
        public IActionResult Create()
        {

			// BENEFICIARIOS -----------------------------------------
			var items = new List<SelectListItem>();
			items = DB.RRHH_Beneficiario.
				   Where(f => f.DepartamentoSigla == "LPZ").
				   OrderBy(x => x.Denominacion).
				   Select(c => new SelectListItem()
							{
								Text = c.Denominacion,
								Value = c.IdBeneficiario.ToString()
							}).
				   ToList();
			ViewBag.Beneficiarios = items;

			// GARANTES -----------------------------------------
			var items3 = new List<SelectListItem>();
			items3 = DB.RRHH_Beneficiario.
				   Where(f => f.DepartamentoSigla == "LPZ").
				   OrderBy(x => x.Denominacion).
				   Select(c => new SelectListItem()
				   {
					   Text = c.Denominacion,
					   Value = c.IdBeneficiario.ToString()
				   }).
				   ToList();
			ViewBag.Garantes = items3;

			// UNIDAD EJECUTORA ------------------------------------------
			var items2 = new List<SelectListItem>();

			items2 = DB.RRHH_UnidadEjecutora.
				   Select(c => new SelectListItem()
				   {
					   Text = c.Descripcion,
					   Value = c.IdUnidadEjecutora.ToString()
				   }).
				   ToList();
			ViewBag.UnidadesEjecutoras = items2;

			return View();
        }

		public Boolean ValidaAntesGrabar()
		{
			Int16 IdUnidadEjecutora = 22;
			var VerificaLimite = DB.Ventas_pVerificaLimite.FromSql($"SELECT * FROM \"Ventas\".\"pVerificaLimite\"({IdUnidadEjecutora})").ToList();
			Int16 CantidadLimite = VerificaLimite.First().CantidadLimite;
			if (4 > CantidadLimite)
			{
				return false;
			}
			else
				return true;
		}

		[HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdVentaContratacion,IdVentaSolicitud,IdProcesoNivel2,Gestion,IdUnidadEjecutora,CorrelativoUnidad,IdDepartamento,FechaVenta,IdBeneficiario,IdBeneficiarioGarante,IdBeneficiarioResponsable,IdVentaTarifario,Concepto,Observaciones,CiteTramite,IdAsrSiver,MesNumero,FechaInicio,FechaFinal,CantidadTotal,TotalBs,TotalDolares,IdTipoMoneda,TipoCambio,TotalPrevisionBs,Literal,PlazoMeses,MesInicioCronograma,IdPoa,IdProceso,IdDocumentoRespaldo,NumeroDocumento,ArchivoRespaldo,ArchivoRespaldoCargado,IdEstadoRegistro,IdUsuario,IdUsuarioAprueba,FechaRegistro,FechaAprueba")] VentaContratacion ventaContratacion, string Beneficiarios, string Garantes, string UnidadesEjecutoras)
        {
			if (ModelState.IsValid)
			{
				ventaContratacion.IdUnidadEjecutora = Convert.ToInt32(UnidadesEjecutoras);
				ventaContratacion.IdVentaSolicitud = 0;
				ventaContratacion.IdProcesoNivel2 = 0;
				ventaContratacion.Gestion = DateTime.Now.Year.ToString();
				ventaContratacion.IdDepartamento = 2;
				ventaContratacion.IdBeneficiario = Convert.ToInt32(Beneficiarios);
				ventaContratacion.IdBeneficiarioGarante = Convert.ToInt32(Garantes);
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
				ventaContratacion.FechaRegistro = DateTime.Now.Date;

				DB.Add(ventaContratacion);
				await DB.SaveChangesAsync();
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

            var ventaContratacion = await DB.Ventas_VentaContratacion.FindAsync(id);
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
                    DB.Update(ventaContratacion);
                    await DB.SaveChangesAsync();
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

            var ventaContratacion = await DB.Ventas_VentaContratacion
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
            var ventaContratacion = await DB.Ventas_VentaContratacion.FindAsync(id);
            DB.Ventas_VentaContratacion.Remove(ventaContratacion);
            await DB.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
		
		//----------------------------------------------------------
		public async Task<IActionResult> Requisitos(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			await DB.Database.ExecuteSqlCommandAsync($"CALL \"Ventas\".\"pGeneraRequisitos\"({id})");

			var ventaContratacion = await DB.Ventas_vContratacion.FirstOrDefaultAsync(m => m.IdVentaContratacion == id);
			if (ventaContratacion == null)
			{
				return NotFound();
			}

			ViewBag.DatosCabecera = "Lista de Requisitos ASR Nro: " + ventaContratacion.IdAsrSiver + " / " +  ventaContratacion.Beneficiario;

			TempData["IdContratacion"] = id;
			return RedirectToAction( "Index", "VentaRequisito", new { Id = id });
		}

		private bool VentaContratacionExists(int id)
        {
            return DB.Ventas_VentaContratacion.Any(e => e.IdVentaContratacion == id);
        }
    }
}
