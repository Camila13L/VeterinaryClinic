using System;
using MediatR;
using VeterinaryClinic.Core.Application.DTOs.Users;
using VeterinaryClinic.Core.Application.Interfaces;
using VeterinaryClinic.Core.Application.Wrappers;

namespace VeterinaryClinic.Core.Application.Features.Users.Commands.AuthenticateUser
{
	public class AuthenticateCommand : IRequest<Response<AuthenticationResponse>>
	{
		public string Email { get; set; } = string.Empty;
		public string Password { get; set; } = string.Empty;
		public string IpAddress { get; set; } = string.Empty;
	}

    public class AuthenticateUserCommandHandler : IRequestHandler<AuthenticateCommand, Response<AuthenticationResponse>>
    {
        private readonly IAccountservice _accountservice;

        public AuthenticateUserCommandHandler(IAccountservice accountservice)
        {
            _accountservice = accountservice;
        }

        public async Task<Response<AuthenticationResponse>> Handle(AuthenticateCommand request, CancellationToken cancellationToken)
        {
            return await _accountservice.AuthenticateAsync(new AuthenticationRquest
            {
                Email = request.Email,
                Password = request.Password
            }, request.IpAddress);
        }
    }
}

