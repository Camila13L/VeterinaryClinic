using System;
using System.Text;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using VeterinaryClinic.Core.Application.DTOs;
using VeterinaryClinic.Core.Application.Interfaces;
using VeterinaryClinic.Core.Application.Specifications;
using VeterinaryClinic.Core.Application.Wrappers;
using VeterinaryClinic.Core.Domain.Entities;

namespace VeterinaryClinic.Core.Application.Features.Owners.Queries.GetAllOwners
{
	public class GetAllOwnersQuery : IRequest<PagedResponse<List<OwnerDto>>>
	{
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string FullName { get; set; } = string.Empty;
    }

    public class GetAllOwnersQueryHandler : IRequestHandler<GetAllOwnersQuery, PagedResponse<List<OwnerDto>>>
    {
        private readonly IRepositoryAsync<Owner> _repositoryAsync;
        private readonly IDistributedCache _distributerCahche;
        private readonly IMapper _mapper;



        public GetAllOwnersQueryHandler(IRepositoryAsync<Owner> repositoryAsync, IMapper mapper, IDistributedCache distributerCahche)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
            _distributerCahche = distributerCahche;
        }

        public async Task<PagedResponse<List<OwnerDto>>> Handle(GetAllOwnersQuery request, CancellationToken cancellationToken)
        {

            var cacheKey = $"OwnerList_{request.PageNumber}_{request.PageSize}_{request.FullName}";
            string serializedOwnersList;
            var ownerlist = new List<Owner>();

            var redisOwnersList = await _distributerCahche.GetAsync(cacheKey);

            if (redisOwnersList != null)
            {
                serializedOwnersList = Encoding.UTF8.GetString(redisOwnersList);
                ownerlist = JsonConvert.DeserializeObject<List<Owner>>(serializedOwnersList);
            }
            else
            {
                ownerlist = await _repositoryAsync.ListAsync(new PagedOwnersSpecification(request.PageNumber, request.PageSize, request.FullName));
                serializedOwnersList = JsonConvert.SerializeObject(ownerlist);
                redisOwnersList = Encoding.UTF8.GetBytes(serializedOwnersList);

                var options = new DistributedCacheEntryOptions()
                    .SetAbsoluteExpiration(DateTime.Now.AddMinutes(10))
                    .SetSlidingExpiration(TimeSpan.FromMinutes(2));

                await _distributerCahche.SetAsync(cacheKey, redisOwnersList, options);
            }

            var ownersDto = _mapper.Map<List<OwnerDto>>(ownerlist);

            return new PagedResponse<List<OwnerDto>>(ownersDto, request.PageNumber, request.PageSize);
        }
    }
}

