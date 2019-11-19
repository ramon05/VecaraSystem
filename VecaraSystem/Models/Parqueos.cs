using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VecaraSystem.Models
{
	public class Parqueos
	{
		public Parqueos()
		{
			ControlAcceso = new HashSet<ControlAcceso>();
		}

		public int Id { get; set; }
		[Column("Id_TipoParqueo")]
		public int IdTipoParqueo { get; set; }
		[Required]
		[StringLength(10)]
		public string Disponibilidad { get; set; }

		[ForeignKey("IdTipoParqueo")]
		[InverseProperty("Parqueos")]
		public virtual TipoParqueos TipoParqueoId { get; set; }
		[InverseProperty("ParqueoId")]
		public virtual ICollection<ControlAcceso> ControlAcceso { get; set; }
	}
}
