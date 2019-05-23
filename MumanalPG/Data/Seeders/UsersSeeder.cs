using System;
using MumanalPG.Models.RRHH;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using MumanalPG.Models;
using MumanalPG.Utility;

namespace MumanalPG.Data.Seeders
{
    public class UsersSeeder
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public UsersSeeder(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public void SeedData()
        {

            var userAdmin = _context.ApplicationUser.FirstOrDefault(a => a.UserName == "admin@gmail.com");
            if (userAdmin != null)
            {
                var firstUser = _context.ApplicationUser.FirstOrDefault(a => a.IdUsuario == 1);
                if (firstUser != null)
                {
                    firstUser.IdUsuario = userAdmin.IdUsuario;
                    userAdmin.IdUsuario = 1;
                    _context.ApplicationUser.Update(firstUser);
                    _context.ApplicationUser.Update(userAdmin);
                    
                }
            }

            var beneficiarios =  _context.RRHH_Beneficiario
                .Include(b => b.Puesto).Where(b => b.PuestoId > 1)
                .OrderBy(b => b.IdBeneficiario)
                .ToList();

            foreach (var b in beneficiarios)
            {
                if (b.Puesto.Descripcion.Contains("Secretaria General"))
                {
                    AgregarUser(SD.VentanillaUnicaUser, b);
                    
                } else if (b.Puesto.Descripcion.Contains("Secretaria"))
                {
                    AgregarUser(SD.SecretariaUser, b);
                }
                else
                {
                    AgregarUser(SD.DefaultUser, b);
                }

            }
            
            _context.SaveChanges();  
        }

        // since we run this seeder when the app starts
        // we should avoid adding duplicates, so check first
        // then add
        private void AgregarUser(string rol, Beneficiario ben)
        {
            string apellido = ben.PrimerApellido != null ? ben.PrimerApellido : ben.SegundoApellido; 
            string username = $"{ben.PrimerNombre.ToLower()}.{apellido.ToLower()}@mumanal.org";
            
            IdentityRole role = _context.Roles.FirstOrDefault(r => r.Name == rol);
            IdentityUser user =  _context.Users.FirstOrDefault(u => u.UserName == username);
            if (user == null)
            {
                var userCreated = _userManager.CreateAsync(new ApplicationUser
                {
                    UserName = username,
                    Email = username,
                    Name = ben.Denominacion,
                    EmailConfirmed = true
                }, "User123*").GetAwaiter().GetResult();
                
                if (userCreated.Succeeded && role != null)
                {
                    user =  _context.Users.FirstOrDefault(u => u.UserName == username);
                   
                    var userRole = new IdentityUserRole<string>();
                    userRole.UserId = user.Id;
                    userRole.RoleId = role.Id;
                    _context.UserRoles.Add(userRole);
                    //await _userManager.AddToRoleAsync(user, rol);
                }

            }
            else
            {
                IdentityUserRole<string> userRole = _context.UserRoles.FirstOrDefault(u => u.UserId == user.Id);
                
                if (userRole == null)
                {
                    userRole = new IdentityUserRole<string>();
                    userRole.UserId = user.Id;
                    userRole.RoleId = role.Id;
                   _context.UserRoles.Add(userRole);
                }
                else
                {
                    userRole.UserId = user.Id;
                    userRole.RoleId = role.Id;
                    _context.UserRoles.Update(userRole);
                }
            }
            
            ApplicationUser currentUser = _context.ApplicationUser.FirstOrDefault(u => u.Id == user.Id);

            if (currentUser != null)
            {
                ben.IdUsuario = currentUser.IdUsuario;
                _context.RRHH_Beneficiario.Update(ben);  
            }
        }
    }
}