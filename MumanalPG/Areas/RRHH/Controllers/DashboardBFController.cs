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

namespace MumanalPG.Areas.RRHH.Controllers
{
    //[Authorize(Roles = SD.SuperAdminEndUser)]
    [Authorize]
    [Area("RRHH")]
    public class DashboardBFController : BaseController
    {        
		public DashboardBFController(ApplicationDbContext db): base(db)
        {
        }

//        // GET: RRHH/Beneficiario
//        [Breadcrumb("RRHH")]
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
//        [Breadcrumb("Beneficiario", FromAction = "Index")]
//        public async Task<IActionResult> DocsO()
//        {
//            var consulta = DB.RRHH_Beneficiario.AsNoTracking().AsQueryable();
//            consulta = consulta.Where(m => m.IdEstadoRegistro != '2'); //!= Constantes.Eliminado );
//
//            var resp = await PagingList.CreateAsync(consulta, 100, 1, "PrimerApellido", "SegundoApellido");
//            //resp.RouteValue = new RouteValueDictionary {{ "filter", filter}};
//            return View(resp);
//        }

    } 
}
