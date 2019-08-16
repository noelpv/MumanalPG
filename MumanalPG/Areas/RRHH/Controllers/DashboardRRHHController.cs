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
    public class DashboardRRHHController : BaseController
    {        
		public DashboardRRHHController(ApplicationDbContext db): base(db)
        {
        }

        // GET: RRHH/RRHH
        [Breadcrumb("RRHH")]
        public IActionResult Index()
        {
            return View();
        }

        [Breadcrumb("AdministracionRRHH", FromAction = "Index")]
        public async Task<IActionResult> AdministracionRRHH()
        {
            return View();
        }

        [Breadcrumb("ControlRRHH", FromAction = "Index")]
        public async Task<IActionResult> ControlRRHH()
        {
            return View();
        }

        [Breadcrumb("Planillas", FromAction = "Index")]
        public async Task<IActionResult> Planillas()
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
