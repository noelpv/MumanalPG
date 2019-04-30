using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MumanalPG.Data;
using MumanalPG.Models.Ventas;

namespace MumanalPG.Areas.Ventas
{
    [Area("Ventas")]
    public class VentaSolicitudController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VentaSolicitudController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Ventas/VentaSolicitud
        public async Task<IActionResult> Index()
        {
            return View(await _context.VentaSolicitud.ToListAsync());
        }

        // GET: Ventas/VentaSolicitud/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventaSolicitud = await _context.VentaSolicitud
                .FirstOrDefaultAsync(m => m.IdVentaSolicitud == id);
            if (ventaSolicitud == null)
            {
                return NotFound();
            }

            return View(ventaSolicitud);
        }

        // GET: Ventas/VentaSolicitud/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ventas/VentaSolicitud/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdVentaSolicitud,Gestion,IdUnidadEjecutora,CorrelativoUnidad,IdDepartamento,FechaSolicitud,FechaRecepcionSolicitud,IdBeneficiario,IdBeneficiarioResponsable,Justificacion,Observaciones,CiteTramite,MesNumero,IdPoa,IdProceso,IdDocumentoRespaldo,NumeroDocumento,PathArchivo,ArchivoCargado,IdEstadoRegistro,IdUsuario,IdUsuarioAprueba,FechaRegistro,FechaAprueba")] VentaSolicitud ventaSolicitud)
        {
            if (ModelState.IsValid)
            {
                ventaSolicitud.FechaRegistro = DateTime.Now;
                ventaSolicitud.FechaAprueba = DateTime.Now;
                ventaSolicitud.IdEstadoRegistro = '1';

                _context.Add(ventaSolicitud);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ventaSolicitud);
        }

        // GET: Ventas/VentaSolicitud/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventaSolicitud = await _context.VentaSolicitud.FindAsync(id);
            if (ventaSolicitud == null)
            {
                return NotFound();
            }
            return View(ventaSolicitud);
        }

        // POST: Ventas/VentaSolicitud/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdVentaSolicitud,Gestion,IdUnidadEjecutora,CorrelativoUnidad,IdDepartamento,FechaSolicitud,FechaRecepcionSolicitud,IdBeneficiario,IdBeneficiarioResponsable,Justificacion,Observaciones,CiteTramite,MesNumero,IdPoa,IdProceso,IdDocumentoRespaldo,NumeroDocumento,PathArchivo,ArchivoCargado,IdEstadoRegistro,IdUsuario,IdUsuarioAprueba,FechaRegistro,FechaAprueba")] VentaSolicitud ventaSolicitud)
        {
            if (id != ventaSolicitud.IdVentaSolicitud)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ventaSolicitud);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VentaSolicitudExists(ventaSolicitud.IdVentaSolicitud))
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
            return View(ventaSolicitud);
        }

        // GET: Ventas/VentaSolicitud/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventaSolicitud = await _context.VentaSolicitud
                .FirstOrDefaultAsync(m => m.IdVentaSolicitud == id);
            if (ventaSolicitud == null)
            {
                return NotFound();
            }

            return View(ventaSolicitud);
        }

        // POST: Ventas/VentaSolicitud/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ventaSolicitud = await _context.VentaSolicitud.FindAsync(id);
            _context.VentaSolicitud.Remove(ventaSolicitud);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VentaSolicitudExists(int id)
        {
            return _context.VentaSolicitud.Any(e => e.IdVentaSolicitud == id);
        }
    }
}
