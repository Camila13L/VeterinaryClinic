using System;
using VeterinaryClinic.Core.Domain.Common;

namespace VeterinaryClinic.Core.Domain.Entities
{
	public class Owner : AuditableBaseEntity
	{
        public string FullName { get; set; } = string.Empty;
        public int CI { get; set; } = 0;
        public string Adress { get; set; } = string.Empty;
        public int Contact { get; set; } = 0;
        public string Email { get; set; } = string.Empty;
    }
}

