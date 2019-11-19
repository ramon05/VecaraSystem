using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VecaraSystem.Models
{
	public class Vehiculos
	{
		public Vehiculos()
		{
			ControlAcceso = new HashSet<ControlAcceso>();
		}

		public int Id { get; set; }
		[Column("Id_Cliente")]
		public int IdCliente { get; set; }
		[Column("Id_Modelo")]
		public int IdModelo { get; set; }
		[Required]
		[StringLength(4)]
		public string Anio { get; set; }
		[Required]
		[StringLength(7)]
		public string Placa { get; set; }

		[ForeignKey("IdCliente")]
		[InverseProperty("Vehiculos")]
		public virtual Clientes ClienteId { get; set; }
		[ForeignKey("IdModelo")]
		[InverseProperty("Vehiculos")]
		public virtual Modelos ModeloId { get; set; }
		[InverseProperty("VehiculoId")]
		public virtual ICollection<ControlAcceso> ControlAcceso { get; set; }
	}
}
