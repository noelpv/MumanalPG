using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MumanalPG.Data;
using MumanalPG.Models;

namespace MumanalPG.Areas.Admin
{
    [Area("Admin")]
    public class RoleViewModelController : Controller
    {
		private RoleManager<IdentityRole> roleManagerM;

        private readonly ApplicationDbContext _context;

        public RoleViewModelController(ApplicationDbContext context, UserManager<ApplicationUser> usermanager, RoleManager<IdentityRole> rolemanager)
        {
            _context = context;
			roleManagerM = rolemanager;
        }

        public IActionResult GetAllRoles()
        {
            var roles = roleManagerM.Roles.ToList();
            var vm = new List<RoleViewModel>();
            roles.ForEach(item => vm.Add(
                new RoleViewModel()
                {
                    Id = item.Id,
                    Name = item.Name
                }
            ));
            return View(vm);
        }

        // GET: Admin/RoleViewModel
        public async Task<IActionResult> Index()
        {
            return View(await _context.RoleViewModel.ToListAsync());
        }

        // GET: Admin/RoleViewModel/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roleViewModel = await _context.RoleViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (roleViewModel == null)
            {
                return NotFound();
            }

            return View(roleViewModel);
        }

        // GET: Admin/RoleViewModel/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/RoleViewModel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] RoleViewModel roleViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(roleViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(roleViewModel);
        }

        // GET: Admin/RoleViewModel/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roleViewModel = await _context.RoleViewModel.FindAsync(id);
            if (roleViewModel == null)
            {
                return NotFound();
            }
            return View(roleViewModel);
        }

        // POST: Admin/RoleViewModel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Name")] RoleViewModel roleViewModel)
        {
            if (id != roleViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roleViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoleViewModelExists(roleViewModel.Id))
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
            return View(roleViewModel);
        }

        // GET: Admin/RoleViewModel/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roleViewModel = await _context.RoleViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (roleViewModel == null)
            {
                return NotFound();
            }

            return View(roleViewModel);
        }

        // POST: Admin/RoleViewModel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var roleViewModel = await _context.RoleViewModel.FindAsync(id);
            _context.RoleViewModel.Remove(roleViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoleViewModelExists(string id)
        {
            return _context.RoleViewModel.Any(e => e.Id == id);
        }
    }
}
