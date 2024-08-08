using Application.Features.Cities.Constants;
using Application.Features.Cities.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static Application.Features.Cities.Constants.CitiesOperationClaims;

namespace Application.Features.Cities.Queries.GetListByDynamicCity;

public class GetListByDynamicCityQuery : IRequest<GetListResponse<GetListByDynamicCityItemDto>>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest
{
    public PageRequest PageRequest { get; set; }
    public DynamicQuery DynamicQuery { get; set; }

    public GetListByDynamicCityQuery()
    {
        PageRequest = new PageRequest { PageIndex = 0, PageSize = 10 };
    }

    public GetListByDynamicCityQuery(PageRequest pageRequest, DynamicQuery dynamicQuery)
    {
        PageRequest = pageRequest;
        DynamicQuery = dynamicQuery;
    }

    public string[] Roles => new[] { Admin, Read, CitiesOperationClaims.GetListByDynamicCity };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListByDynamicCity";
    public string CacheGroupKey => "GetCities";
    public TimeSpan? SlidingExpiration { get; }
    
    public class GetListByDynamicCityQueryHandler : IRequestHandler<GetListByDynamicCityQuery, GetListResponse<GetListByDynamicCityItemDto>>
    {
        private readonly IMapper _mapper;
        private readonly ICityRepository _cityRepository;
        private readonly CityBusinessRules _cityBusinessRules;

        public GetListByDynamicCityQueryHandler(IMapper mapper,
                                                    CityBusinessRules cityBusinessRules,
                                                ICityRepository cityRepository)
        {
            _mapper = mapper;
            _cityBusinessRules = cityBusinessRules;
            _cityRepository = cityRepository;
        }

        public async Task<GetListResponse<GetListByDynamicCityItemDto>> Handle(GetListByDynamicCityQuery request,
                                                                               CancellationToken cancellationToken)
        {
            IPaginate<City> cities = await _cityRepository.GetListByDynamicAsync(
                request.DynamicQuery,
                include: c => c.Include(c => c.Companies).Include(c => c.Country),
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                enableTracking:true,
                cancellationToken:cancellationToken
                );

            GetListResponse<GetListByDynamicCityItemDto>? response = _mapper.Map<GetListResponse<GetListByDynamicCityItemDto>>(cities);
            return response;
        }
    }
}
