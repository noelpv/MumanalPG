using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MumanalPG.Models.Planificacion
{
    [Table("TiposBeneficiario", Schema = "Planificacion")]
    public class TipoBeneficiario
    {
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Denominacion { get; set; }

        [Required]
        public bool Activo { get; set; }
    }
}
