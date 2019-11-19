using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VecaraSystem.Models
{
	public class Modelos
	{
		public Modelos()
		{
			Vehiculos = new HashSet<Vehiculos>();
		}

		public int Id { get; set; }
		[Required]
		[StringLength(20)]
		public string Nombre { get; set; }
		[Column("Id_Marca")]
		public int IdMarca { get; set; }

		[ForeignKey("IdMarca")]
		[InverseProperty("Modelos")]
		public virtual Marcas MarcaId { get; set; }
		[InverseProperty("ModeloId")]
		public virtual ICollection<Vehiculos> Vehiculos { get; set; }
	}
}
