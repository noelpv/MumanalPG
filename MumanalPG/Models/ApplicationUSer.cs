using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MumanalPG.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "Nombre Usuario")]
        public string Name { get; set; }

        [NotMapped]
        public bool IsSuperAdmin { get; set; }
        
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public Int32 IdUsuario { get; set; }
    }
}
