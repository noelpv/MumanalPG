using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MumanalPG.Models;
using MumanalPG.Data;
using Microsoft.EntityFrameworkCore;
using MumanalPG.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Internal;
using Microsoft.EntityFrameworkCore.Query.Internal;
using MumanalPG.Extensions;
using MumanalPG.Models.Correspondencia;
using MumanalPG.Models.Correspondencia.DTO;
using MumanalPG.Models.RRHH;
using Npgsql.EntityFrameworkCore.PostgreSQL.Storage.Internal.Mapping;
using Remotion.Linq.Clauses;
using SmartBreadcrumbs;


namespace MumanalPG.Areas
{
    public abstract class BaseController : Controller
    {
        protected ApplicationDbContext DB { get; }
        private readonly UserManager<IdentityUser> _userManager;


        protected BaseController(ApplicationDbContext db)
        {
            DB = db;
        }
        
        protected BaseController(ApplicationDbContext db, UserManager<IdentityUser> userManager)
        {
            DB = db;
            _userManager = userManager;
        }

        private void SetFlash(string msgType, string msg)
        {
            TempData["FlashMsgType"] = msgType;
            TempData["FlashMsg"] = msg;
        }

        public void SetFlashInfo(string msg)
        {
            SetFlash("info", msg);
        }
        
        public void SetFlashSuccess(string msg)
        {
            SetFlash("success", msg);
        }
        public void SetFlashWarning(string msg)
        {
            SetFlash("warning", msg);
        }
        public void SetFlashError(string msg)
        {
            SetFlash("error", msg);
        }

        public void ShowFlash(string a)
        {
            switch (a)
            {
                case Constantes.Creado:
                    SetFlashSuccess("Registro creado satisfactoriamente");
                    break;
                case Constantes.Modificado:
                    SetFlashSuccess("Registro modificado satisfactoriamente");
                    break;
                case Constantes.Eliminado:
                    SetFlashSuccess("Registro eliminado satisfactoriamente");
                    break;
               
            }
        }

        public async Task<ApplicationUser> GetCurrentUser()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);

            ApplicationUser currentUser = DB.ApplicationUser
                .Include(u => u.Funcionario)
                .Include(u => u.Funcionario.Puesto)
                .Include(u => u.Funcionario.Puesto.UnidadEjecutora)
                .FirstOrDefault(u => u.Id == user.Id);
          
