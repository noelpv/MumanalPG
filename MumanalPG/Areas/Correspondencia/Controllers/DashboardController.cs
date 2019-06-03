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

namespace MumanalPG.Areas.Correspondencia.Controllers
{
    //[Authorize(Roles = SD.SuperAdminEndUser)]
    [Authorize]
    [Area("Correspondencia")]
    public class DashboardController : BaseController
    {        
		public DashboardController(ApplicationDbContext db): base(db)
        {
        }

		// GET: Planificacion/TipoBeneficiarios
        [Breadcrumb("Correspondencia")]
        public async Task<IActionResult> Index()
        { 
            return View();
        }

        [Breadcrumb("Clasificadores", FromAction = "Index")]
        public async Task<IActionResult> Clasificadores()
        {
            return View();
        }
        
        [Breadcrumb("Documentos", FromAction = "Index")]
        public async Task<IActionResult> Docs()
        {
            var consulta = DB.CorrespondenciaTipoDocumento.AsNoTracking().AsQueryable();
            consulta = consulta.Where(m => m.IdEstadoRegistro != Constantes.Anulado);
            
            var resp = await PagingList.CreateAsync(consulta, 100, 1, "Nombre", "Nombre");
            //resp.RouteValue = new RouteValueDictionary {{ "filter", filter}};
            return View(resp);
        }
    }
}
