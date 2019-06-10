using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MumanalPG.Data;
using MumanalPG.Models.Administra;

namespace MumanalPG.Areas.Administra
{
    [Area("Administra")]
    public class CompraSolicitudController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CompraSolicitudController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Administra/CompraSolicitud
        public async Task<IActionResult> Index()
        {
            return View(await _context.CompraSolicitud.ToListAsync());
        }

        // GET: Administra/CompraSolicitud/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compraSolicitud = await _context.CompraSolicitud
                .FirstOrDefaultAsync(m => m.IdCompraSolicitud == id);
            if (compraSolicitud == null)
            {
                return NotFound();
            }

            return View(compraSolicitud);
        }

        // GET: Administra/CompraSolicitud/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Administra/CompraSolicitud/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCompraSolicitud,Gestion,IdUnidadEjecutora,CorrelativoUnidad,FechaSolicitud,FechaRecepcionSolicitud,IdBeneficiario,IdBeneficiarioResponsable,Justificacion,Observaciones,CiteTramite,MesNumero,IdDepartamento,IdPoa,IdProceso,IdDocumentoRespaldo,NumeroDocumento,PathArchivo,ArchivoCargado,IdEstadoRegistro,IdUsuario,IdUsuarioAprueba,FechaRegistro,FechaAprueba")] CompraSolicitud compraSolicitud)
        {
            if (ModelState.IsValid)
            {
                compraSolicitud.FechaRegistro = DateTime.Now;
                compraSolicitud.FechaAprueba = DateTime.Now;
                compraSolicitud.IdEstadoRegistro = '1';

                _context.Add(compraSolicitud);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(compraSolicitud);
        }

        // GET: Administra/CompraSolicitud/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compraSolicitud = await _context.CompraSolicitud.FindAsync(id);
            if (compraSolicitud == null)
            {
                return NotFound();
            }
            return View(compraSolicitud);
        }

        // POST: Administra/CompraSolicitud/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCompraSolicitud,Gestion,IdUnidadEjecutora,CorrelativoUnidad,FechaSolicitud,FechaRecepcionSolicitud,IdBeneficiario,IdBeneficiarioResponsable,Justificacion,Observaciones,CiteTramite,MesNumero,IdDepartamento,IdPoa,IdProceso,IdDocumentoRespaldo,NumeroDocumento,PathArchivo,ArchivoCargado,IdEstadoRegistro,IdUsuario,IdUsuarioAprueba,FechaRegistro,FechaAprueba")] CompraSolicitud compraSolicitud)
        {
            if (id != compraSolicitud.IdCompraSolicitud)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(compraSolicitud);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompraSolicitudExists(compraSolicitud.IdCompraSolicitud))
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
            return View(compraSolicitud);
        }

        // GET: Administra/CompraSolicitud/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compraSolicitud = await _context.CompraSolicitud
                .FirstOrDefaultAsync(m => m.IdCompraSolicitud == id);
            if (compraSolicitud == null)
            {
                return NotFound();
            }

            return View(compraSolicitud);
        }

        // POST: Administra/CompraSolicitud/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var compraSolicitud = await _context.CompraSolicitud.FindAsync(id);
            _context.CompraSolicitud.Remove(compraSolicitud);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompraSolicitudExists(int id)
        {
            return _context.CompraSolicitud.Any(e => e.IdCompraSolicitud == id);
        }
    }
}