            return currentUser;
        }
        
        public async Task<string> GetCite(int uEjecutoraId)
        {

            List<string> cites = await GetCiteList(uEjecutoraId);
            cites.Reverse();
            string citesStr = String.Join("/", cites.ToArray());
            return $"MUMANAL/{citesStr}";
        }

        public async Task<List<string>> GetCiteList(int uEjecutoraId, List<string> cites = null)
        {
            var unidadEjecutora = await DB.RRHH_UnidadEjecutora.FindAsync(uEjecutoraId);
            if (cites == null)
            {
                cites = new List<string>();
            }

            if (unidadEjecutora != null)
            {
                cites.Add(unidadEjecutora.Sigla);
                if (unidadEjecutora.IdUnidadEjecutoraPadre > 0)
                {
                    cites = await GetCiteList(unidadEjecutora.IdUnidadEjecutoraPadre, cites);
                }
            }

            return cites;
        }
        
        public async Task<List<AreasFunTreeDTO>> GetAreas(int currentFunId = 0)
        {

            List<AreasFunTreeDTO> areas = await GetAreasList("GG", null, currentFunId);
            //areas.Reverse();
            
            return areas;
        }

        public async Task<List<AreasFunTreeDTO>> GetAreasList(string uSigla, List<AreasFunTreeDTO> areas = null, int currentFunId = 0)
        {
            var unidadEjecutora = await DB.RRHH_UnidadEjecutora.FirstOrDefaultAsync(a => a.Sigla == uSigla);
            if (areas == null)
            {
                areas = new List<AreasFunTreeDTO>();
            }

            if (unidadEjecutora != null)
            {
                var nodeRaiz = await DB.RRHH_UnidadEjecutora.FirstOrDefaultAsync(a => a.Sigla == "GG");
                AreasFunTreeDTO area = new AreasFunTreeDTO();
                area.areaId = unidadEjecutora.IdUnidadEjecutora;
                area.id = $"area_{unidadEjecutora.IdUnidadEjecutora}";
                area.text = unidadEjecutora.Descripcion;
                area.parent = (unidadEjecutora.IdUnidadEjecutoraPadre == 0) ? "#" : $"area_{unidadEjecutora.IdUnidadEjecutoraPadre}";
//                area.icon = "ti-folder";
                if (unidadEjecutora.IdUnidadEjecutoraPadre == nodeRaiz.IdUnidadEjecutora || 
                    unidadEjecutora.IdUnidadEjecutora == nodeRaiz.IdUnidadEjecutora)
                {
                    area.state = new {opened = true, disabled = false, selected = false};
                }
                areas.Add(area);

                var funcionarios = DB.RRHH_Beneficiario
                    .Include(b => b.Puesto)
                    .Where(b => b.PuestoId > 0)
                    .Where(b => b.Puesto.IdUnidadEjecutora == unidadEjecutora.IdUnidadEjecutora)
                    .OrderBy(b => b.Denominacion).ToList();

                foreach (var f in funcionarios)
                {
                    if (f.IdBeneficiario != currentFunId)
                    {
                        AreasFunTreeDTO fun = new AreasFunTreeDTO();
                        fun.areaId = unidadEjecutora.IdUnidadEjecutora;
                        fun.funId = f.IdBeneficiario;
                        fun.id = $"fun_{f.IdBeneficiario}";
                        fun.text = $"<span class='small jstree-text'>{f.Denominacion}<div class='ml-5'><b>({f.Puesto.Descripcion})</b></div></span>";
                        fun.parent = area.id;
                        fun.icon = "/lib/theme-elegant/img/users/user-male-iconx24.png";
                        areas.Add(fun);
                    }
                }

                var children = DB.RRHH_UnidadEjecutora
                        .Where(a => a.IdUnidadEjecutoraPadre == unidadEjecutora.IdUnidadEjecutora)
                        .Where(a => a.IdEstadoRegistro != Constantes.Anulado)
                        .OrderBy(a => a.Descripcion)
                        .ToList();
                
                foreach (var child in children)
                {
                    areas = await GetAreasList(child.Sigla, areas);
                }
            }

            return areas;
        }

        public IList<Instrucciones> GetInstrucciones()
        {
            var instrucciones = DB.CorrespondenciaInstrucciones
                .Where(i => i.IdEstadoRegistro != Constantes.Anulado)
                .OrderBy(i => i.Nombre).ToList();

            return instrucciones;
        }

        public JsonResult GetFuncionarios(string filter = "")
        {
            if (filter.Length > 2)
            {
                var beneficiarios = DB.RRHH_Beneficiario
                    .Include(b => b.Puesto)
                    .Where(b => b.PuestoId > 1)
                    .Where(b => (b.IdEstadoRegistro != Constantes.Anulado || b.IdEstadoRegistro == null))
                    .Where(b => EF.Functions.ILike(b.Denominacion, "%" + filter + "%") || EF.Functions.ILike(b.Puesto.Descripcion, "%" + filter + "%"))
                    .OrderBy(d => d.Denominacion).Take(20)
                    .Select(c => new {Id=c.IdBeneficiario, Nombre = c.Denominacion, cargo = c.Puesto.Descripcion, 
                        area = c.Puesto.UnidadEjecutora.Descripcion, areaId = c.Puesto.UnidadEjecutora.IdUnidadEjecutora})
                    .ToList(); 
                
                return Json(new {repositories = beneficiarios});
            }
            else
            {
                return Json(new {repositories = new {}});
            }
        }
    }
}