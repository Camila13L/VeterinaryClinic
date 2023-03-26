using System;
using AutoMapper;
using MediatR;
using VeterinaryClinic.Core.Application.Exceptions;
using VeterinaryClinic.Core.Application.Interfaces;
using VeterinaryClinic.Core.Application.Wrappers;
using VeterinaryClinic.Core.Domain.Entities;

namespace VeterinaryClinic.Core.Application.Features.Owners.Commands.DeleteOwnerCommand
{
	public class DeleteOwnerCommand : IRequest<Response<int>>
    {
		public int Id { get; set; }
	}

    public class DeleteOwnerCommandHandler : IRequestHandler<DeleteOwnerCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Owner> _respositoryAsync;
        private readonly IMapper _mapper;

        public DeleteOwnerCommandHandler(IRepositoryAsync<Owner> respositoryAsync, IMapper mapper)
        {
            _respositoryAsync = respositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(DeleteOwnerCommand request, CancellationToken cancellationToken)
        {
            var owner = await _respositoryAsync.GetByIdAsync(request.Id);
            if (owner == null)
            {
                throw new KeyNotFoundException($"Id {request.Id} not found");
            }
            else
            {
                await _respositoryAsync.DeleteAsync(owner);
                return new Response<int>(owner.Id);
            }
        }
    }
}

