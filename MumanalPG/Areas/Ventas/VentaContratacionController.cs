using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Dynamic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MumanalPG.Data;
using MumanalPG.Models.Ventas;
using MumanalPG.Extensions;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;

namespace MumanalPG.Areas.Ventas
{
    [Area("Ventas")]
    public class VentaContratacionController : BaseController
    {
		//private readonly ApplicationDbContext _context;
		//const string SessionIdBeneficiario = "_IdBeneficiario";
		//const string SessionBeneficiario = "_Beneficiario";
		//const string SessionIdBeneficiarioGarante = "_IdBeneficiariogarante";
		//const string SessionGarante = "_Garante";
		//const string SessionKeyDate = "_Date";

		public VentaContratacionController(ApplicationDbContext db) : base(db)
        {
			//_context = context;
			
		}

		public async Task<IActionResult> Index(string searchString)
        {
			String InternalSearchString = "";
			ViewData["CurrentFilter"] = searchString;
			if (!String.IsNullOrEmpty(searchString))
				InternalSearchString = searchString;

			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

			return View(await DB.Ventas_vContratacion.FromSql($"SELECT * FROM \"Ventas\".\"pContratacion\"({userId}, {InternalSearchString})").ToListAsync());

			//SELECT * FROM "Ventas"."pContratacion"('0eb3655e-dc53-4950-9414-455d8d1329be');
			//return View(await DB.Ventas_vContratacion.ToListAsync());
        }

		public async Task<IActionResult> IndexReg(string searchString)
        {
            String InternalSearchString = "";
            ViewData["CurrentFilter"] = searchString;
            if (!String.IsNullOrEmpty(searchString))
                InternalSearchString = searchString;

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            return View(await DB.Ventas_vContratacion.FromSql($"SELECT * FROM \"Ventas\".\"pContratacion\"({userId}, {InternalSearchString})").ToListAsync());
        }


