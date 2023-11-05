using Application.Features.Cities.Constants;
using Application.Features.Cities.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static Application.Features.Cities.Constants.CitiesOperationClaims;

namespace Application.Features.Cities.Queries.GetByNameCity;

public class GetByNameCityQuery : IRequest<GetByNameCityResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest
{
    public string? Name { get; set; }
    public string[] Roles => new[] { Admin, Read, CitiesOperationClaims.GetByNameCity };

    public bool BypassCache { get; }
    public string CacheKey => $"GetByNameCity";
    public string CacheGroupKey => "GetCities";
    public TimeSpan? SlidingExpiration { get; }

    public class GetByNameCityQueryHandler : IRequestHandler<GetByNameCityQuery, GetByNameCityResponse>
    {
        private readonly IMapper _mapper;
        private readonly CityBusinessRules _cityBusinessRules;
        private readonly ICityRepository _cityRepository;

        public GetByNameCityQueryHandler(IMapper mapper, CityBusinessRules cityBusinessRules, ICityRepository cityRepository)
        {
            _mapper = mapper;
            _cityBusinessRules = cityBusinessRules;
            _cityRepository = cityRepository;
        }

        public async Task<GetByNameCityResponse> Handle(GetByNameCityQuery request, CancellationToken cancellationToken)
        {
            City? city = await _cityRepository.GetAsync(
                predicate: c => string.Equals(c.Name, request.Name, StringComparison.OrdinalIgnoreCase),
                cancellationToken: cancellationToken,
                 include: c => c.Include(c => c.Companies).Include(c => c.Country)
                //enableTracking: false
                );
            await _cityBusinessRules.CityShouldExistWhenSelected(city);

            GetByNameCityResponse response = _mapper.Map<GetByNameCityResponse>(city);
            return response;
        }
    }
}
