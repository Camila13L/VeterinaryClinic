
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using MediatR;
using System.Reflection;
using VeterinaryClinic.Core.Application.Behaviours;

namespace VeterinaryClinic.Core.Application
{
	// Allows to gruop injections of thirty services or owns
	public static class ServiceExtensions
	{
		public static void AddApplicationLayer(this IServiceCollection services)
		{
			//register mapings by reflextion
			services.AddAutoMapper(Assembly.GetExecutingAssembly());

			//register validators
			services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

			//register MediatR for mediator pattern
			services.AddMediatR(Assembly.GetExecutingAssembly());

			services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

		}
	}
}

