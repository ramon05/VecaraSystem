using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VecaraSystem.Data;
using VecaraSystem.Models;

namespace VecaraSystem.Controllers
{
	[Authorize(Roles = "Admin")]
	public class RolesController : Controller
	{
		private readonly RoleManager<IdentityRole> roleManager;
		private readonly UserManager<ApplicationUser> userManager;


		public RolesController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
		{
			this.roleManager = roleManager;
			this.userManager = userManager;
		}

		[HttpGet]
		public IActionResult CreateRole()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateRole(CreateRoleModel Model)
		{
			if (ModelState.IsValid)
			{
				IdentityRole identityRole = new IdentityRole
				{
					Name = Model.NombreRole
				};

				IdentityResult result = await roleManager.CreateAsync(identityRole);

				if (result.Succeeded)
				{
					return RedirectToAction("ListaRoles", "Roles");
				}

				foreach (IdentityError error in result.Errors)
				{
					ModelState.AddModelError("", error.Description);
				}
			}

			return View(Model);
		}

		[HttpGet]
		public IActionResult ListaRoles()
		{
			var roles = roleManager.Roles;

			return View(roles);
		}

		[HttpGet]
		public async Task<IActionResult> EditarRole(string id)
		{
			// Find the role by Role ID
			var role = await roleManager.FindByIdAsync(id);

			if (role == null)
			{
				ViewBag.ErrorMessage = $"No se puede encontrar el rol con Id = {id}";
				return View("NotFound");
			}

			var model = new EditarRoleModel
			{
				Id = role.Id,
				NombreRole = role.Name
			};

			// Recuperar todos los usuarios
			foreach (var user in userManager.Users)
			{
				// Si el usuario está en este rol, agregue el nombre de usuario a
				// Propiedad de los usuarios de EditarRoleModel. Este modelo
				// el objeto se pasa a la vista para su visualización
				if (await userManager.IsInRoleAsync(user, role.Name))
				{
					model.Users.Add(user.UserName);
				}
			}

			return View(model);
		}

		// Esta acción responde a HttpPost y recibe EditarRoleModel
		[HttpPost]
		public async Task<IActionResult> EditarRole(EditarRoleModel model)
		{
			var role = await roleManager.FindByIdAsync(model.Id);

			if (role == null)
			{
				ViewBag.ErrorMessage = $"No se puede encontrar el rol con Id = {model.Id}";
				return View("NotFound");
			}
			else
			{
				role.Name = model.NombreRole;

				// Actualice el rol usando UpdateAsync
				var result = await roleManager.UpdateAsync(role);

				if (result.Succeeded)
				{
					return RedirectToAction("ListaRoles");
				}

				foreach (var error in result.Errors)
				{
					ModelState.AddModelError("", error.Description);
				}

				return View(model);
			}
		}

		[HttpGet]
		public async Task<IActionResult> EditarUsuarioEnRol(string roleId)
		{
			ViewBag.roleId = roleId;

			var role = await roleManager.FindByIdAsync(roleId);

			if (role == null)
			{
				ViewBag.ErrorMessage = $"No se puede encontrar el rol con Id = {roleId}";
				return View("NotFound");
			}

			var model = new List<UserRolerModel>();

			foreach (var user in userManager.Users)
			{
				var userRolewModel = new UserRolerModel
				{
					UserId = user.Id,
					UserName = user.UserName
				};

				if (await userManager.IsInRoleAsync(user, role.Name))
				{
					userRolewModel.IsSelected = true;
				}
				else
				{
					userRolewModel.IsSelected = false;
				}

				model.Add(userRolewModel);
			}

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> EditarUsuarioEnRol(List<UserRolerModel> model, string roleId)
		{
			var role = await roleManager.FindByIdAsync(roleId);

			if (role == null)
			{
				ViewBag.ErrorMessage = $"No se puede encontrar el rol con Id = {roleId}";
				return View("NotFound");
			}

			for (int i = 0; i < model.Count; i++)
			{
				var user = await userManager.FindByIdAsync(model[i].UserId);

				IdentityResult result = null;

				if (model[i].IsSelected && !(await userManager.IsInRoleAsync(user, role.Name)))
				{
					result = await userManager.AddToRoleAsync(user, role.Name);
				}
				else if (!model[i].IsSelected && await userManager.IsInRoleAsync(user, role.Name))
				{
					result = await userManager.RemoveFromRoleAsync(user, role.Name);
				}
				else
				{
					continue;
				}

				if (result.Succeeded)
				{
					if (i < (model.Count - 1))
						continue;
					else
						return RedirectToAction("EditarRole", new { Id = roleId });
				}
			}

			return RedirectToAction("EditarRole", new { Id = roleId });
		}
	}
}
