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
    }
}
