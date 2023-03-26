using System;
using AutoMapper;
using FluentValidation;
using MediatR;
using VeterinaryClinic.Core.Application.Exceptions;
using VeterinaryClinic.Core.Application.Interfaces;
using VeterinaryClinic.Core.Application.Wrappers;
using VeterinaryClinic.Core.Domain.Entities;

namespace VeterinaryClinic.Core.Application.Features.Owners.Commands.UpdateOwnerCommand
{
    public class UpdateOwnerCommandValidator : AbstractValidator<UpdateOwnerCommand>
    {
        public UpdateOwnerCommandValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty().WithErrorCode("Please, enter an Id")
                .Must(p => p >= 0).WithMessage("{PropertyName} must be positive");
            RuleFor(p => p.FullName)
                .NotEqual(String.Empty).WithMessage("Name cannot be empty")
                .NotEmpty().WithMessage("Fullname required")
                .MaximumLength(80).WithMessage("Fullname Maximun length {MaxLength}");

            RuleFor(p => p.CI)
                .NotEmpty().WithMessage("{PropertyName} required")
                .Must(p => p.ToString().Length >= 7).WithMessage("{PropertyValue} is not an indentification");

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