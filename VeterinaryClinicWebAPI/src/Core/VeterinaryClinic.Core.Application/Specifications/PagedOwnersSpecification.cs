using System;
using Ardalis.Specification;
using VeterinaryClinic.Core.Domain.Entities;

namespace VeterinaryClinic.Core.Application.Specifications
{
	public class PagedOwnersSpecification : Specification<Owner>
	{
		public PagedOwnersSpecification(int pageNumber, int pageSize, string fullName)
		{
			Query.Skip((pageNumber - 1) * pageSize)
				 .Take(pageSize);

			if (!string.IsNullOrEmpty(fullName))
			{
				Query.Search(x => x.FullName, "%" + fullName + "%");
			}
		}
	}
}

