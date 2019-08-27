using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MumanalPG.Data;
using MumanalPG.Models;
using MumanalPG.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using MumanalPG.Models.Seguridad;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MumanalPG.Areas.Admin.Controllers
{
    [Authorize(Roles = SD.SuperAdminEndUser)]  // aqui se limita aun rol x
    [Area("Admin")]
	public class AdminUsersController : Controller
    {

        private readonly ApplicationDbContext _db;
		//UserManager<ApplicationUser> _userManager;
		//RoleManager<IdentityRole> _roleManager;
		//UsuarioRole _usuarioRole;
		//public List<SelectListItem> usuarioRole;

		//public AdminUsersController(ApplicationDbContext db, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
		public AdminUsersController(ApplicationDbContext db)
		{
			_db = db;
			//_userManager = userManager;
			//_roleManager = roleManager;
			//_usuarioRole = new UsuarioRole();
			//usuarioRole = new List<SelectListItem>();
        }

        public IActionResult Index()
        {
            return View(_db.ApplicationUser.ToList());
        }

		//public async Task<IActionResult> Index2()
		//{
		//	var ID = "";
		//	List<Usuario> usuario = new List<Usuario>();
		//	var appUsuario = _db.ApplicationUser.ToList();
		//	foreach (var Data in appUsuario)
		//	{
		//		ID = Data.Id;
		//		usuarioRole = await _usuarioRole.GetRole(_userManager, _roleManager, ID);
		//	}

		//	return View(usuario.ToList());
		//}

		//Get Edit
		public async Task<IActionResult> Edit(string id)
        {
            if(id==null || id.Trim().Length==0)
            {
                return NotFound();
            }

            var userFromDb = await _db.ApplicationUser.FindAsync(id);
            if(userFromDb==null)
            {
                return NotFound();
            }

            return View(userFromDb);
        }


        //Post Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit (string id, ApplicationUser applicationUser)
        {
            if(id!=applicationUser.Id)
            {
                return NotFound();
            }

            if(ModelState.IsValid)
            {
                ApplicationUser userFromDb = _db.ApplicationUser.Where(u => u.Id == id).FirstOrDefault();
                userFromDb.Name = applicationUser.Name;
                userFromDb.PhoneNumber = applicationUser.PhoneNumber;

                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(applicationUser);
        }


        //Get Delete
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || id.Trim().Length == 0)
            {
                return NotFound();
            }

            var userFromDb = await _db.ApplicationUser.FindAsync(id);
            if (userFromDb == null)
            {
                return NotFound();
            }

            return View(userFromDb);
        }


        //Post Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePOST(string id)
        {
                ApplicationUser userFromDb = _db.ApplicationUser.Where(u => u.Id == id).FirstOrDefault();
                userFromDb.LockoutEnd= DateTime.Now.AddYears(1000);

                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
        }
	}
}