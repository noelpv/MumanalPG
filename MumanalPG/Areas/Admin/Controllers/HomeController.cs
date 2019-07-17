using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MumanalPG.Models;
using MumanalPG.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using MumanalPG.Areas;
using MumanalPG.Extensions;
using MumanalPG.Utility;
using SmartBreadcrumbs;

namespace MumanalPG.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class HomeController : BaseController
    {
        public HomeController(ApplicationDbContext db) : base(db)
        {
            
        }

        [DefaultBreadcrumb("")]
        public IActionResult Index()
        {
           SetFlashInfo("Esto es una prueba");
           return View();
        }

    }
}
