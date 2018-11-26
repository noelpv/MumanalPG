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
    public class TablaPDFController : Controller
    {
        private readonly ApplicationDbContext _context;

		private readonly IHostingEnvironment he;
        public TablaPDFController(ApplicationDbContext context, IHostingEnvironment HE)
        {
            _context = context;
			he = HE;
        } 

        // GET: Ventas/TablaPDF
        public async Task<IActionResult> Index()
        {
            return View(await _context.TablaPDF.ToListAsync());
        }

        // GET: Ventas/TablaPDF/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tablaPDF = await _context.TablaPDF
                .FirstOrDefaultAsync(m => m.IdTablaPDF == id);
            if (tablaPDF == null)
            {
                return NotFound();
            }

            return View(tablaPDF);
        }

        // GET: Ventas/TablaPDF/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ventas/TablaPDF/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTablaPDF,IdDocumento,RutaDocumento,Cargado")] TablaPDF tablaPDF, IFormFile PDFfile)
        {
            if (ModelState.IsValid)
			{
				String fileName = "";
				if (PDFfile != null)
				{
					fileName = Path.Combine(he.WebRootPath, Path.GetFileName(PDFfile.FileName));
					PDFfile.CopyTo(new FileStream(fileName, FileMode.Create));
				}
				//IHostingEnvironment env =;
				//string fileName = $"{env.WebRootPath}\\{file.FileName}";

				//using (FileStream fs = System.IO.File.Create(fileName))
				//{
				//	file.CopyTo(fs);
				//	fs.Flush();
				//}

				//ViewData["message"] = $"{file.Length} bytes uploaded successfully!";

				tablaPDF.RutaDocumento = fileName;
				tablaPDF.Cargado = true;

				_context.Add(tablaPDF);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tablaPDF);
        }

        // GET: Ventas/TablaPDF/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tablaPDF = await _context.TablaPDF.FindAsync(id);
            if (tablaPDF == null)
            {
                return NotFound();
            }
            return View(tablaPDF);
        }

        // POST: Ventas/TablaPDF/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTablaPDF,IdDocumento,RutaDocumento,Cargado")] TablaPDF tablaPDF)
        {
            if (id != tablaPDF.IdTablaPDF)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tablaPDF);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TablaPDFExists(tablaPDF.IdTablaPDF))
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
            return View(tablaPDF);
        }

        // GET: Ventas/TablaPDF/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tablaPDF = await _context.TablaPDF
                .FirstOrDefaultAsync(m => m.IdTablaPDF == id);
            if (tablaPDF == null)
            {
                return NotFound();
            }

            return View(tablaPDF);
        }

        // POST: Ventas/TablaPDF/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tablaPDF = await _context.TablaPDF.FindAsync(id);
            _context.TablaPDF.Remove(tablaPDF);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TablaPDFExists(int id)
        {
            return _context.TablaPDF.Any(e => e.IdTablaPDF == id);
        }
    }
}
