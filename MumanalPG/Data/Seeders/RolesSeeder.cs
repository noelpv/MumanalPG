using System;
using MumanalPG.Models.RRHH;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using MumanalPG.Utility;

namespace MumanalPG.Data.Seeders
{
    public class RolesSeeder
    {
        private readonly ApplicationDbContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;
        public RolesSeeder(ApplicationDbContext context, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _roleManager = roleManager;
        }

        public void SeedData()
        {
            AgregarRol(SD.DefaultUser);
            AgregarRol(SD.VentanillaUnicaUser);
            AgregarRol(SD.SecretariaUser);
            AgregarRol(SD.AdminEndUser);
            AgregarRol(SD.RecursosHumanos);
            AgregarRol(SD.Prestaciones);
        }

        // since we run this seeder when the app starts
        // we should avoid adding duplicates, so check first
        // then add
        private void AgregarRol(string rol)
        {
            if (_context.Roles.Any(r => r.Name == rol)) return;

            _roleManager.CreateAsync(new IdentityRole(rol)).GetAwaiter().GetResult();
        }
    }
}