using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MumanalPG.Data;
using MumanalPG.Models.Ventas;

namespace MumanalPG.Areas.Ventas
{
    [Area("Ventas")]
    public class VentaRequisitoController : Controller
    {
        private readonly ApplicationDbContext _context;
		private readonly IHostingEnvironment he;
		
        public VentaRequisitoController(ApplicationDbContext context, IHostingEnvironment HE)
        {
            _context = context;
			he = HE;
		}
		        
        public async Task<IActionResult> Index(Int32? Id) // GET: Ventas/VentaRequisito
		{
			Id = Convert.ToInt32(TempData["IdContratacion"]);
			return View(await _context.vRequisito.Where(f => f.IdVentaContratacion == Id).ToListAsync());
        }
				
		public async Task<IActionResult> Details(int? id) // GET: Ventas/VentaRequisito/Details/5
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventaRequisito = await _context.VentaRequisito
                .FirstOrDefaultAsync(m => m.IdVentaRequisito == id);
            if (ventaRequisito == null)
            {
                return NotFound();
            }

            return View(ventaRequisito);
        }

		//----------------------------------------------------------
		public IActionResult Create(int? id) // GET: Ventas/VentaRequisito/Create
        {
			TempData["IdContratacion"] = id;
			var items = new List<SelectListItem>();

			items = _context.DocumentoRespaldo.Select(c => new SelectListItem()
			{
				Text = c.Descripcion,
				Value = c.IdDocumentoRespaldo.ToString()
			}).ToList();

			ViewBag.Cities = items;
			ViewBag.id = id;
			return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdVentaRequisito,IdVentaContratacion,IdBeneficiario,IdDocumentoRespaldo,IdDocumentoFormato,DocumentoEntregado,PathArchivo,ArchivoCargado,IdEstadoRegistro,IdUsuario,FechaRegistro")] VentaRequisito ventaRequisito, IFormFile ArchivoPDF, int?id, string Cities)
        {
            if (ModelState.IsValid)
            {
				String fileName = "";
				if (ArchivoPDF != null)
				{
					fileName = Path.Combine(he.WebRootPath, Path.GetFileName(ArchivoPDF.FileName));
					ArchivoPDF.CopyTo(new FileStream(fileName, FileMode.Create));
				}

				ventaRequisito.IdVentaContratacion = Convert.ToInt32(TempData["IdContratacion"]);
				ventaRequisito.IdVentaContratacion = Convert.ToInt32(id);
				ventaRequisito.IdBeneficiario = 1;
				ventaRequisito.DocumentoEntregado = true;
				ventaRequisito.IdDocumentoRespaldo =Convert.ToInt32(Cities);
				ventaRequisito.PathArchivo = fileName;
				ventaRequisito.ArchivoCargado = true;
				ventaRequisito.IdEstadoRegistro = 1;
				ventaRequisito.IdUsuario = 1;
				ventaRequisito.FechaRegistro = DateTime.Now;

				_context.Add(ventaRequisito);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ventaRequisito);
        }

		//----------------------------------------------------------
		public async Task<IActionResult> Edit(int? id) // GET: Ventas/VentaRequisito/Edit/5
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventaRequisito = await _context.VentaRequisito.FindAsync(id);
            if (ventaRequisito == null)
            {
                return NotFound();
            }
            return View(ventaRequisito);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdVentaRequisito,IdVentaContratacion,IdBeneficiario,IdDocumentoRespaldo,IdDocumentoFormato,DocumentoEntregado,PathArchivo,ArchivoCargado,IdEstadoRegistro,IdUsuario,FechaRegistro")] VentaRequisito ventaRequisito)
        {
            if (id != ventaRequisito.IdVentaRequisito)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ventaRequisito);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VentaRequisitoExists(ventaRequisito.IdVentaRequisito))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(ventaRequisito);
        }

		//----------------------------------------------------------
		public async Task<IActionResult> Delete(int? id) // GET: Ventas/VentaRequisito/Delete/5
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventaRequisito = await _context.VentaRequisito
                .FirstOrDefaultAsync(m => m.IdVentaRequisito == id);
            if (ventaRequisito == null)
            {
                return NotFound();
            }

            return View(ventaRequisito);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ventaRequisito = await _context.VentaRequisito.FindAsync(id);
            _context.VentaRequisito.Remove(ventaRequisito);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

		//----------------------------------------------------------
		private bool VentaRequisitoExists(int id)
        {
            return _context.VentaRequisito.Any(e => e.IdVentaRequisito == id);
        }

		public async Task<IActionResult> VerPDF(int? id, int? idContratacion)
		{
			if (id == null)
			{
				return NotFound();
			}

			ViewBag.idContratacion = idContratacion;

			var ventaRequisito = await _context.VentaRequisito.FindAsync(id);
			if (ventaRequisito == null)
			{
				return NotFound();
			}

			string x = ventaRequisito.PathArchivo;
			x = Path.GetFileName(x);
			ViewData["ArchivoPDF2"] = "/" + x;

			return View("VerPDF");
		}
	}
}
