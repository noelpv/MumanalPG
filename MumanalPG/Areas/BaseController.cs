using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
using Npgsql.EntityFrameworkCore.PostgreSQL.Storage.Internal.Mapping;
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
    }
}