using Application.Features.Cities.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.Cities.Rules;

public class CityBusinessRules : BaseBusinessRules
{
    private readonly ICityRepository _cityRepository;

    public CityBusinessRules(ICityRepository cityRepository)
    {
        _cityRepository = cityRepository;
    }

    public Task CityShouldExistWhenSelected(City? city)
    {
        if (city == null)
            throw new BusinessException(CitiesBusinessMessages.CityNotExists);
        return Task.CompletedTask;
    }
    public Task CityShouldNotExistWhenSelected(City? city)
    {
        if (city != null)
            throw new BusinessException(CitiesBusinessMessages.CityNameAlreadyExists);
        return Task.CompletedTask;
    }
    public async Task CityNameShouldNotExistWhenSelected(City? city, CancellationToken cancellationToken)
    {
        if (city == null)
            throw new BusinessException(CitiesBusinessMessages.CityIsNull);
        City? result =await _cityRepository.GetAsync(
        predicate: c => string.Equals(c.Name, city.Name, StringComparison.OrdinalIgnoreCase),
        enableTracking: false,
        cancellationToken: cancellationToken);

        await CityShouldNotExistWhenSelected(result);
    }

    public async Task CityNameShouldNotExistWhenUpdated(City? city,string newCityName, CancellationToken cancellationToken)
    {
        if (city == null)
            throw new BusinessException(CitiesBusinessMessages.CityIsNull);
        City? result = await _cityRepository.GetAsync(
        predicate: c => string.Equals(c.Name, newCityName, StringComparison.OrdinalIgnoreCase)&& c.Id != city.Id,                     
        enableTracking: false,
        cancellationToken: cancellationToken);
        await CityShouldNotExistWhenSelected(result);
    }

    public async Task CityIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        City? city = await _cityRepository.GetAsync(
            predicate: c => c.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await CityShouldExistWhenSelected(city);
    }
}