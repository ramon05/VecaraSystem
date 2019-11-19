using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VecaraSystem.Models;

namespace VecaraSystem.Data
{
	public class ApplicationDbContext : IdentityDbContext<
		ApplicationUser, IdentityRole, string,
		IdentityUserClaim<string>, IdentityUserRole, IdentityUserLogin<string>,
		IdentityRoleClaim<string>, IdentityUserToken<string>>
	{
	
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

		public virtual DbSet<Clientes> Clientes { get; set; }
		public virtual DbSet<ControlAcceso> ControlAcceso { get; set; }
		public virtual DbSet<Empleados> Empleados { get; set; }
		public virtual DbSet<Marcas> Marcas { get; set; }
		public virtual DbSet<Modelos> Modelos { get; set; }
		public virtual DbSet<Pagos> Pagos { get; set; }
		public virtual DbSet<Parqueos> Parqueos { get; set; }
		public virtual DbSet<TipoPagos> TipoPagos { get; set; }
		public virtual DbSet<TipoParqueos> TipoParqueos { get; set; }
		public virtual DbSet<Vehiculos> Vehiculos { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
			// Customize the ASP.NET Identity model and override the defaults if needed.
			// For example, you can rename the ASP.NET Identity table names and more.
			// Add your customizations after calling base.OnModelCreating(builder);
		}
	}
}
