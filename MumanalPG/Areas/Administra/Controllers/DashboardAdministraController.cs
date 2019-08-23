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

namespace MumanalPG.Areas.Administra.Controllers
{
    //[Authorize(Roles = SD.SuperAdminEndUser)]
    [Authorize]
    [Area("Administra")]
    public class DashboardAdministraController : BaseController
    {        
		public DashboardAdministraController(ApplicationDbContext db): base(db)
        {
        }

        // GET: Administra/Administra
        [Breadcrumb("Administra")]
        public IActionResult Index()
        {
            return View();
        }

        [Breadcrumb("Compras", FromAction = "Index")]
        public IActionResult Compras()
        {
            return View();
        }

        [Breadcrumb("Almacenes", FromAction = "Index")]
        public IActionResult Almacenes()
        {
            return View();
        }

        [Breadcrumb("ActivosFijos", FromAction = "Index")]
        public IActionResult ActivosFijos()
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
