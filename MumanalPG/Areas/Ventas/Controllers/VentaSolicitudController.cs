using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Dynamic;
using Microsoft.AspNetCore.Http;
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
using MumanalPG.Extensions;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;


namespace MumanalPG.Areas.Ventas.Controllers
{
    //[Authorize(Roles = SD.SuperAdminEndUser)]
    [Authorize]
    [Area("Ventas")]
    public class VentaSolicitudController : BaseController
    {        
        
		public VentaSolicitudController(ApplicationDbContext db, UserManager<IdentityUser> userManager): base(db, userManager)
        {
            
        }

		// GET: Ventas/VentaSolicitud
        [Breadcrumb("Afiliaciones", FromController = "DashboardVenta", FromAction = "Index")]
        public async Task<IActionResult> Index(string filter, int page = 1, string sortExpression = "Descripcion", string a = "")
        { 
            var consulta = DB.VentaSolicitud.AsNoTracking().AsQueryable();
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

        // GET: Ventas/VentaSolicitud/Details/5
        public async Task<IActionResult> Details(Int32? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await DB.VentaSolicitud.FirstOrDefaultAsync(m => m.IdVentaSolicitud  == id);
            if (item == null)
            {
                return NotFound();
            }

            return PartialView("Details",item);
        }

        // GET: Ventas/VentaSolicitud/Create
        public IActionResult Create()
        {
            var model = new Models.Ventas.VentaSolicitud();
            //UnidadEjecutora
            var itemsU = DB.RRHH_UnidadEjecutora.
                Where(i => i.IdEstadoRegistro != Constantes.Anulado).OrderBy(i => i.Descripcion).ToList();
            ViewBag.UnidadEjecutora = itemsU;

            //Beneficiario
            var itemsB = DB.RRHH_Beneficiario.
                Where(i => i.IdEstadoRegistro != Constantes.Anulado).OrderBy(i => i.Denominacion).ToList();
            ViewBag.Beneficiario = itemsB;

            return PartialView("Create", model);
        }

        // POST: Ventas/VentaSolicitud/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create(Models.Ventas.VentaSolicitud item, string UnidadEjecutora, string Beneficiario)
        public async Task<IActionResult> Create(Models.Ventas.VentaSolicitud item)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser currentUser = await GetCurrentUser();
                item.IdUsuario = currentUser.AspNetUserId;
                item.IdUsuarioAprueba = currentUser.AspNetUserId;
                item.IdBeneficiarioResponsable = currentUser.AspNetUserId;
                item.Gestion = "2019";
                item.CorrelativoUnidad = 0;
                item.IdDepartamento = 2;
                item.FechaSolicitud = DateTime.Now;
                item.FechaRecepcionSolicitud = DateTime.Now;
                item.Observaciones = "Solicitud de Afiliación";
                item.CiteTramite = "MUMANAL/GG/ 1/2019";
                item.MesNumero = 7;
                item.IdPoa = 0;
                item.IdProceso = 11;
                item.IdDocumentoRespaldo = 14;
                item.NumeroDocumento = 6;
                item.PathArchivo = "-";
                item.ArchivoCargado = false;
                item.IdEstadoRegistro = 1;
                item.FechaRegistro = DateTime.Now;
                item.FechaAprueba = DateTime.Now;
                //item.IdUnidadEjecutora = Convert.ToInt32(UnidadEjecutora);
                //item.IdBeneficiario = Convert.ToInt32(Beneficiario);
                //UnidadEjecutora
                var itemsU = DB.RRHH_UnidadEjecutora.
                    Where(i => i.IdEstadoRegistro != Constantes.Anulado).OrderBy(i => i.Descripcion).ToList();
                ViewBag.UnidadEjecutora = itemsU;

                //Beneficiario
                var itemsB = DB.RRHH_Beneficiario.
                    Where(i => i.IdEstadoRegistro != Constantes.Anulado).OrderBy(i => i.Denominacion).ToList();
                ViewBag.Beneficiario = itemsB;
                DB.Add(item);
                await DB.SaveChangesAsync();
                SetFlashSuccess("Registro creado satisfactoriamente");
            }
            
