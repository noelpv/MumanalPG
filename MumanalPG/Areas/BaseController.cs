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
using MumanalPG.Extensions;
using SmartBreadcrumbs;


namespace MumanalPG.Areas
{
    public abstract class BaseController : Controller
    {
        protected ApplicationDbContext DB { get; }

        protected BaseController(ApplicationDbContext db)
        {
            DB = db;
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
    }
}