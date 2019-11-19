using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VecaraSystem.Models
{
	public class Empleados
	{
		public Empleados()
		{
			Clientes = new HashSet<Clientes>();
			ControlAcceso = new HashSet<ControlAcceso>();
		}

		public int Id { get; set; }
		[Required]
		[StringLength(100)]
		public string Nombre { get; set; }
		[Required]
		[StringLength(100)]
		public string Apellido { get; set; }
		[Required]
		[StringLength(200)]
		public string Direccion { get; set; }
		[Required]
		[StringLength(11)]
		public string Cedula { get; set; }
		[Required]
		[StringLength(10)]
		public string Telefono { get; set; }
		public string UsuarioId { get; set; }
		public ApplicationUser Usuario { get; set; }

		[InverseProperty("Empleado_Id")]
		public virtual ICollection<Clientes> Clientes { get; set; }
		[InverseProperty("EmpleadoId")]
		public virtual ICollection<ControlAcceso> ControlAcceso { get; set; }
	}
}
