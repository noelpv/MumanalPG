using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using MumanalPG.Models.RRHH;
using MumanalPG.Utility;

namespace MumanalPG.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "Nombre Usuario")]
        public string Name { get; set; }

        public Int32 IdUsuario { get; set; }
        
        public int AspNetUserId { get; set; }
        [ForeignKey("AspNetUserId")]
        public Beneficiario Funcionario { get; set; }

        public static bool IsSuperAdmin(ClaimsPrincipal User)
        {
            return User.IsInRole(SD.SuperAdminEndUser);
        }
        
        public static bool IsAdmin(ClaimsPrincipal User)
        {
            return User.IsInRole(SD.SuperAdminEndUser) || User.IsInRole(SD.AdminEndUser);
        }
        
        public static bool IsRecursosHumanos(ClaimsPrincipal User)
        {
            return User.IsInRole(SD.SuperAdminEndUser) || User.IsInRole(SD.AdminEndUser) || User.IsInRole(SD.RecursosHumanos);
        }
        
        public static bool IsVentanillaUnica(ClaimsPrincipal User)
        {
            return User.IsInRole(SD.SuperAdminEndUser) || User.IsInRole(SD.AdminEndUser) || User.IsInRole(SD.VentanillaUnicaUser);
        }
        
        public static bool IsSecretaria(ClaimsPrincipal User)
        {
            return User.IsInRole(SD.SuperAdminEndUser) || User.IsInRole(SD.AdminEndUser) || User.IsInRole(SD.SecretariaUser);
        }
        
        public static bool IsPrestaciones(ClaimsPrincipal User)
        {
            return User.IsInRole(SD.SuperAdminEndUser) || User.IsInRole(SD.AdminEndUser) || User.IsInRole(SD.Prestaciones);
        }
    }
}
