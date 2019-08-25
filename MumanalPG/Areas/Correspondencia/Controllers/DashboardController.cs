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

namespace MumanalPG.Areas.Correspondencia.Controllers
{
    //[Authorize(Roles = SD.SuperAdminEndUser)]
    [Authorize]
    [Area("Correspondencia")]
    public class DashboardController : BaseController
    {        
		public DashboardController(ApplicationDbContext db): base(db)
        {
        }

		// GET: Planificacion/TipoBeneficiarios
        [Breadcrumb("Correspondencia")]
        public IActionResult Index()
        { 
            return View();
        }

        [Breadcrumb("Clasificadores", FromAction = "Index")]
        public IActionResult Clasificadores()
        {
            return View();
        }
        
        [Breadcrumb("Documentos", FromAction = "Index")]
        public async Task<IActionResult> Docs()
        {
            var consulta = DB.CorrespondenciaTipoDocumento.AsNoTracking().AsQueryable();
            consulta = consulta.Where(m => m.IdEstadoRegistro != Constantes.Anulado);
            
            var resp = await PagingList.CreateAsync(consulta, 100, 1, "Nombre", "Nombre");
            //resp.RouteValue = new RouteValueDictionary {{ "filter", filter}};
            return View(resp);
        }


        public IActionResult RemoteDropdown()
        {
            return View("RemoteDropdown");
        }
        
        public JsonResult ListaUnidadesEjecutoras(string filter = "")
        {
            if (filter.Length > 2)
            {
                var unidades = DB.RRHH_UnidadEjecutora
                    .Where(b => (b.IdEstadoRegistro != Constantes.Anulado || b.IdEstadoRegistro == null))
                    .Where(b => EF.Functions.ILike(b.Descripcion, "%" + filter + "%") || EF.Functions.ILike(b.Sigla, "%" + filter + "%"))
                    .OrderBy(d => d.Descripcion).Take(20)
                    .Select(c => new {Id=c.IdUnidadEjecutora, Nombre = c.Descripcion, c.Sigla})
                    .ToList(); 
                
                return Json(new {repositories = unidades});
            }
            else
            {
                return Json(new {repositories = new {}});
            }
        }
    }
    
    
}