            return PartialView("Create",item);
        }
        // GET: Ventas/VentaSolicitud/Edit/5
        public async Task<IActionResult> Edit(Int32? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await DB.VentaSolicitud.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            //UnidadEjecutora
            var itemsU = DB.RRHH_UnidadEjecutora.
                Where(i => i.IdEstadoRegistro != Constantes.Anulado).OrderBy(i => i.Descripcion).ToList();
            ViewBag.UnidadEjecutora = itemsU;

            //Beneficiario
            var itemsB = DB.RRHH_Beneficiario.
                Where(i => i.IdEstadoRegistro != Constantes.Anulado).OrderBy(i => i.Denominacion).ToList();
            ViewBag.Beneficiario = itemsB;

            return PartialView( "Edit", item);
        }

        // POST: Ventas/VentaSolicitud/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(Int32 id, [Bind("IdVentaSolicitud,IdBeneficiario,Descripcion,IdUnidadEjecutora")] Models.Ventas.VentaSolicitud item)
        public async Task<IActionResult> Edit(Int32 id,  Models.Ventas.VentaSolicitud item)
        {
            if (id != item.IdVentaSolicitud)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    ApplicationUser currentUser = await GetCurrentUser();
                    item.IdUsuario = currentUser.AspNetUserId;
                    item.IdUsuarioAprueba = currentUser.AspNetUserId;
                    item.IdBeneficiarioResponsable = currentUser.AspNetUserId;

                    item.Gestion = "2019";
                    item.CorrelativoUnidad = 0;
                    item.IdDepartamento = 2;
                    item.FechaSolicitud = DateTime.Now;
                    item.FechaRecepcionSolicitud = DateTime.Now;
                    item.Observaciones = "Solicitud de Afiliación";
                    item.CiteTramite = "MUMANAL/GG/ 1/2019";
                    item.MesNumero = 7;
                    item.IdPoa = 0;
                    item.IdProceso = 11;
                    item.IdDocumentoRespaldo = 14;
                    item.NumeroDocumento = 6;
                    item.PathArchivo = "-";
                    item.ArchivoCargado = false;
                    item.IdEstadoRegistro = 1;
                    item.FechaRegistro = DateTime.Now;
                    item.FechaAprueba = DateTime.Now;

                    DB.Update(item);
                    await DB.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemExists(item.IdVentaSolicitud))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                
            }
            //UnidadEjecutora
            var itemsU = DB.RRHH_UnidadEjecutora.
                Where(i => i.IdEstadoRegistro != Constantes.Anulado).OrderBy(i => i.Descripcion).ToList();
            ViewBag.UnidadEjecutora = itemsU;

            //Beneficiario
            var itemsB = DB.RRHH_Beneficiario.
                Where(i => i.IdEstadoRegistro != Constantes.Anulado).OrderBy(i => i.Denominacion).ToList();
            ViewBag.Beneficiario = itemsB;

            return PartialView("Edit", item);
        }

        // GET: Ventas/VentaSolicitud/Delete/5
        public async Task<IActionResult> Delete(Int32? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await DB.VentaSolicitud.FirstOrDefaultAsync(m => m.IdVentaSolicitud == id);
            if (item == null)
            {
                return NotFound();
            }

            return PartialView("Delete",item);
        }

        // POST: Ventas/VentaSolicitud/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Int32 id)
        {
            var item = await DB.VentaSolicitud.FindAsync(id);
            item.IdEstadoRegistro = 2;  //Constantes.Eliminado ;
            DB.VentaSolicitud.Update(item);
            await DB.SaveChangesAsync();
            return PartialView("Delete",item);
        }

        private bool ItemExists(Int32 id)
        {
            return DB.VentaSolicitud.Any(e => e.IdVentaSolicitud == id);
        }
    }
}
