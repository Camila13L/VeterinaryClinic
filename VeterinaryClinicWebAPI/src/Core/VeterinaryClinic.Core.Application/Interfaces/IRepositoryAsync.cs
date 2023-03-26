using System;
using Ardalis.Specification;

namespace VeterinaryClinic.Core.Application.Interfaces
{
	public interface IRepositoryAsync<T> : IRepositoryBase<T> where T : class
	{
	}

	public interface IReadRepositoryAsync<T> : IReadRepositoryBase<T> where T : class
	{
	}
}

