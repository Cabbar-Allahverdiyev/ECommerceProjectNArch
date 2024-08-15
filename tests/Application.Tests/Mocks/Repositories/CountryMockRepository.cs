using Application.Features.Countries.Profiles;
using Application.Features.Countries.Rules;
using Application.Services.Repositories;
using Application.Tests.Mocks.FakeData;
using Core.Test.Application.Repositories;
using Domain.Entities;
using System;

namespace Application.Tests.Mocks.Repositories;
public class CountryMockRepository
    : BaseMockRepository<ICountryRepository, Country, Guid, MappingProfiles, CountryBusinessRules, CountryFakeData>
{
    public CountryMockRepository(CountryFakeData fakeData)
        : base(fakeData) { }
}