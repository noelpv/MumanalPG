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
    public class DashboardFinanzasController : BaseController
    {        
		public DashboardFinanzasController(ApplicationDbContext db): base(db)
        {
        }

        // GET: Finanzas/Finanzas
        [Breadcrumb("Finanzas")]
        public IActionResult Index()
        {
            return View();
        }

        [Breadcrumb("Cobranzas", FromAction = "Index")]
        public IActionResult Cobranzas()
        {
            return View();
        }

        [Breadcrumb("Pagos", FromAction = "Index")]
        public IActionResult Pagos()
        {
            return View();
        }

        [Breadcrumb("Contabilidad", FromAction = "Index")]
        public IActionResult Contabilidad()
        {
            return View();
        }


        [Breadcrumb("Fondos", FromAction = "Index")]
        public IActionResult Fondos()
        {
            return View();
        }

        [Breadcrumb("Clasificadores", FromAction = "Index")]
        public IActionResult Clasificadores()
        {
            return View();
        }
    } 
}
