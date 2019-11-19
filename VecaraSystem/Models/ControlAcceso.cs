using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VecaraSystem.Models
{
	public class ControlAcceso
	{
		public ControlAcceso()
		{
			Pagos = new HashSet<Pagos>();
		}

		[Column("ID")]
		public int Id { get; set; }
		[Column("Id_Empleado")]
		public int IdEmpleado { get; set; }
		[Column("Id_Vehiculo")]
		public int IdVehiculo { get; set; }
		[Column("Id_Parqueo")]
		public int IdParqueo { get; set; }
		[Column(TypeName = "date")]
		public DateTime FechaEntrada { get; set; }
		[Column(TypeName = "date")]
		public DateTime? FechaSalida { get; set; }

		[ForeignKey("IdEmpleado")]
		[InverseProperty("ControlAcceso")]
		public virtual Empleados EmpleadoId { get; set; }
		[ForeignKey("IdParqueo")]
		[InverseProperty("ControlAcceso")]
		public virtual Parqueos ParqueoId { get; set; }
		[ForeignKey("IdVehiculo")]
		[InverseProperty("ControlAcceso")]
		public virtual Vehiculos VehiculoId { get; set; }
		[InverseProperty("ControlAccesoId")]
		public virtual ICollection<Pagos> Pagos { get; set; }
	}
}
