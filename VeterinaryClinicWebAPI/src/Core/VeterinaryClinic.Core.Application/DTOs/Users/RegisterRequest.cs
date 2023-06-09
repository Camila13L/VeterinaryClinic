﻿using System;
namespace VeterinaryClinic.Core.Application.DTOs.Users
{
	public class RegisterRequest
	{
		public string Name { get; set; } = string.Empty;
		public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
		public string UserName { get; set; } = string.Empty;
		public string Password { get; set; } = string.Empty;
		public string ConfirmPassword { get; set; } = string.Empty;
    }
}

