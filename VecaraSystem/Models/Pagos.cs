using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VecaraSystem.Models
{
	public class Pagos
	{
		public int Id { get; set; }
		[Column("Id_TipoPago")]
		public int IdTipoPago { get; set; }
		[Column("Id_ControlAcceso")]
		public int IdControlAcceso { get; set; }
		[Column(TypeName = "decimal(10, 2)")]
		public decimal Monto { get; set; }
		[Column(TypeName = "date")]
		public DateTime Fecha { get; set; }

		[ForeignKey("IdControlAcceso")]
		[InverseProperty("Pagos")]
		public virtual ControlAcceso ControlAccesoId { get; set; }
		[ForeignKey("IdTipoPago")]
		[InverseProperty("Pagos")]
		public virtual TipoPagos TipoPagoId { get; set; }
	}
}
