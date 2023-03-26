using System;
namespace VeterinaryClinic.Core.Application.Interfaces
{
	public interface IDateTimeService
	{
		DateTime NowUtc { get; }
	}
}

