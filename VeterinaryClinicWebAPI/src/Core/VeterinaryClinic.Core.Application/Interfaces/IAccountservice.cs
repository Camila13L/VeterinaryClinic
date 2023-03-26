using System;
using System.Threading.Tasks;
using VeterinaryClinic.Core.Application.DTOs.Users;
using VeterinaryClinic.Core.Application.Wrappers;

namespace VeterinaryClinic.Core.Application.Interfaces
{
	public interface IAccountservice
	{
		Task<Response<AuthenticationResponse>> AuthenticateAsync(AuthenticationRquest authenticationRquest, string ipAddres);
		Task<Response<string>> RegisterAsync(RegisterRequest request, string origin);
	}
}

