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
using MumanalPG.Extensions;
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
            ApplicationUser currentUser = await DB.ApplicationUser.Where(u => u.Id == user.Id).FirstOrDefaultAsync();
            return currentUser;
        }
    }
}