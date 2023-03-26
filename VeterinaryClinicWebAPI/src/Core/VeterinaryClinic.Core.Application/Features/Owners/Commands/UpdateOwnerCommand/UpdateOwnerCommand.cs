using System;
using AutoMapper;
using MediatR;
using VeterinaryClinic.Core.Application.Exceptions;
using VeterinaryClinic.Core.Application.Interfaces;
using VeterinaryClinic.Core.Application.Wrappers;
using VeterinaryClinic.Core.Domain.Entities;

namespace VeterinaryClinic.Core.Application.Features.Owners.Commands.UpdateOwnerCommand
{
    public class UpdateOwnerCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public int CI { get; set; } = 0;
        public string Adress { get; set; } = string.Empty;
        public int Contact { get; set; } = 0;
        public string Email { get; set; } = string.Empty;
    }
    public class UpdateOwnerCommandHandler : IRequestHandler<UpdateOwnerCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Owner> _respositoryAsync;
        private readonly IMapper _mapper;

        public UpdateOwnerCommandHandler(IRepositoryAsync<Owner> repositoryAsync, IMapper mapper)
        {
            _respositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(UpdateOwnerCommand request, CancellationToken cancellationToken)
        {
            var owner = await _respositoryAsync.GetByIdAsync(request.Id);
            if (owner == null)
            {
                throw new KeyNotFoundException($"Id {request.Id} not found");
            }
            else
            {
                owner.FullName = request.FullName;
                owner.CI = request.CI;
                owner.Adress = request.Adress;
                owner.Contact = request.Contact;
                owner.Email = request.Email;

                await _respositoryAsync.UpdateAsync(owner);
                return new Response<int>(owner.Id);

            }
        }
    }
}

