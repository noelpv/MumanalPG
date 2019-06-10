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

namespace MumanalPG.Areas.Ventas.Controllers
{
    //[Authorize(Roles = SD.SuperAdminEndUser)]
    [Authorize]
    [Area("Ventas")]
    public class DashboardVentaController : BaseController
    {        
		public DashboardVentaController(ApplicationDbContext db): base(db)
        {
        }

        // GET: Ventas/Prestaciones
        [Breadcrumb("Prestaciones")]
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [Breadcrumb("Clasificadores", FromAction = "Index")]
        public async Task<IActionResult> Clasificadores()
        {
            return View();
        }

        //[Breadcrumb("Presupuesto", FromAction = "Index")]
        //public async Task<IActionResult> Plan()
        //{
        //    //var consulta = DB.EstructuraProgramatica.AsNoTracking().AsQueryable();
        //    //consulta = consulta.Where(m => m.IdEstadoRegistro != '2'); //!= Constantes.Eliminado );

        //    //var resp = await PagingList.CreateAsync(consulta, 100, 1, "Descripcion", "Sigla");
        //    ////resp.RouteValue = new RouteValueDictionary {{ "filter", filter}};
        //    return View();
        //}

    } 
}
