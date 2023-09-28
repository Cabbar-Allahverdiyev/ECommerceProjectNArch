using Application.Features.Cities.Constants;
using Application.Features.Countries.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using Nest;

namespace Application.Features.Countries.Rules;

public class CountryBusinessRules : BaseBusinessRules
{
    private readonly ICountryRepository _countryRepository;

    public CountryBusinessRules(ICountryRepository countryRepository)
    {
        _countryRepository = countryRepository;
    }

    public Task CountryShouldExistWhenSelected(Country? country)
    {
        if (country == null)
            throw new BusinessException(CountriesBusinessMessages.CountryNotExists);
        return Task.CompletedTask;
    }
    public Task CountryShouldNotExistWhenSelected(Country? country)
    {
        if (country != null)
            throw new BusinessException(CountriesBusinessMessages.CountryExists);
        return Task.CompletedTask;
    }

    public async Task CountryIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Country? country = await _countryRepository.GetAsync(
            predicate: c => c.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await CountryShouldExistWhenSelected(country);
    }

    public async Task CountryNameShouldNotExistWhenSelected(string? name,CancellationToken cancellationToken)
    {
        Country? country = await _countryRepository.GetAsync(
            predicate: c => c.Name == name,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await CountryShouldNotExistWhenSelected(country);
    }

    public async Task CountryNameShouldNotExistWhenUpdated(Country? country, string newCountryName, CancellationToken cancellationToken)
    {
        if (country == null)
            throw new BusinessException(CountriesBusinessMessages.CountryIsNull);
        Country? result = await _countryRepository.GetAsync(
        predicate: c => string.Equals(c.Name, newCountryName, StringComparison.OrdinalIgnoreCase) && c.Id != country.Id,

        enableTracking: false,
        cancellationToken: cancellationToken);
        await CountryShouldNotExistWhenSelected(result);
    }
}