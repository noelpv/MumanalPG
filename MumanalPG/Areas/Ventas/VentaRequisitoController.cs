using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
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
    public class VentaRequisitoController : BaseController
    {
		//private readonly ApplicationDbContext _context;
		//private IHostingEnvironment _hostingEnvironment;

		private /*readonly*/ IHostingEnvironment he;
		
        public VentaRequisitoController(ApplicationDbContext db, IHostingEnvironment HE) : base(db)
        {
            //_context = context;
			he = HE;
			//_hostingEnvironment = environment;
		}
		   
		
        public async Task<IActionResult> Index(Int32? Id) // GET: Ventas/VentaRequisito
		{
			var VentaContratacion = await DB.Ventas_vContratacion.FindAsync(Id);
			if (VentaContratacion == null)
				ViewBag.Titular = "";
			else
				ViewBag.Titular = "Nro ASR: " + VentaContratacion.IdAsrSiver + ",  Titular: " + VentaContratacion.Beneficiario;
			ViewBag.IdVentaContratacion = VentaContratacion.IdVentaContratacion;

			return View(await DB.Ventas_vRequisito.Where(f => f.IdVentaContratacion == Id).OrderBy(p => p.Orden).ToListAsync());
        }
		
		public async Task<IActionResult> Details(int? id) // GET: Ventas/VentaRequisito/Details/5
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventaRequisito = await DB.Ventas_VentaRequisito
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

			items = DB.Ventas_DocumentoRespaldo.Select(c => new SelectListItem()
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
				ventaRequisito.IdDocumentoRespaldo = 1; Convert.ToInt32(Cities);
				ventaRequisito.PathArchivo = fileName;
				ventaRequisito.ArchivoCargado = true;
				ventaRequisito.IdEstadoRegistro = 1;
				ventaRequisito.IdUsuario = 1;
				ventaRequisito.FechaRegistro = DateTime.Now;

				DB.Add(ventaRequisito);
                await DB.SaveChangesAsync();
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

            var ventaRequisito = await DB.Ventas_VentaRequisito.FindAsync(id);
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
                    DB.Update(ventaRequisito);
                    await DB.SaveChangesAsync();
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

            var ventaRequisito = await DB.Ventas_VentaRequisito
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
            var ventaRequisito = await DB.Ventas_VentaRequisito.FindAsync(id);
            DB.Ventas_VentaRequisito.Remove(ventaRequisito);
            await DB.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

		//----------------------------------------------------------
		private bool VentaRequisitoExists(int id)
        {
            return DB.Ventas_VentaRequisito.Any(e => e.IdVentaRequisito == id);
        }

		public async Task<IActionResult> VerJPG(int? id/*, int? idContratacion*/)
		{
			if (id == null)
			{
				return NotFound();
			}

			
			var ventaRequisito = await DB.Ventas_VentaRequisito.FindAsync(id);
			if (ventaRequisito == null)
			{
				return NotFound();
			}

			ViewBag.idContratacion = ventaRequisito.IdVentaContratacion;

			string x = ventaRequisito.PathArchivo;
			x = Path.GetFileName(x);
			ViewData["ArchivoPDF2"] = "/" + x;

			return View("VerJPG");
		}

		public async Task<IActionResult> VerPDF(int? id/*, int? idContratacion*/)
		{
			var ventaRequisito = await DB.Ventas_VentaRequisito.FindAsync(id);
			String Archivo = ventaRequisito.PathArchivo;

			int IdDocumento = ventaRequisito.IdDocumentoRespaldo;
			var documento = await DB.Ventas_DocumentoRespaldo.FindAsync(IdDocumento);
			
			//ViewBag.IdVentaRequisito = id;
			ViewBag.Documento = documento.Descripcion;
			ViewBag.IdVentaContratacion = ventaRequisito.IdVentaContratacion;
			ViewBag.Archivo = string.Format("~/docs/{0}", Archivo);

			return View("VerPDF");
		}

		//[HttpPost]
		////[ValidateAntiForgeryToken]
		//public ActionResult VerPDF()
		//{
		//	string embed = "<object data=\"{0}\" type=\"application/pdf\" width=\"500px\" height=\"300px\">";
		//	embed += "If you are unable to view file, you can download from <a href = \"{0}\">here</a>";
		//	embed += " or download <a target = \"_blank\" href = \"http://get.adobe.com/reader/\">Adobe PDF Reader</a> to view the file.";
		//	embed += "</object>";
		//	TempData["Embed"] = string.Format(embed, @"D:\Fuentes\aJorge\MumanalPG\MumanalPG\wwwroot\uploads\367.pdf");
		//	//TempData["Embed"] = string.Format(embed, VirtualPathUtility.ToAbsolute("~/Files/Mudassar_Khan.pdf"));
		//	ViewBag.Archivo = @"D:\Fuentes\aJorge\MumanalPG\MumanalPG\wwwroot\uploads\367.pdf";
		//	ViewBag.Archivo = string.Format("~/uploads/{0}", "367.pdf");
		//	return RedirectToAction("VerPDF");
		//}

		//----------------------------------------------------------
		public async Task<IActionResult> CargaArchivo(int? idVentaRequisito, String Documento) // GET: Ventas/VentaRequisito/Edit/5
		//public async Task<IActionResult> CargaArchivo(int? id) // GET: Ventas/VentaRequisito/Edit/5
		{

			if (idVentaRequisito == null)
			{
				return NotFound();
			}
			ViewBag.Documento = "Cargar: " + Documento;

			var ventaRequisito = await DB.Ventas_VentaRequisito.FindAsync(idVentaRequisito);
			if (ventaRequisito == null)
			{
				return NotFound();
			}
			return View(ventaRequisito);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> CargaArchivo(int id, [Bind("IdVentaRequisito,IdVentaContratacion,IdBeneficiario,IdDocumentoRespaldo,IdDocumentoFormato,DocumentoEntregado,PathArchivo,ArchivoCargado,IdEstadoRegistro,IdUsuario,FechaRegistro")] VentaRequisito ventaRequisito, IFormFile ArchivoPDF)
		{
			//if (id != ventaRequisito.IdVentaRequisito)
			//{
			//	return NotFound();
			//}
			Int32 IdVentaContratacion;

			if (ModelState.IsValid)
			{
				try
				{
					String fileName = "";
					if (ArchivoPDF != null)
					{
						fileName = Path.Combine(he.WebRootPath, Path.GetFileName(ArchivoPDF.FileName));
						ArchivoPDF.CopyTo(new FileStream(fileName, FileMode.Create));
					}

					ventaRequisito.PathArchivo = fileName;
					ventaRequisito.ArchivoCargado = true;
					IdVentaContratacion = ventaRequisito.IdVentaContratacion;

					DB.Update(ventaRequisito);
					await DB.SaveChangesAsync();
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
				return RedirectToAction("Index", "VentaRequisito", new { Id = IdVentaContratacion });
			}
			return View(ventaRequisito);
		}

		//----------------------------------------------------------
		public async Task<IActionResult> Escanear(int? id, String Documento) // GET: Ventas/VentaRequisito/Edit/5
		{
			if (id == null)
			{
				return NotFound();
			}

			ViewBag.IdVentaRequisito = id;
			ViewBag.Documento = "Escanear: " + Documento;

			var ventaRequisito = await DB.Ventas_VentaRequisito.FindAsync(id);
			if (ventaRequisito == null)
			{
				return NotFound();
			}
			ViewBag.IdVentaContratacion = ventaRequisito.IdVentaContratacion;
			return View(ventaRequisito);
		}

		[HttpPost]
		public async Task<IActionResult> Upload()
		{
			Microsoft.AspNetCore.Http.IFormCollection formCollection = Request.Form;
			Microsoft.AspNetCore.Http.IFormFileCollection formFiles = formCollection.Files;

			var uploads = Path.Combine(he.WebRootPath, "docs");
			String DocsRutaNombreArchivo = "";
			//Boolean fileUploaded = false;

			var ventaRequisito =  await DB.Ventas_VentaRequisito.FindAsync(0);

			for (var i = 0; i < formFiles.Count; i++)
			{
				if (i == 0)
				{
					var file = formFiles[i];
					if (file.Length > 0)
					{
						Int32 IdVentaRequisito = Convert.ToInt32(file.FileName.Replace(".pdf",""));
						var GeneraNombreArchivo = DB.Generales_fRetornaCadena.FromSql($"SELECT * FROM \"Ventas\".\"fGeneraNombreDocumento\"({IdVentaRequisito})").ToList();
						String NombreArchivo = GeneraNombreArchivo.FirstOrDefault().Cadena;
						DocsRutaNombreArchivo += NombreArchivo;

						var filePath = Path.Combine(uploads, NombreArchivo);
						using (var fileStream = new FileStream(filePath, FileMode.Create))
						{
							await file.CopyToAsync(fileStream);
							//fileUploaded = true;
						}

						ventaRequisito = await DB.Ventas_VentaRequisito.FindAsync(IdVentaRequisito);
						ventaRequisito.PathArchivo = DocsRutaNombreArchivo;
						ventaRequisito.ArchivoCargado = true;
						DB.Update(ventaRequisito);
						await DB.SaveChangesAsync();
					}
				}
			}
			//return fileUploaded;
			return View(ventaRequisito);
		}

		public async Task<IActionResult> Regresar() 
		{
			return RedirectToAction("Index", "VentaContratacion");
		}

		public async Task<IActionResult> Enviar(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var ventaContratacion = await DB.Ventas_VentaContratacion.FirstOrDefaultAsync(m => m.IdVentaContratacion == id);
			if (ventaContratacion == null)
			{
				return NotFound();
			}

			ViewBag.IdVentaContratacion = ventaContratacion.IdVentaContratacion;

			var ValidaDocumentos = DB.Generales_fRetornaEntero.FromSql($"SELECT * FROM \"Ventas\".\"fVerificaDocumentos\"({id})").ToList();
			Int32 CodigoRetorno = ValidaDocumentos.FirstOrDefault().Entero;

			//-- 0 = 'Aun no se han generado los requisitos!!!'
			//-- 1 = 'Todos los Documentos fueron cargados!!!'
			//-- 2 = 'Falta cargar documentos!!!'
			if (CodigoRetorno == 0)
				ViewBag.Mensaje = "Aun no se han generado los requisitos!!!";
			else if (CodigoRetorno == 1)
				ViewBag.Mensaje = "Esta Seguro de enviar?";
			else
				ViewBag.Mensaje = "Falta cargar documentos!!!";

			return View(ventaContratacion);
		}

		[HttpPost, ActionName("Enviar")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> EnviarConfirmed(int id)
		{
			var ventaContratacion = await DB.Ventas_VentaContratacion.FindAsync(id);
			ventaContratacion.IdEstadoRegistro = 2;
			await DB.SaveChangesAsync();

			SetFlashInfo("El Tramite fue enviado satisfactoriamente!!!");
			return RedirectToAction("Index", "VentaContratacion");
		}

		public async Task<IActionResult> Revisado(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var ventaContratacion = await DB.Ventas_VentaContratacion.FirstOrDefaultAsync(m => m.IdVentaContratacion == id);
			if (ventaContratacion == null)
			{
				return NotFound();
			}

			ViewBag.IdVentaContratacion = ventaContratacion.IdVentaContratacion;
			ViewBag.Mensaje = "Esta Seguro de marcar como <Revisado>?";

			return View(ventaContratacion);
		}

		[HttpPost, ActionName("Revisado")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> RevisadoConfirmed(int id)
		{
			var ventaContratacion = await DB.Ventas_VentaContratacion.FindAsync(id);
			ventaContratacion.IdEstadoRegistro = 3;
			await DB.SaveChangesAsync();

			SetFlashInfo("El Tramite fue marcado como <Revisado> satisfactoriamente!!!");
			return RedirectToAction("Index", "VentaContratacion");
		}

		public async Task<IActionResult> Aprobar(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var ventaContratacion = await DB.Ventas_VentaContratacion.FirstOrDefaultAsync(m => m.IdVentaContratacion == id);
			if (ventaContratacion == null)
			{
				return NotFound();
			}

			ViewBag.IdVentaContratacion = ventaContratacion.IdVentaContratacion;
			ViewBag.Mensaje = "Esta Seguro de Aprobar?";

			return View(ventaContratacion);
		}

		[HttpPost, ActionName("Aprobar")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> AprobarConfirmed(int id)
		{
			var ventaContratacion = await DB.Ventas_VentaContratacion.FindAsync(id);
			ventaContratacion.IdEstadoRegistro = 4;
			await DB.SaveChangesAsync();

			SetFlashInfo("El Tramite fue aprobado satisfactoriamente!!!");
			return RedirectToAction("Index", "VentaContratacion");
		}

		public async Task<IActionResult> Rechazar(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var ventaContratacion = await DB.Ventas_VentaContratacion.FirstOrDefaultAsync(m => m.IdVentaContratacion == id);
			if (ventaContratacion == null)
			{
				return NotFound();
			}

			ViewBag.IdVentaContratacion = ventaContratacion.IdVentaContratacion;
			ViewBag.Mensaje = "Esta Seguro de Rechazar?";

			return View(ventaContratacion);
		}

		[HttpPost, ActionName("Rechazar")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> RechazarConfirmed(int id)
		{
			var ventaContratacion = await DB.Ventas_VentaContratacion.FindAsync(id);
			ventaContratacion.IdEstadoRegistro = 1;
			await DB.SaveChangesAsync();

			SetFlashInfo("El Tramite fue rechazado satisfactoriamente!!!");
			return RedirectToAction("Index", "VentaContratacion");
		}

		//----------------------------------------------------------
		//public async Task<IActionResult> Aprobar(int? id) // GET: Ventas/VentaRequisito/Edit/5
		//{
		//	if (id == null)
		//	{
		//		return NotFound();
		//	}

		//	var ventaRequisito = await DB.Ventas_VentaRequisito.FindAsync(id);
		//	if (ventaRequisito == null)
		//	{
		//		return NotFound();
		//	}

		//	Int32 IdVentaContratacion = ventaRequisito.IdVentaContratacion;

		//	if (!ventaRequisito.Aprobado)
		//	{
		//		if (ventaRequisito.ArchivoCargado)
		//		{
		//			ventaRequisito.Aprobado = true;
		//			DB.Update(ventaRequisito);
		//			await DB.SaveChangesAsync();
		//			SetFlashInfo("Documento aprobado satisfactoriamente");
		//		}
		//		else
		//		{
		//			SetFlashInfo("Hay que cargar en archivo antes de aprobar");
		//		}
		//	}
		//	else
		//		SetFlashWarning("El documento ya esta Aprobado");

		//	return RedirectToAction("Index", "VentaRequisito", new { Id = IdVentaContratacion });
		//}
	}
}
