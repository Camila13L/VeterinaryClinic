using System;
using AutoMapper;
using VeterinaryClinic.Core.Application.DTOs;
using VeterinaryClinic.Core.Application.Features.Owners.Commands.CreateOwnerCommand;
using VeterinaryClinic.Core.Domain.Entities;

namespace VeterinaryClinic.Core.Application.Mapping
{
	public class GeneralProfile : Profile
	{

		public GeneralProfile()
		{
			#region DTOs
			CreateMap<Owner, OwnerDto>();
			#endregion

			#region Commands
			CreateMap<CreateOwnerCommand, Owner>();
			#endregion
		}
    }
}

