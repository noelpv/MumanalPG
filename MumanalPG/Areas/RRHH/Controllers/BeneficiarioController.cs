using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Dynamic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using MumanalPG.Data;
using MumanalPG.Models;
using MumanalPG.Utility;
using ReflectionIT.Mvc.Paging;
using SmartBreadcrumbs;
using MumanalPG.Extensions;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;
using Microsoft.AspNetCore.Razor.Language.Extensions;


namespace MumanalPG.Areas.RRHH.Controllers
{
    [Authorize(Roles = SD.RecursosHumanosAccess)]
    [Area("RRHH")]
    public class BeneficiarioController : BaseController
    {
        public BeneficiarioController(ApplicationDbContext db, UserManager<IdentityUser> userManager) : base(db,
            userManager)
        {
        }

        // GET: RRHH/Beneficiario
        [Breadcrumb("Funcionarios", FromController = "DashboardRRHH", FromAction = "Index")]
        public async Task<IActionResult> Index(string filter, int page = 1, string sortExpression = "Denominacion",
            string a = "")
        {
            var consulta = DB.RRHH_Beneficiario.AsNoTracking().AsQueryable();
            consulta = consulta.Include(b => b.Puesto);
            consulta = consulta.Where(m =>
                m.IdEstadoRegistro != 2); //!= Constantes.Eliminado); // != el estado es diferente a ANULADO
            consulta = consulta.Where(b =>
                b.PuestoId > 1); //Puesto > 1 quiere decir que es un funcionario y no un beneficiario   

            if (!string.IsNullOrWhiteSpace(filter))
            {
                consulta = consulta.Where(m => EF.Functions.ILike(m.Denominacion, $"%{filter}%"));
            }

            var resp = await PagingList.CreateAsync(consulta, Constantes.TamanoPaginacion * 2, page, sortExpression,
                "Denominacion");
            resp.RouteValue = new RouteValueDictionary {{"filter", filter}};
            // ShowFlash(a);
            return View(resp);
        }

        // GET: RRHH/Beneficiario/Details/5
        public async Task<IActionResult> Details(Int32? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await DB.RRHH_Beneficiario.Include(b => b.Puesto)
                .FirstOrDefaultAsync(m => m.IdBeneficiario == id);
            if (item == null)
            {
                return NotFound();
            }

            return PartialView("Details", item);
        }

        // GET: RRHH/Beneficiario/Create
        public IActionResult Create()
        {
            var model = new Models.RRHH.Beneficiario();
            model.RolUsuario = "4c7e18e8-0305-42ed-ade3-ab1640f7b00e"; //Normal
            model.Password = "User123*";

            var unidades = DB.RRHH_UnidadEjecutora
                .Where(i => i.IdEstadoRegistro != Constantes.Anulado && i.EsExterna == false)
                .OrderBy(i => i.Descripcion).ToList();

            var puestos = DB.RRHH_Puesto.Where(p => p.IdEstadoRegistro != Constantes.Anulado)
                .OrderBy(i => i.Descripcion).ToList();

            var roles = DB.Roles.Where(r => r.Name != SD.SuperAdminEndUser)
                .OrderBy(r => r.Name).ToList();


            ViewBag.Unidades = unidades;
            ViewBag.Puestos = puestos;
            ViewBag.Roles = roles;

            return PartialView("Create", model);
        }

        // POST: RRHH/Beneficiario/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Models.RRHH.Beneficiario item)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser currentUser = await GetCurrentUser();
                item.IdUsuario = currentUser.AspNetUserId;
                item.IdBeneficiarioClasificacion = 2;
                item.Nit = "0";
                item.Iniciales = "NN";
                item.IdDocumentoRespaldo = 0;
                item.FechaNacimiento = DateTime.Now;
                item.IdGenero = 0;
                item.TelefonoFijo = "0";
                item.TelefonoOficina = "0";
                item.EmailPersonal = "";
                item.EmailOficina = "";
                item.DomicilioLegal = "";
                item.IdBarrio = 0;
                item.IdCalle = 0;
                item.IdMunicipio = 0;
                item.IdEdificio = 0;
                item.EdificioNumero = "0";
                item.EdificioNumeroPiso = "0";
                item.EdificioNumeroDepto = "0";
                item.EsDeudor = "NO";
                item.EsHabilitado = false;
                item.FechaRegistro = DateTime.Now;
                item.IdEstadoRegistro = Constantes.Registrado;
                item.Denominacion =
                    $"{item.PrimerApellido} {item.SegundoApellido} {item.PrimerNombre} {item.SegundoNombre}";
                DB.Add(item);
                await DB.SaveChangesAsync();
                var ben = DB.RRHH_Beneficiario.FirstOrDefault(b => b.DocumentoIdentidad == item.DocumentoIdentidad);
                if (ben != null)
                {
                    var user = new ApplicationUser
                    {
                        UserName = item.Username, Email = item.Email, Name = item.Denominacion, EmailConfirmed = true,
                        AspNetUserId = ben.IdBeneficiario
                    };
                    var userCreated = await _userManager.CreateAsync(user, "User123*"); // <- Creacion de Usuario

                    if (userCreated.Succeeded)
                    {
                        var role_name = DB.Roles.FirstOrDefault(i => i.Id == item.RolUsuario).ToString();
                        await _userManager.AddToRoleAsync(user, role_name); // <- Asignacion de rol
                    }
                }

                SetFlashSuccess("Registro creado satisfactoriamente");
            }

            //Puesto
            var unidades = DB.RRHH_UnidadEjecutora
                .Where(i => i.IdEstadoRegistro != Constantes.Anulado && i.EsExterna == false)
                .OrderBy(i => i.Descripcion).ToList();

