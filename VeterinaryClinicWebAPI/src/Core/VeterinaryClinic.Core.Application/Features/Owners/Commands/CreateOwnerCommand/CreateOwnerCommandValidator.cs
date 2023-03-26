using System;
using System.Text.RegularExpressions;
using FluentValidation;

namespace VeterinaryClinic.Core.Application.Features.Owners.Commands.CreateOwnerCommand
{
    public class CreateOwnerCommandValidator : AbstractValidator<CreateOwnerCommand>
	{
		public CreateOwnerCommandValidator()
		{
			RuleFor(p => p.FullName)
				.NotEqual(String.Empty).WithMessage("Name cannot be empty")
				.NotEmpty().WithMessage("Fullname required")
				.MaximumLength(80).WithMessage("Fullname Maximun length {MaxLength}");

			RuleFor(p => p.CI)
				.NotEmpty().WithMessage("{PropertyName} required")
				.Must(p => p.ToString().Length >= 7).WithMessage("{PropertyValue} is not an indentification");
			//crear validador de existencia

			RuleFor(p => p.Adress)
				.NotEqual(String.Empty).WithMessage("{PropertyName} cannot be empty")
				.NotEmpty().WithMessage("{PropertyName} requiered")
				.MaximumLength(150).WithMessage("{PropertyName} Maximun length {MaxLength}");

			RuleFor(p => p.Contact)
				.NotEmpty().WithMessage("{PropertyName} requiered")
				.Must(p => p.ToString().Length == 8).WithMessage("{PropertyValue} is not a telephone number");

			RuleFor(p => p.Email)
				.NotEqual(String.Empty).WithMessage("{PropertyName} cannot be empty")
				.NotEmpty().WithMessage("{PropertyName} requiered")
				.EmailAddress().WithMessage("Is not an {PropertyValue}")
				.MaximumLength(90).WithMessage("{PropertyName} Maximun length {MaxLength}");
		}
	}
}

