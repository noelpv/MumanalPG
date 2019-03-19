using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MumanalPG.Models.Seguridad
{
	[Table("UsuarioUnidadEjecutora", Schema = "Seguridad")]
	public class UsuarioUnidadEjecutora
	{
		[Key]
		public Int16 IdUsuario { get; set; }
		//[Key]
		public Int32 IdUnidadEjecutora { get; set; }
	}
}