            var puestos = DB.RRHH_Puesto.Where(p => p.IdEstadoRegistro != Constantes.Anulado)
                .OrderBy(i => i.Descripcion).ToList();

            var roles = DB.Roles.Where(r => r.Name != SD.SuperAdminEndUser)
                .OrderBy(r => r.Name).ToList();

            ViewBag.Unidades = unidades;
            ViewBag.Puestos = puestos;
            ViewBag.Roles = roles;

            return PartialView("Create", item);
        }

        // GET: RRHH/Beneficiario/Edit/5
        public async Task<IActionResult> Edit(Int32? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await DB.RRHH_Beneficiario.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            //Esto es solo para evitar la validacion no se modificara nada
            item.Username = "username";
            item.Email = "nomail@mail.com";
            item.Password = "password";

            var unidades = DB.RRHH_UnidadEjecutora
                .Where(i => i.IdEstadoRegistro != Constantes.Anulado && i.EsExterna == false)
                .OrderBy(i => i.Descripcion).ToList();

            var puestos = DB.RRHH_Puesto.Where(p => p.IdEstadoRegistro != Constantes.Anulado)
                .OrderBy(i => i.Descripcion).ToList();


            ViewBag.Unidades = unidades;
            ViewBag.Puestos = puestos;

            return PartialView("Edit", item);
        }

        // POST: RRHH/Beneficiario/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        ///public async Task<IActionResult> Edit(Int32 id, [Bind("IdBeneficiario,Denominacion,PrimerApellido, SegundoApellido,PrimerNombre, SegundoNombre,PuestoId")] Models.RRHH.Beneficiario item)
        public async Task<IActionResult> Edit(Int32 id, Models.RRHH.Beneficiario item)
        {
            if (id != item.IdBeneficiario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    ApplicationUser currentUser = await GetCurrentUser();
                    item.IdUsuario = currentUser.AspNetUserId;
                    item.IdBeneficiarioClasificacion = 2;
                    item.Nit = "0";
                    item.Iniciales = "NN";
                    item.IdDocumentoRespaldo = 0;
                    item.FechaNacimiento = DateTime.Now;
                    item.IdGenero = 0;
                    item.TelefonoFijo = "0";
                    item.TelefonoOficina = "0";
                    item.EmailPersonal = "";
                    item.EmailOficina = "";
                    item.DomicilioLegal = "";
                    item.IdBarrio = 0;
                    item.IdCalle = 0;
                    item.IdMunicipio = 0;
                    item.IdEdificio = 0;
                    item.EdificioNumero = "0";
                    item.EdificioNumeroPiso = "0";
                    item.EdificioNumeroDepto = "0";
                    item.EsDeudor = "NO";
                    item.EsHabilitado = false;
                    item.FechaRegistro = DateTime.Now;
                    item.Denominacion =
                        $"{item.PrimerApellido} {item.SegundoApellido} {item.PrimerNombre} {item.SegundoNombre}";
                    DB.Update(item);
                    await DB.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemExists(item.IdBeneficiario))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            var unidades = DB.RRHH_UnidadEjecutora
                .Where(i => i.IdEstadoRegistro != Constantes.Anulado && i.EsExterna == false)
                .OrderBy(i => i.Descripcion).ToList();

            var puestos = DB.RRHH_Puesto.Where(p => p.IdEstadoRegistro != Constantes.Anulado)
                .OrderBy(i => i.Descripcion).ToList();


            ViewBag.Unidades = unidades;
            ViewBag.Puestos = puestos;

            return PartialView("Edit", item);
        }

        // GET: RRHH/Beneficiario/Delete/5
        public async Task<IActionResult> Delete(Int32? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await DB.RRHH_Beneficiario.FirstOrDefaultAsync(m => m.IdBeneficiario == id);
            if (item == null)
            {
                return NotFound();
            }

            return PartialView("Delete", item);
        }

        // POST: RRHH/Beneficiario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Int32 id)
        {
            var item = await DB.RRHH_Beneficiario.FindAsync(id);
            item.IdEstadoRegistro = 2; //Constantes.Eliminado ;
            DB.RRHH_Beneficiario.Update(item);
            await DB.SaveChangesAsync();
            return PartialView("Delete", item);
        }

        // GET: RRHH/Beneficiario/ResetPassword/5
        public async Task<IActionResult> ResetPassword(Int32? id)
        {
            if (id == null)
            {
                return View("_NoEncontrado");
            }

            var item = await DB.RRHH_Beneficiario.Include(b => b.AspNetUser)
                .FirstOrDefaultAsync(m => m.IdBeneficiario == id);
            if (item == null)
            {
                return View("_NoEncontrado");
            }

            item.Username = item.AspNetUser.UserName;
            item.Email = item.AspNetUser.Email;
            return PartialView("ResetPassword", item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(Int32 id, Models.RRHH.Beneficiario item)
        {
            if (id != item.IdBeneficiario)
            {
                return View("_NoEncontrado");
            }

            var ben = await DB.RRHH_Beneficiario.Include(b => b.AspNetUser)
                .FirstOrDefaultAsync(m => m.IdBeneficiario == id);


            if (ModelState.IsValid)
            {
                var user = ben.AspNetUser;

                // Generate the reset token (this would generally be sent out as a query parameter as part of a 'reset' link in an email)
                string resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);

                // Use the reset token to verify the provenance of the reset request and reset the password.
                IdentityResult updateResult = await _userManager.ResetPasswordAsync(user, resetToken, item.Password);
                
                user.LastChangedPassword = null;
                DB.ApplicationUser.Update(user);
                await DB.SaveChangesAsync();

            }

            return PartialView("ResetPassword", item);
        }


        private bool ItemExists(Int32 id)
        {
            return DB.RRHH_Beneficiario.Any(e => e.IdBeneficiario == id);
        }
    }
}