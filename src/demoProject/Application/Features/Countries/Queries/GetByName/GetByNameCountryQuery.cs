using Application.Features.Countries.Constants;
using Application.Features.Countries.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static Application.Features.Countries.Constants.CountriesOperationClaims;

namespace Application.Features.Countries.Queries.GetByName;

public class GetByNameCountryQuery : IRequest<GetByNameCountryResponse>//, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest
{
    public string? Name { get; set; }

    public string[] Roles => new[] { Admin, Read, CountriesOperationClaims.GetByNameCountry };

    public bool BypassCache { get; }
    public string CacheKey => $"GetByNameCountry";
    public string CacheGroupKey => "GetCountries";
    public TimeSpan? SlidingExpiration { get; }
    
    public class GetByNameCountryQueryHandler : IRequestHandler<GetByNameCountryQuery, GetByNameCountryResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICountryRepository _countryRepository;
        private readonly CountryBusinessRules _countryBusinessRules;

        public GetByNameCountryQueryHandler(IMapper mapper, CountryBusinessRules countryBusinessRules,ICountryRepository countryRepository)
        {
            _mapper = mapper;
            _countryRepository = countryRepository;
            _countryBusinessRules = countryBusinessRules;
        }

        public async Task<GetByNameCountryResponse> Handle(GetByNameCountryQuery request, CancellationToken cancellationToken)
        {
            Country? country = await _countryRepository.GetAsync(
                predicate: c => string.Equals(c.Name, request.Name, StringComparison.OrdinalIgnoreCase),
                cancellationToken: cancellationToken,
                include: c => c.Include(c => c.Cities),
                enableTracking: false);
            await _countryBusinessRules.CountryShouldExistWhenSelected(country);

            GetByNameCountryResponse response = _mapper.Map<GetByNameCountryResponse>(country);
            return response;
        }
    }
}
