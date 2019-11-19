using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VecaraSystem.Models
{
	public class Marcas
	{
		public Marcas()
		{
			Modelos = new HashSet<Modelos>();
		}

		public int Id { get; set; }
		[Required]
		[StringLength(20)]
		public string Nombre { get; set; }

		[InverseProperty("MarcaId")]
		public virtual ICollection<Modelos> Modelos { get; set; }
	}
}
