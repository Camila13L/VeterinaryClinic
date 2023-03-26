using System;
using Identity.Models;
using Microsoft.AspNetCore.Identity;
using VeterinaryClinic.Core.Application.Enums;

namespace Identity.Seeds
{
	public static class DefaultRoles
	{
		public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
		{
			//Seed roles
			await roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
			await roleManager.CreateAsync(new IdentityRole(Roles.Basic.ToString()));


		}
	}
}

