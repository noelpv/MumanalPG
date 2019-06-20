using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using MumanalPG.Data;
using MumanalPG.Models;
using MumanalPG.Utility;
using ReflectionIT.Mvc.Paging;
using SmartBreadcrumbs;

namespace MumanalPG.Areas.Ventas.Controllers
{
    //[Authorize(Roles = SD.SuperAdminEndUser)]
    [Authorize]
    [Area("Ventas")]
    public class VentaContratoController : BaseController
    {        
        
		public VentaContratoController(ApplicationDbContext db, UserManager<IdentityUser> userManager): base(db, userManager)
        {
            
        }

		// GET: Ventas/VentaContrato
        [Breadcrumb("Afiliaciones", FromController = "DashboardVenta", FromAction = "Index")]
        public async Task<IActionResult> Index(string filter, int page = 1, string sortExpression = "Descripcion", string a = "")
        { 
            var consulta = DB.VentaContrato.AsNoTracking().AsQueryable();
            consulta = consulta.Where(m => m.IdEstadoRegistro != 2);    //!= Constantes.Eliminado); // != el estado es diferente a ANULADO
            if (!string.IsNullOrWhiteSpace(filter))
			{
                consulta = consulta.Where(m => EF.Functions.ILike(m.Descripcion, $"%{filter}%"));
            }
            var resp = await PagingList.CreateAsync(consulta, Constantes.TamanoPaginacion, page, sortExpression, "Descripcion");
            resp.RouteValue = new RouteValueDictionary {{ "filter", filter}};
            ShowFlash(a);
            return View(resp);
        }

        // GET: Ventas/VentaContrato/Details/5
        public async Task<IActionResult> Details(Int32? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await DB.VentaContrato.FirstOrDefaultAsync(m => m.IdVentaContrato  == id);
            if (item == null)
            {
                return NotFound();
            }

            return PartialView("Details",item);
        }

        // GET: Ventas/VentaContrato/Create
        public IActionResult Create()
        {
            var model = new Models.Ventas.VentaContrato();

            //UnidadEjecutora
            var itemsU = new List<SelectListItem>();
            itemsU = DB.RRHH_UnidadEjecutora.
                   Select(c => new SelectListItem()
                   {
                       Text = c.Descripcion,
                       Value = c.IdUnidadEjecutora.ToString()
                   }).
                   ToList();
            ViewBag.UnidadEjecutora = itemsU;

            //Beneficiario
            var itemsB = new List<SelectListItem>();
            itemsB = DB.RRHH_Beneficiario.
                   Select(c => new SelectListItem()
                   {
                       Text = c.Denominacion,
                       Value = c.IdBeneficiario.ToString()
                   }).
                   ToList();
            ViewBag.Beneficiario = itemsB;

            //VentaTarifario
            var itemsT = new List<SelectListItem>();
            itemsT = DB.VentaTarifario.
                   Select(c => new SelectListItem()
                   {
                       Text = c.Descripcion,
                       Value = c.IdVentaTarifario.ToString()
                   }).
                   ToList();
            ViewBag.VentaTarifario = itemsT;

            return PartialView("Create", model);
        }

        // POST: Ventas/VentaContrato/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Models.Ventas.VentaContrato item, string UnidadEjecutora, string Beneficiario, string VentaTarifario)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser currentUser = await GetCurrentUser();
                item.IdUsuario = currentUser.AspNetUserId;
                item.IdUsuarioAprueba = currentUser.AspNetUserId;
                item.IdBeneficiarioResponsable = currentUser.AspNetUserId;

                item.Gestion = "2019";
                item.CorrelativoUnidad = '0';
                item.IdDepartamento = '2';
                item.FechaVenta = DateTime.Now;
                //item.FechaRecepcionSolicitud = DateTime.Now;
                item.Observaciones = "Solicitud de ASR.";
                item.CiteTramite = "MUMANAL/UP/0101/2019";
                item.IdAsrSiver = Convert.ToString(item.IdVentaContrato);
                item.MesNumero = 6;
                item.FechaInicio = DateTime.Now;
                item.FechaFinal = DateTime.Now;
                item.CantidadTotal = 36;
                item.TotalDolares = 36;
                item.IdTipoMoneda = 1;
                item.TipoCambio = 7;
                item.TotalPrevisionBs = 1;
                item.Literal = "-";
                item.PlazoMeses = 24;
                item.MesInicioCronograma = 7;

                item.IdPoa = 0;
                item.IdProceso = 12;
                item.IdDocumentoRespaldo = 14;
                item.NumeroDocumento = 101;
                item.ArchivoRespaldo = "-";
                item.ArchivoRespaldoCargado = false;
                item.IdEstadoRegistro = 1;
                item.FechaRegistro = DateTime.Now;
                item.FechaAprueba = DateTime.Now;
                item.IdUnidadEjecutora = Convert.ToInt32(UnidadEjecutora);
                item.IdBeneficiario = Convert.ToInt32(Beneficiario);
                item.IdVentaTarifario = Convert.ToInt32(VentaTarifario);
                DB.Add(item);
                await DB.SaveChangesAsync();
                
            }
            return PartialView("Create",item);
        }

        // GET: Ventas/VentaContrato/Edit/5
        public async Task<IActionResult> Edit(Int32? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await DB.VentaContrato.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return PartialView( "Edit", item);
        }

        // POST: Ventas/VentaContrato/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Int32 id, [Bind("IdVentaContrato,IdBeneficiario,Descripcion,IdUnidadEjecutora")] Models.Ventas.VentaContrato item)
        {
            if (id != item.IdVentaContrato)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    DB.Update(item);
                    await DB.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemExists(item.IdVentaContrato))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                
            }
            return PartialView("Edit", item);
        }

        // GET: Ventas/VentaContrato/Delete/5
        public async Task<IActionResult> Delete(Int32? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await DB.VentaContrato.FirstOrDefaultAsync(m => m.IdVentaContrato == id);
            if (item == null)
            {
                return NotFound();
            }

            return PartialView("Delete",item);
        }

        // POST: Ventas/VentaContrato/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Int32 id)
        {
            var item = await DB.VentaContrato.FindAsync(id);
            item.IdEstadoRegistro = 2;  //Constantes.Eliminado ;
            DB.VentaContrato.Update(item);
            await DB.SaveChangesAsync();
            return PartialView("Delete",item);
        }

        private bool ItemExists(Int32 id)
        {
            return DB.VentaContrato.Any(e => e.IdVentaContrato == id);
        }
    }
}