        [HttpGet]
		public JsonResult LoadData()
		{
			var draw = Request.Form.GetPropertyValue("draw").FirstOrDefault();
			var start = Request.Form.GetPropertyValue("start").FirstOrDefault();
			var length = Request.Form.GetPropertyValue("length").FirstOrDefault();
			var sortColumn = Request.Form.GetPropertyValue("columns[" + Request.Form.GetPropertyValue("order[0][column]").FirstOrDefault() + "][name]").FirstOrDefault();
			var sortColumnDir = Request.Form.GetPropertyValue("order[0][dir]").FirstOrDefault();

			var contactName = Request.Form.GetPropertyValue("columns[0][search][value]").FirstOrDefault();
			var country = Request.Form.GetPropertyValue("columns[3][search][value]").FirstOrDefault();

			int pageSize = length != null ? Convert.ToInt32(length):0;
			int skip = start != null ? Convert.ToInt16(start) : 0;
			int recordsTotal = 0;

			var v = (from a in DB.Ventas_vContratacion select a);

			if (!string.IsNullOrEmpty(contactName.ToString()))
			{
				v = v.Where(a => a.IdAsrSiver.Contains(contactName));
			}
			if (!string.IsNullOrEmpty(country.ToString()))
			{
				v = v.Where(a => a.UnidadEjecutora.Contains(country.ToString()));
			}
			if (!(string.IsNullOrEmpty(sortColumn.ToString()) && string.IsNullOrEmpty(sortColumnDir.ToString())))
			{
				//v = v.OrderBy(sortColumn.ToString() + " " + sortColumnDir.ToString());
			}
			recordsTotal = v.Count();
			var data = v.Skip(skip).Take(pageSize).ToList();
			return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });
		}

		public async Task<IActionResult> BuscaPersona(string searchString, Int32 IdBeneficiario, String Beneficiario, Int32 IdBeneficiarioGarante, String Garante)
		{
			String InternalSearchString = ".";
			ViewData["CurrentFilter"] = searchString;
			ViewBag.IdBeneficiario = IdBeneficiario;
			ViewBag.Beneficiario = Beneficiario;
			ViewBag.IdBeneficiarioGarante = IdBeneficiarioGarante;
			ViewBag.Garante = Garante;

			//IQueryable<vContratacion> categorias;

			if (!String.IsNullOrEmpty(searchString))
				InternalSearchString = searchString;

			return View(await DB.RRHH_vPersona.FromSql($"SELECT * FROM \"RRHH\".\"fBuscaPersona\"({InternalSearchString})").ToListAsync());
		}
		
		public async Task<IActionResult> BuscaPersona2(string searchString, Int32 IdBeneficiario, String Beneficiario, Int32 IdBeneficiarioGarante, String Garante)
		{
			String InternalSearchString = "-";
			ViewData["CurrentFilter"] = searchString;
			ViewBag.IdBeneficiario = IdBeneficiario;
			ViewBag.Beneficiario = Beneficiario;
			ViewBag.IdBeneficiarioGarante = IdBeneficiarioGarante;
			ViewBag.Garante = Garante;

			//IQueryable<vContratacion> categorias;

			if (!String.IsNullOrEmpty(searchString))
				InternalSearchString = searchString;

			return View(await DB.RRHH_vPersona.FromSql($"SELECT * FROM \"RRHH\".\"fBuscaPersona\"({InternalSearchString})").ToListAsync());
		}

		//--CREATE GET DIGITAL  -------------------------------------------------------- 
        public IActionResult Create(String IdBeneficiario, String IdBeneficiarioGarante, String Beneficiario, String Garante)
        {
			Models.Ventas.VentaContratacion Contratacion = new VentaContratacion();
			Contratacion.FechaVenta = DateTime.Now.Date;

			if (IdBeneficiario == null && IdBeneficiarioGarante == null)
			{
				ViewBag.IdBeneficiario = IdBeneficiario;
				ViewBag.Beneficiario = Beneficiario;
				ViewBag.IdBeneficiarioGarante = IdBeneficiarioGarante;
				ViewBag.Garante = Garante;
			}
			else if (IdBeneficiario != null && IdBeneficiarioGarante == "0")
			{
				//HttpContext.Session.SetString(SessionIdBeneficiario, IdBeneficiario);
				//HttpContext.Session.SetString(SessionBeneficiario, Beneficiario);

				ViewBag.IdBeneficiario = IdBeneficiario;
				ViewBag.Beneficiario = Beneficiario;
				ViewBag.IdBeneficiarioGarante = IdBeneficiarioGarante;
				ViewBag.Garante = Garante;
			}
			else if (IdBeneficiario == "0" && IdBeneficiarioGarante != null)
			{
				//HttpContext.Session.SetString(SessionIdBeneficiarioGarante, IdBeneficiarioGarante);
				//HttpContext.Session.SetString(SessionGarante, Garante);

				//ViewBag.IdBeneficiario = HttpContext.Session.GetString(SessionIdBeneficiario);
				//ViewBag.Beneficiario = HttpContext.Session.GetString(SessionBeneficiario);
				//ViewBag.IdBeneficiarioGarante = HttpContext.Session.GetString(SessionIdBeneficiarioGarante);
				//ViewBag.Garante = HttpContext.Session.GetString(SessionGarante);
			}

			//// BENEFICIARIOS --------------------------------------------
			//var items = new List<SelectListItem>();
			//items = DB.RRHH_Beneficiario.
			//	   Where(f => f.DepartamentoSigla == "LPZ").
			//	   OrderBy(x => x.Denominacion).
			//	   Select(c => new SelectListItem()
			//				{
			//					Text = c.Denominacion,
			//					Value = c.IdBeneficiario.ToString()
			//				}).
			//	   ToList();
			//ViewBag.Beneficiarios = items;

			//// GARANTES --------------------------------------------------
			//var items3 = new List<SelectListItem>();
			//items3 = DB.RRHH_Beneficiario.
			//	   Where(f => f.DepartamentoSigla == "LPZ").
			//	   OrderBy(x => x.Denominacion).
			//	   Select(c => new SelectListItem()
			//	   {
			//		   Text = c.Denominacion,
			//		   Value = c.IdBeneficiario.ToString()
			//	   }).
			//	   ToList();
			//ViewBag.Garantes = items3;

			// UNIDAD EJECUTORA ------------------------------------------


			//var items2 = new List<SelectListItem>();

			//items2 = DB.RRHH_UnidadEjecutora.
			//	   Select(c => new SelectListItem()
			//	   {
			//		   Text = c.Descripcion,
			//		   Value = c.IdUnidadEjecutora.ToString()
			//	   }).
			//	   ToList();
			//ViewBag.UnidadesEjecutoras = items2;

			//var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

			//var items3 = new List<SelectListItem>();

			//items3 = (from E in DB.RRHH_UnidadEjecutora
			//		  join U in DB.Seguridad_UsuarioUnidadEjecutora on E.IdUnidadEjecutora equals U.IdUnidadEjecutora
			//		  join R in DB.Seguridad_Usuario on U.IdUsuario equals R.IdUsuario
			//		  where R.Id == userId
			//		  select new SelectListItem()
			//		  {
			//			  Text = E.Descripcion,
			//			  Value = E.IdUnidadEjecutora.ToString()
			//		  }
			//		 ).ToList();
			//ViewBag.UnidadesEjecutoras = items3;

			//var entryPoint = (from u in DB.RRHH_UnidadEjecutora
			//				  join e in dbContext.tbl_Entry on ep.EID equals e.EID
			//				  join t in dbContext.tbl_Title on e.TID equals t.TID
			//				  where e.OwnerID == user.UID
			//				  select new
			//				  {
			//					  UID = e.OwnerID,
			//					  TID = e.TID,
			//					  Title = t.Title,
			//					  EID = e.EID
			//				  }).Take(10);

			return View(Contratacion);
        }

		[HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdVentaContratacion,IdVentaSolicitud,IdProcesoNivel2,Gestion,IdUnidadEjecutora,CorrelativoUnidad,IdDepartamento,FechaVenta,IdBeneficiario,IdBeneficiarioGarante,IdBeneficiarioResponsable,IdVentaTarifario,Concepto,Observaciones,CiteTramite,IdAsrSiver,MesNumero,FechaInicio,FechaFinal,CantidadTotal,TotalBs,TotalDolares,IdTipoMoneda,TipoCambio,TotalPrevisionBs,Literal,PlazoMeses,MesInicioCronograma,IdPoa,IdProceso,IdDocumentoRespaldo,NumeroDocumento,ArchivoRespaldo,ArchivoRespaldoCargado,IdEstadoRegistro,IdUsuario,IdUsuarioAprueba,FechaRegistro,FechaAprueba")] VentaContratacion ventaContratacion, string Beneficiarios, string Garantes, string UnidadesEjecutoras, String IdBeneficiario, String IdBeneficiarioGarante)
        {
			if (ModelState.IsValid)
			{
				var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

				var BuscaId = DB.Generales_fBuscaId.FromSql($"SELECT * FROM \"Generales\".\"fBuscaId\"({userId})").ToList();
				Int32 IdUnidadEjecutora = BuscaId.FirstOrDefault().IdUnidadEjecutora;
				
				ventaContratacion.IdUnidadEjecutora = IdUnidadEjecutora; // Convert.ToInt32(UnidadesEjecutoras);
				ventaContratacion.IdVentaSolicitud = 0;
				ventaContratacion.IdProcesoNivel2 = 0;
				ventaContratacion.Gestion = DateTime.Now.Year.ToString();
				ventaContratacion.IdDepartamento = 2;
				//ventaContratacion.IdBeneficiario = //Convert.ToInt32(Beneficiarios);
				ventaContratacion.IdBeneficiarioGarante = -1;// Convert.ToInt32(HttpContext.Session.GetString(SessionIdBeneficiarioGarante)); //Convert.ToInt32(Garantes);
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
				ventaContratacion.IdEstadoRegistro = 1;
				ventaContratacion.IdUsuario = 1;
				ventaContratacion.FechaRegistro = DateTime.Now.Date;

				DB.Add(ventaContratacion);
				await DB.SaveChangesAsync();
				return RedirectToAction(nameof(Index));				
			}
		
            return View(ventaContratacion);
        }

        //--CREATE GET REGULAR  -------------------------------------------------------- 
        public IActionResult CreateReg(String IdBeneficiario, String IdBeneficiarioGarante, String Beneficiario, String Garante)
        {
            Models.Ventas.VentaContratacion Contratacion = new VentaContratacion();
            Contratacion.FechaVenta = DateTime.Now.Date;

            if (IdBeneficiario == null && IdBeneficiarioGarante == null)
            {
                ViewBag.IdBeneficiario = IdBeneficiario;
                ViewBag.Beneficiario = Beneficiario;
                ViewBag.IdBeneficiarioGarante = IdBeneficiarioGarante;
                ViewBag.Garante = Garante;
            }
            else if (IdBeneficiario != null && IdBeneficiarioGarante == "0")
            {
                //HttpContext.Session.SetString(SessionIdBeneficiario, IdBeneficiario);
                //HttpContext.Session.SetString(SessionBeneficiario, Beneficiario);

                ViewBag.IdBeneficiario = IdBeneficiario;
                ViewBag.Beneficiario = Beneficiario;
                ViewBag.IdBeneficiarioGarante = IdBeneficiarioGarante;
                ViewBag.Garante = Garante;
            }
            else if (IdBeneficiario == "0" && IdBeneficiarioGarante != null)
            {
                //HttpContext.Session.SetString(SessionIdBeneficiarioGarante, IdBeneficiarioGarante);
                //HttpContext.Session.SetString(SessionGarante, Garante);

                //ViewBag.IdBeneficiario = HttpContext.Session.GetString(SessionIdBeneficiario);
                //ViewBag.Beneficiario = HttpContext.Session.GetString(SessionBeneficiario);
                //ViewBag.IdBeneficiarioGarante = HttpContext.Session.GetString(SessionIdBeneficiarioGarante);
                //ViewBag.Garante = HttpContext.Session.GetString(SessionGarante);
            }

            //// BENEFICIARIOS --------------------------------------------
            //var items = new List<SelectListItem>();
            //items = DB.RRHH_Beneficiario.
            //	   Where(f => f.DepartamentoSigla == "LPZ").
            //	   OrderBy(x => x.Denominacion).
            //	   Select(c => new SelectListItem()
            //				{
            //					Text = c.Denominacion,
            //					Value = c.IdBeneficiario.ToString()
            //				}).
            //	   ToList();
            //ViewBag.Beneficiarios = items;

            //// GARANTES --------------------------------------------------
            //var items3 = new List<SelectListItem>();
            //items3 = DB.RRHH_Beneficiario.
            //	   Where(f => f.DepartamentoSigla == "LPZ").
            //	   OrderBy(x => x.Denominacion).
            //	   Select(c => new SelectListItem()
            //	   {
            //		   Text = c.Denominacion,
            //		   Value = c.IdBeneficiario.ToString()
            //	   }).
            //	   ToList();
            //ViewBag.Garantes = items3;

            // UNIDAD EJECUTORA ------------------------------------------


            //var items2 = new List<SelectListItem>();

            //items2 = DB.RRHH_UnidadEjecutora.
            //	   Select(c => new SelectListItem()
            //	   {
            //		   Text = c.Descripcion,
            //		   Value = c.IdUnidadEjecutora.ToString()
            //	   }).
            //	   ToList();
            //ViewBag.UnidadesEjecutoras = items2;

            //var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            //var items3 = new List<SelectListItem>();

            //items3 = (from E in DB.RRHH_UnidadEjecutora
            //		  join U in DB.Seguridad_UsuarioUnidadEjecutora on E.IdUnidadEjecutora equals U.IdUnidadEjecutora
            //		  join R in DB.Seguridad_Usuario on U.IdUsuario equals R.IdUsuario
            //		  where R.Id == userId
            //		  select new SelectListItem()
            //		  {
            //			  Text = E.Descripcion,
            //			  Value = E.IdUnidadEjecutora.ToString()
            //		  }
            //		 ).ToList();
            //ViewBag.UnidadesEjecutoras = items3;

            //var entryPoint = (from u in DB.RRHH_UnidadEjecutora
            //				  join e in dbContext.tbl_Entry on ep.EID equals e.EID
            //				  join t in dbContext.tbl_Title on e.TID equals t.TID
            //				  where e.OwnerID == user.UID
            //				  select new
            //				  {
            //					  UID = e.OwnerID,
            //					  TID = e.TID,
            //					  Title = t.Title,
            //					  EID = e.EID
            //				  }).Take(10);

            return View(Contratacion);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateReg([Bind("IdVentaContratacion,IdVentaSolicitud,IdProcesoNivel2,Gestion,IdUnidadEjecutora,CorrelativoUnidad,IdDepartamento,FechaVenta,IdBeneficiario,IdBeneficiarioGarante,IdBeneficiarioResponsable,IdVentaTarifario,Concepto,Observaciones,CiteTramite,IdAsrSiver,MesNumero,FechaInicio,FechaFinal,CantidadTotal,TotalBs,TotalDolares,IdTipoMoneda,TipoCambio,TotalPrevisionBs,Literal,PlazoMeses,MesInicioCronograma,IdPoa,IdProceso,IdDocumentoRespaldo,NumeroDocumento,ArchivoRespaldo,ArchivoRespaldoCargado,IdEstadoRegistro,IdUsuario,IdUsuarioAprueba,FechaRegistro,FechaAprueba")] VentaContratacion ventaContratacion, string Beneficiarios, string Garantes, string UnidadesEjecutoras, String IdBeneficiario, String IdBeneficiarioGarante)
        {
            if (ModelState.IsValid)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                var BuscaId = DB.Generales_fBuscaId.FromSql($"SELECT * FROM \"Generales\".\"fBuscaId\"({userId})").ToList();
                Int32 IdUnidadEjecutora = BuscaId.FirstOrDefault().IdUnidadEjecutora;

                ventaContratacion.IdUnidadEjecutora = IdUnidadEjecutora; // Convert.ToInt32(UnidadesEjecutoras);
                ventaContratacion.IdVentaSolicitud = 0;
                ventaContratacion.IdProcesoNivel2 = 0;
                ventaContratacion.Gestion = DateTime.Now.Year.ToString();
                ventaContratacion.IdDepartamento = 2;
                //ventaContratacion.IdBeneficiario = //Convert.ToInt32(Beneficiarios);
                ventaContratacion.IdBeneficiarioGarante = -1;// Convert.ToInt32(HttpContext.Session.GetString(SessionIdBeneficiarioGarante)); //Convert.ToInt32(Garantes);
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
                ventaContratacion.IdEstadoRegistro = 1;
                ventaContratacion.IdUsuario = 1;
                ventaContratacion.FechaRegistro = DateTime.Now.Date;

                DB.Add(ventaContratacion);
                await DB.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View("IndexReg");
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

		// href
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
		public async Task<IActionResult> Requisitos(int? id, String Beneficiario, String IdAsrSiver)
		{
			if (id == null)
			{
				return NotFound();
			}
		
			await DB.Database.ExecuteSqlCommandAsync($"CALL \"Ventas\".\"pGeneraRequisitos\"({id})");

			var ventaContratacion = await DB.Ventas_VentaContratacion.FirstOrDefaultAsync(m => m.IdVentaContratacion == id);
			if (ventaContratacion == null)
			{
				return NotFound();
			}

			TempData["IdContratacion"] = id;
			TempData["Titulo"] = "Requisitos para NroASR: " + IdAsrSiver + " - Titular: " + Beneficiario;


			//TempData.Keep();
			return RedirectToAction( "Index", "VentaRequisito", new { Id = id });
		}

		private bool VentaContratacionExists(int id)
        {
            return DB.Ventas_VentaContratacion.Any(e => e.IdVentaContratacion == id);
        }

		//----------------------------------------------------------
		public async Task<IActionResult> Enviar(int? id)
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

			var ValidaDocumentos = DB.Generales_fRetornaEntero.FromSql($"SELECT * FROM \"Ventas\".\"fVerificaDocumentos\"({id})").ToList();
			Int32 CodigoRetorno = ValidaDocumentos.FirstOrDefault().Entero;

			//-- 0 = 'Aun no se han generado los requisitos!!!'
			//-- 1 = 'Todos los Documentos fueron cargados!!!'
			//-- 2 = 'Falta cargar documentos!!!'
			if (CodigoRetorno == 0)
				ViewBag.Mensaje = "Aun no se han generado los requisitos!!!";
			else if (CodigoRetorno == 1)
				ViewBag.Mensaje = "Esta Seguro de enviar?";
			else
				ViewBag.Mensaje = "Falta cargar documentos!!!";

			return View(ventaContratacion);
		}

		[HttpPost, ActionName("Enviar")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> EnviarConfirmed(int id)
		{
			var ventaContratacion = await DB.Ventas_VentaContratacion.FindAsync(id);
			ventaContratacion.IdEstadoRegistro = 2;
			await DB.SaveChangesAsync();

			SetFlashInfo("El Tramite fue enviado satisfactoriamente!!!");
			return RedirectToAction(nameof(Index));
		}
	}
}
