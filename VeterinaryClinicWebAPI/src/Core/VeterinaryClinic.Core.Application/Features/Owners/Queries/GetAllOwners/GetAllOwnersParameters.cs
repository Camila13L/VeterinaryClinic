using System;
using VeterinaryClinic.Core.Application.Parameters;

namespace VeterinaryClinic.Core.Application.Features.Owners.Queries.GetAllOwners
{
	public class GetAllOwnersParameters : RequestParameters
	{
		public string FullName { get; set; } = string.Empty;
	}
}

