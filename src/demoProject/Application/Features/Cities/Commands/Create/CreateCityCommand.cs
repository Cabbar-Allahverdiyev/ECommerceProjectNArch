using Application.Features.Cities.Constants;
using Application.Features.Cities.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Cities.Constants.CitiesOperationClaims;

namespace Application.Features.Cities.Commands.Create;

public class CreateCityCommand : IRequest<CreatedCityResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public string? Name { get; set; }
    public Guid CountryId { get; set; }

    public CreateCityCommand()
    {
        Name = string.Empty;
    }

    public CreateCityCommand(string? name, Guid countryId) 
    {
        CountryId = countryId;
        Name = name;
    }

    public string[] Roles => new[] { Admin, Write, CitiesOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetCities";

    public class CreateCityCommandHandler : IRequestHandler<CreateCityCommand, CreatedCityResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICityRepository _cityRepository;
        private readonly CityBusinessRules _cityBusinessRules;

        public CreateCityCommandHandler(IMapper mapper, ICityRepository cityRepository,
                                         CityBusinessRules cityBusinessRules)
        {
            _mapper = mapper;
            _cityRepository = cityRepository;
            _cityBusinessRules = cityBusinessRules;
        }

        public async Task<CreatedCityResponse> Handle(CreateCityCommand request, CancellationToken cancellationToken)
        {
            City? city = _mapper.Map<City>(request);
            await _cityBusinessRules.CityShouldExistWhenSelected(city);
            await  _cityBusinessRules.CityNameShouldNotExistWhenSelected(city,cancellationToken);
            await _cityRepository.AddAsync(city);

            CreatedCityResponse response = _mapper.Map<CreatedCityResponse>(city);
            return response;
        }
    }
}