using System;
using VeterinaryClinic.Core.Application.Interfaces;

namespace VeterinaryClinic.Infraestructure.Shared.Services
{
	public class DateTimeService : IDateTimeService
	{

		public DateTime NowUtc => DateTime.UtcNow;
		
	}
}

