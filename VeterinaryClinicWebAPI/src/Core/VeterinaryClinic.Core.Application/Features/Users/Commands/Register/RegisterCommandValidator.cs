using System;
using FluentValidation;
using VeterinaryClinic.Core.Application.Features.Users.Commands.RegisterUser;

namespace VeterinaryClinic.Core.Application.Features.Users.Commands.Register
{
	public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
	{
		public RegisterCommandValidator()
		{
			RuleFor(p => p.Name)
				.NotEmpty().WithMessage("{PropertyName} required")
				.MaximumLength(80).WithMessage("{PropertyName} max length {MaxLength}");

			RuleFor(p => p.Email)
				.NotEmpty().WithMessage("{PropertyName} required")
				.EmailAddress().WithMessage("{PropertyName} is not an email")
				.MaximumLength(100).WithMessage("{PropertyName} max length {MaxLength}");

            RuleFor(p => p.UserName)
                .NotEmpty().WithMessage("{PropertyName} required")
                .MaximumLength(10).WithMessage("{PropertyName} max length {MaxLength}");

            RuleFor(p => p.Password)
                .NotEmpty().WithMessage("{PropertyName} required")
                .MaximumLength(15).WithMessage("{PropertyName} max length {MaxLength}")
				.MinimumLength(8).WithMessage("{PropertyName} must have at least {PropertyValue} characters");

            RuleFor(p => p.ConfirmPassword)
                .NotEmpty().WithMessage("{PropertyName} required")
                .MaximumLength(15).WithMessage("{PropertyName} max length {MaxLength}")
                .MinimumLength(8).WithMessage("{PropertyName} must have at least {PropertyValue} characters")
                .Equal(p => p.Password).WithMessage("Passwords are different");


        }
    }
}

