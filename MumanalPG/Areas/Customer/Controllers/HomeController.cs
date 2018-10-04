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

namespace MumanalPG.Controllers
{
    [Authorize]
    [Area("Customer")]
    public class HomeController : BaseController
    {
        public HomeController(ApplicationDbContext db) : base(db)
        {
            
        }

        [DefaultBreadcrumb("Inicio")]
        [Route("/")]
        [Route("Admin")]
        public async Task<IActionResult> Index()
        {
            var productList = await DB.Products.Include(m => m.ProductTypes).Include(m => m.SpecialTags).ToListAsync();
            SetFlashInfo("Esto es una prueba");
            return View(productList);
        }

        public async Task<IActionResult> Details(int id)
        {
            var product = await DB.Products.Include(m => m.ProductTypes).Include(m => m.SpecialTags).Where(m=>m.Id==id).FirstOrDefaultAsync();


            return View(product);
        }

        [HttpPost,ActionName("Details")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DetailsPost(int id)
        {
            List<int> lstShoppingCart = HttpContext.Session.Get<List<int>>("ssShoppingCart");
            if(lstShoppingCart==null)
            {
                lstShoppingCart = new List<int>();
            }
            lstShoppingCart.Add(id);
            HttpContext.Session.Set("ssShoppingCart", lstShoppingCart);

            return RedirectToAction("Index", "Home", new { area = "Customer" });

        }

        public IActionResult Remove(int id)
        {
            List<int> lstShoppingCart = HttpContext.Session.Get<List<int>>("ssShoppingCart");
            if(lstShoppingCart.Count>0)
            {
                if(lstShoppingCart.Contains(id))
                {
                    lstShoppingCart.Remove(id);
                }
            }

            HttpContext.Session.Set("ssShoppingCart", lstShoppingCart);

            return RedirectToAction(nameof(Index));
        }





        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
