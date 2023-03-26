using System;
using AutoMapper;
using MediatR;
using VeterinaryClinic.Core.Application.DTOs;
using VeterinaryClinic.Core.Application.Interfaces;
using VeterinaryClinic.Core.Application.Wrappers;
using VeterinaryClinic.Core.Domain.Entities;

namespace VeterinaryClinic.Core.Application.Features.Owners.Queries.GetOwnerbyId
{
	public class GetOwnerByIdQuery : IRequest<Response<OwnerDto>>
	{
		public int Id { get; set; }
	}

    public class GetOwnerByIdQueryHandler : IRequestHandler<GetOwnerByIdQuery, Response<OwnerDto>>
    {
        private readonly IRepositoryAsync<Owner> _repositoryAsync;
        private readonly IMapper _mapper;

        public GetOwnerByIdQueryHandler(IRepositoryAsync<Owner> repositoryAsync, IMapper mapper)
        {
            this._repositoryAsync = repositoryAsync;
            this._mapper = mapper;
        }

        public async Task<Response<OwnerDto>> Handle(GetOwnerByIdQuery request, CancellationToken cancellationToken)
        {
            var owner = await _repositoryAsync.GetByIdAsync(request.Id);
           
            if (owner == null)
            {
                throw new KeyNotFoundException($"Id {request.Id} not found");
            }
            else
            {
                var dto = _mapper.Map<OwnerDto>(owner);
                return new Response<OwnerDto>(dto);
            }
        }
    }
}

