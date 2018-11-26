using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MumanalPG.Data;
using MumanalPG.Models.AdministraParam;

namespace MumanalPG.Areas.AdministraParam.Controllers
{
    [Area("AdministraParam")]
    public class SubGrupoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SubGrupoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AdministraParam/SubGrupo
        public async Task<IActionResult> Index()
        {
            return View(await _context.SubGrupo.ToListAsync());
        }

        // GET: AdministraParam/SubGrupo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subGrupo = await _context.SubGrupo
                .FirstOrDefaultAsync(m => m.IdSubgrupo == id);
            if (subGrupo == null)
            {
                return NotFound();
            }

            return View(subGrupo);
        }

        // GET: AdministraParam/SubGrupo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdministraParam/SubGrupo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSubgrupo,Descripcion,IdGrupo")] SubGrupo subGrupo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(subGrupo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(subGrupo);
        }

        // GET: AdministraParam/SubGrupo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subGrupo = await _context.SubGrupo.FindAsync(id);
            if (subGrupo == null)
            {
                return NotFound();
            }
            return View(subGrupo);
        }

        // POST: AdministraParam/SubGrupo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdSubgrupo,Descripcion,IdGrupo")] SubGrupo subGrupo)
        {
            if (id != subGrupo.IdSubgrupo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subGrupo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubGrupoExists(subGrupo.IdSubgrupo))
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
            return View(subGrupo);
        }

        // GET: AdministraParam/SubGrupo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subGrupo = await _context.SubGrupo
                .FirstOrDefaultAsync(m => m.IdSubgrupo == id);
            if (subGrupo == null)
            {
                return NotFound();
            }

            return View(subGrupo);
        }

        // POST: AdministraParam/SubGrupo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subGrupo = await _context.SubGrupo.FindAsync(id);
            _context.SubGrupo.Remove(subGrupo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubGrupoExists(int id)
        {
            return _context.SubGrupo.Any(e => e.IdSubgrupo == id);
        }
    }
}
