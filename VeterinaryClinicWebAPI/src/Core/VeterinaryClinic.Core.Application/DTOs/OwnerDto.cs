using System;
namespace VeterinaryClinic.Core.Application.DTOs
{
	public class OwnerDto
	{
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public int CI { get; set; } = 0;
        public string Adress { get; set; } = string.Empty;
        public int Contact { get; set; } = 0;
        public string Email { get; set; } = string.Empty;
	}
}

