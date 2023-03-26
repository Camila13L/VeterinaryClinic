using System;
namespace VeterinaryClinic.Core.Application.DTOs.Users
{
	public class AuthenticationRquest
	{
		public string Email { get; set; } = string.Empty;
		public string Password { get; set; } = string.Empty;
	}
}

