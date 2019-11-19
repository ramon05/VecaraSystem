using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VecaraSystem.Models
{
	public class TipoPagos
	{
		public TipoPagos()
		{
			Pagos = new HashSet<Pagos>();
		}

		public int Id { get; set; }
		[Required]
		[StringLength(10)]
		public string Nombre { get; set; }

		[InverseProperty("TipoPagoId")]
		public virtual ICollection<Pagos> Pagos { get; set; }
	}
}

