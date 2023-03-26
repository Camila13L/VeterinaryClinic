using System;
using System.Net;
using System.Text.Json;
using VeterinaryClinic.Core.Application.Wrappers;

namespace VeterinaryClinic.Presentation.WebAPI.Middlewares
{
	public class ErrorHandlerMiddleware
	{
		private readonly RequestDelegate _next;
		public ErrorHandlerMiddleware(RequestDelegate next)
		{
			this._next = next;
		}

		public async Task Invoke(HttpContext context)
		{
			try
			{
				await _next(context);
			}
			catch (Exception error)
			{
				var response = context.Response;
				response.ContentType = "application/json";
				var responseModel = new Response<string>() {
					Succeeded = false,
                    Message = error.Message,
				};

				switch (error)
				{
					case Core.Application.Exceptions.ApiException e:
						//custom application error API
						response.StatusCode = (int)HttpStatusCode.BadRequest;
						break;
                    case Core.Application.Exceptions.ValidationException e:
                        //Custom aplication error
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
						responseModel.Error = e.Errors;
                        break;
					case KeyNotFoundException e:
                        //not found error
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    default:
                        //unhandle error
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;

                        break;
				}

				var result = JsonSerializer.Serialize(responseModel);
				await response.WriteAsync(result);
			}
		}
	}
}

