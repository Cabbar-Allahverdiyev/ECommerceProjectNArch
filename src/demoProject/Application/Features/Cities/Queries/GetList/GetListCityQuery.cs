using Application.Features.Cities.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.Cities.Constants.CitiesOperationClaims;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Cities.Queries.GetList;

public class GetListCityQuery : IRequest<GetListResponse<GetListCityListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }
    public GetListCityQuery()
    {
        PageRequest = new PageRequest { PageIndex = 0, PageSize = 10 };
    }

    public GetListCityQuery(PageRequest pageRequest)
    {
        PageRequest = pageRequest;
    }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListCities({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetCities";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListCityQueryHandler : IRequestHandler<GetListCityQuery, GetListResponse<GetListCityListItemDto>>
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;

        public GetListCityQueryHandler(ICityRepository cityRepository, IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListCityListItemDto>> Handle(GetListCityQuery request, CancellationToken cancellationToken)
        {
            IPaginate<City> cities = await _cityRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                include: c => c.Include(c => c.Companies).Include(c => c.Country),
                enableTracking: false,
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListCityListItemDto> response = _mapper.Map<GetListResponse<GetListCityListItemDto>>(cities);
            return response;
        }
    }
}