using System;
using Ardalis.Specification.EntityFrameworkCore;
using VeterinaryClinic.Core.Application.Interfaces;
using VeterinaryClinic.Infraestructure.Persistence.Context;

namespace VeterinaryClinic.Infraestructure.Persistence.Repository
{
	public class MyRepositoryAsync<T> : RepositoryBase<T>, IRepositoryAsync<T> where T : class
	{
		private readonly ApplicationDbContext dbContext;

		public MyRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
		{
			this.dbContext = dbContext;
		}
	}
}

