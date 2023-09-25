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

namespace Application.Features.Cities.Commands.Update;

public class UpdateCityCommand : IRequest<UpdatedCityResponse>//, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public string? Name { get; set; }

    public string[] Roles => new[] { Admin, Write, CitiesOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetCities";

    public class UpdateCityCommandHandler : IRequestHandler<UpdateCityCommand, UpdatedCityResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICityRepository _cityRepository;
        private readonly CityBusinessRules _cityBusinessRules;

        public UpdateCityCommandHandler(IMapper mapper, ICityRepository cityRepository,
                                         CityBusinessRules cityBusinessRules)
        {
            _mapper = mapper;
            _cityRepository = cityRepository;
            _cityBusinessRules = cityBusinessRules;
        }

        public async Task<UpdatedCityResponse> Handle(UpdateCityCommand request, CancellationToken cancellationToken)
        {
            City? city = await _cityRepository.GetAsync(predicate: c => c.Id == request.Id, cancellationToken: cancellationToken);
            await _cityBusinessRules.CityShouldExistWhenSelected(city);
            await _cityBusinessRules.CityNameShouldNotExistWhenSelectedForUpdateCommand(city,request.Name,cancellationToken);
            city = _mapper.Map(request, city);

            await _cityRepository.UpdateAsync(city!);

            UpdatedCityResponse response = _mapper.Map<UpdatedCityResponse>(city);
            return response;
        }
    }
}