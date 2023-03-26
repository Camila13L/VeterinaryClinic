using System;

namespace VeterinaryClinic.Core.Domain.Common
{
	public abstract class AuditableBaseEntity
	{
		public virtual int  Id { get; set; }
		public string CreatedBy { get; set; } = string.Empty;
		public DateTime Created { get; set; }
		public string LastModifiedBy { get; set; } = string.Empty;
		public DateTime? LastModified { get; set; }

	}
}

