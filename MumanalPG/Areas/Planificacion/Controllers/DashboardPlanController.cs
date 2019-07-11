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

namespace MumanalPG.Areas.Planificacion.Controllers
{
    //[Authorize(Roles = SD.SuperAdminEndUser)]
    [Authorize]
    [Area("Planificacion")]
    public class DashboardPlanController : BaseController
    {        
		public DashboardPlanController(ApplicationDbContext db): base(db)
        {
        }

        // GET: Planificacion/Planificacion
        [Breadcrumb("Planificacion")]
        public IActionResult Index()
        {
            return View();
        }

        [Breadcrumb("Clasificadores", FromAction = "Index")]
        public IActionResult Clasificadores()
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
