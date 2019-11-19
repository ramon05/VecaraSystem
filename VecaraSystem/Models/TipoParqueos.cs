using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VecaraSystem.Models
{
	public class TipoParqueos
	{
		public TipoParqueos()
		{
			Parqueos = new HashSet<Parqueos>();
		}

		public int Id { get; set; }
		[Required]
		[StringLength(10)]
		public string Nombre { get; set; }
		[Required]
		[StringLength(10)]
		public string Longitud { get; set; }

		[InverseProperty("TipoParqueoId")]
		public virtual ICollection<Parqueos> Parqueos { get; set; }
	}
}
