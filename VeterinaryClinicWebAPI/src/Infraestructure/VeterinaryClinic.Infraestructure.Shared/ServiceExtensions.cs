using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VeterinaryClinic.Core.Application.Interfaces;
using VeterinaryClinic.Infraestructure.Shared.Services;

namespace VeterinaryClinic.Infraestructure.Shared
{
	public static class ServiceExtensions
	{
        public static void AddSharedInfraestructure(this IServiceCollection services, IConfiguration configuration)
        {
			services.AddTransient<IDateTimeService, DateTimeService>(); 
		}
	}
}

