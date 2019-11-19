using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VecaraSystem.Models
{
	public class EditarRoleModel
	{
		public EditarRoleModel()
		{
			Users = new List<string>();
		}

		public string Id { get; set; }

		[Required(ErrorMessage ="El Nombre del Rol es Obligatorio")]
		public string NombreRole { get; set; }

		public List<string> Users { get; set; }

	}
}
