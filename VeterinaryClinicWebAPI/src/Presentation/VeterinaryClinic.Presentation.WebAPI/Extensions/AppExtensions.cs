using System;
using VeterinaryClinic.Presentation.WebAPI.Middlewares;

namespace VeterinaryClinic.Presentation.WebAPI.Extensions
{
	public static class AppExtensions
	{
		public static void UseErrorHandlingMiddleware(this IApplicationBuilder app)
		{
			app.UseMiddleware<ErrorHandlerMiddleware>();
		}

    }
}

