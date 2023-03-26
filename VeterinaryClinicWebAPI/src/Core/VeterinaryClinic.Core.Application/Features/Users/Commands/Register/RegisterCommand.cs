using System;
using MediatR;
using VeterinaryClinic.Core.Application.DTOs.Users;
using VeterinaryClinic.Core.Application.Interfaces;
using VeterinaryClinic.Core.Application.Wrappers;

namespace VeterinaryClinic.Core.Application.Features.Users.Commands.RegisterUser
{
	public class RegisterCommand : IRequest<Response<string>>
	{
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string ConfirmPassword { get; set; } = string.Empty;
        public string Origin { get; set; } = string.Empty;
    }
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, Response<string>>
    {
        private readonly IAccountservice _accountservice;

        public RegisterCommandHandler(IAccountservice accountservice)
        {
            _accountservice = accountservice;
        }

        public async Task<Response<string>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            return await _accountservice.RegisterAsync(new RegisterRequest
            {
                Email = request.Email,
                Password = request.Password,
                ConfirmPassword = request.ConfirmPassword,
                UserName = request.UserName,
                Name = request.Name,
                LastName = request.LastName
            }, request.Origin);
        }
    }
}

