using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VecaraSystem.Models
{
	public class UserRolerModel
	{
		public string UserId { get; set; }
		public string RoleId { get; set; }
		public string UserName { get; set; }
		public bool IsSelected { get; set; }
	}
}
