using Application.Features.Countries.Constants;
using Application.Features.Countries.Rules;
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
using static Application.Features.Countries.Constants.CountriesOperationClaims;

namespace Application.Features.Countries.Queries.GetListByDynamicCountry;

public class GetListByDynamicCountryQuery : IRequest<GetListResponse<GetListByDynamicCountryItemDto>>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest
{
    public PageRequest PageRequest { get; set; }
    public DynamicQuery DynamicQuery { get; set; }

    public GetListByDynamicCountryQuery()
    {
        PageRequest = new PageRequest { PageIndex = 0, PageSize = 10 };
    }

    public GetListByDynamicCountryQuery(PageRequest pageRequest, DynamicQuery dynamicQuery)
    {
        PageRequest = pageRequest;
        DynamicQuery = dynamicQuery;
    }

    public string[] Roles => new[] { Admin, Read, CountriesOperationClaims.GetListByDynamicCountry };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListByDynamicCountry";
    public string CacheGroupKey => "GetCountries";
    public TimeSpan? SlidingExpiration { get; }
    
    public class GetListByDynamicCountryQueryHandler : IRequestHandler<GetListByDynamicCountryQuery, GetListResponse<GetListByDynamicCountryItemDto>>
    {
        private readonly IMapper _mapper;
        private readonly CountryBusinessRules _countryBusinessRules;
        private readonly ICountryRepository _countryRepository;

        public GetListByDynamicCountryQueryHandler(IMapper mapper,
                                                   CountryBusinessRules countryBusinessRules,
                                                   ICountryRepository countryRepository)
        {
            _mapper = mapper;
            _countryBusinessRules = countryBusinessRules;
            _countryRepository = countryRepository;
        }

        public async Task<GetListResponse<GetListByDynamicCountryItemDto>> Handle(GetListByDynamicCountryQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Country> countries = await _countryRepository.GetListByDynamicAsync(
                           dynamic: request.DynamicQuery,
                           index: request.PageRequest.PageIndex,
                           size: request.PageRequest.PageSize,
                           include: c=>c.Include(c=>c.Cities),
                           cancellationToken: cancellationToken,
                           enableTracking: false
                       );
            GetListResponse<GetListByDynamicCountryItemDto> response = _mapper.Map<GetListResponse<GetListByDynamicCountryItemDto>>(countries);
            return response;
        }
    }
}
