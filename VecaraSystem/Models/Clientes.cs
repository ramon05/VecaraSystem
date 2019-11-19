using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VecaraSystem.Models
{
	public class Clientes
	{
		public Clientes()
		{
			Vehiculos = new HashSet<Vehiculos>();
		}

		public int Id { get; set; }
		[Column("Id_Empleado")]
		public int IdEmpleado { get; set; }
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

		[ForeignKey("IdEmpleado")]
		[InverseProperty("Clientes")]
		public virtual Empleados Empleado_Id { get; set; }
		[InverseProperty("ClienteId")]
		public virtual ICollection<Vehiculos> Vehiculos { get; set; }
	}
}
