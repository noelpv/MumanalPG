using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MumanalPG.Data;
using MumanalPG.Models;
using MumanalPG.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartBreadcrumbs;

namespace MumanalPG.Areas.Admin.Controllers
{
    [Authorize(Roles = SD.SuperAdminEndUser)]
    [Area("Admin")]
    public class ProductTypesController : BaseController
    {

        public ProductTypesController( ApplicationDbContext db): base(db)
        {
        }

        [Breadcrumb("Tipos de Producto")]
        public IActionResult Index()
        {
            return View(DB.ProductTypes.ToList());
        }

        //GET Create Action Method
        [Breadcrumb("Crear",FromAction = "ProductTypes.Index")]
        public IActionResult Create()
        {
            return View();
        }

        //POST Create action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductTypes productTypes)
        {
            if(ModelState.IsValid)
            {
                DB.Add(productTypes);
                await DB.SaveChangesAsync();
                SetFlashSuccess("Se ha creado de forma correcta.");
                return RedirectToAction(nameof(Index));
            }
            return View(productTypes);
        }


        //GET Edit Action Method
        [Breadcrumb("Modificar Tipo de Producto")]
        public async Task<IActionResult> Edit(int? id)
        {
            if(id==null)
            {
                return NotFound();
            }

            var productType = await DB.ProductTypes.FindAsync(id);
            if (productType == null)
            {
                return NotFound();
            }

            return View(productType);
        }

        //POST Edit action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProductTypes productTypes)
        {
            if(id!=productTypes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                DB.Update(productTypes);
                await DB.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productTypes);
        }

        //GET Details Action Method
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productType = await DB.ProductTypes.FindAsync(id);
            if (productType == null)
            {
                return NotFound();
            }

            return View(productType);
        }


        //GET Delete Action Method
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productType = await DB.ProductTypes.FindAsync(id);
            if (productType == null)
            {
                return NotFound();
            }

            return View(productType);
        }

        //POST Delete action Method
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productTypes = await DB.ProductTypes.FindAsync(id);
            DB.ProductTypes.Remove(productTypes);
            await DB.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}