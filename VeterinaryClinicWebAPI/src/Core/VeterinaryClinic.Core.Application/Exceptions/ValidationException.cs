using System;
using FluentValidation.Results;
using FluentValidation;

namespace VeterinaryClinic.Core.Application.Exceptions
{
	public class ValidationException : Exception
	{

        public List<string> Errors { get; }

        public ValidationException() : base("Validation Errors Found")
		{
            Errors = new List<string>();
		}

		public ValidationException(IEnumerable<ValidationFailure> failures) : this()
		{
			foreach (var failure in failures)
			{
				this.Errors.Add(failure.ErrorMessage);
			}
		}
	}
}

