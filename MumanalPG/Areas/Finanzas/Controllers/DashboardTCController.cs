using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using MumanalPG.Data;
using MumanalPG.Utility;
using ReflectionIT.Mvc.Paging;
using SmartBreadcrumbs;

namespace MumanalPG.Areas.Finanzas.Controllers
{
    //[Authorize(Roles = SD.SuperAdminEndUser)]
    [Authorize]
    [Area("Finanzas")]
    public class DashboardFFController : BaseController
    {        
		public DashboardFFController(ApplicationDbContext db): base(db)
        {
        }

//		// GET: Finanzas/TipoComprobante
//        [Breadcrumb("Finanzas")]
//        public async Task<IActionResult> Index()
//        { 
//            return View();
//        }
//
//        [Breadcrumb("Clasificadores", FromAction = "Index")]
//        public async Task<IActionResult> Clasificadores()
//        {
//            return View();
//        }
//        
//        [Breadcrumb("TipoComprobante", FromAction = "Index")]
//        public async Task<IActionResult> Docs()
//        {
//            var consulta = DB.TipoComprobante.AsNoTracking().AsQueryable();
//            consulta = consulta.Where(m => m.IdEstadoRegistro != '2'); //!= Constantes.Eliminado );
//            
//            var resp = await PagingList.CreateAsync(consulta, 100, 1, "Descripcion", "Sigla");
//            //resp.RouteValue = new RouteValueDictionary {{ "filter", filter}};
//            return View(resp);
//        }

    } 
}
