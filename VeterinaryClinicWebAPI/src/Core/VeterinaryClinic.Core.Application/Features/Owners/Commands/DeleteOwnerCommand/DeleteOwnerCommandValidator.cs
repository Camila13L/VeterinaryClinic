using System;
using FluentValidation;

namespace VeterinaryClinic.Core.Application.Features.Owners.Commands.DeleteOwnerCommand
{
	public class DeleteOwnerCommandValidator : AbstractValidator<DeleteOwnerCommand>
    {

		public DeleteOwnerCommandValidator()
		{
			RuleFor(p => p.Id)
				.NotEmpty().WithErrorCode("Please, enter an Id")
				.Must(p => p >= 0).WithMessage("{PropertyName} must be positive");
		}
	}
}

