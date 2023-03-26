using System;
using AutoMapper;
using MediatR;
using VeterinaryClinic.Core.Application.Interfaces;
using VeterinaryClinic.Core.Application.Wrappers;
using VeterinaryClinic.Core.Domain.Entities;

namespace VeterinaryClinic.Core.Application.Features.Owners.Commands.CreateOwnerCommand
{
	//The medidator executes redirections to the implementation
	public class CreateOwnerCommand : IRequest<Response<int>>
	{
        public string FullName { get; set; } = string.Empty;
        public int CI { get; set; } = 0;
        public string Adress { get; set; } = string.Empty;
        public int Contact { get; set; } = 0;
        public string Email { get; set; } = string.Empty;
        
        //public string Name { get; set; } = string.Empty;
        //public DateTime BirthDate { get; set; }
        //public Sexes Sexes { get; set; }
        //public string Race { get; set; } = string.Empty;
        //public Species Species { get; set; }
        //public string Color { get; set; } = string.Empty;
        //public double Weight { get; set; } = 0.0;
    }

    public class CreateOwnerCommandHandler : IRequestHandler<CreateOwnerCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Owner> _respositoryAsync;
        private readonly IMapper _mapper;

        public CreateOwnerCommandHandler(IRepositoryAsync<Owner> repositoryAsync, IMapper mapper)
        {
            this._respositoryAsync = repositoryAsync;
            this._mapper = mapper;
        }
        public async Task<Response<int>> Handle(CreateOwnerCommand request, CancellationToken cancellationToken)
        {
            var newReport = _mapper.Map<Owner>(request);
            var data = await _respositoryAsync.AddAsync(newReport);
            return new Response<int>(data.Id);
        }
    }
}

