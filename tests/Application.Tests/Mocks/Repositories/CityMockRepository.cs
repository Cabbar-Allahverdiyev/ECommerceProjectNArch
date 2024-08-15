using Application.Features.Cities.Profiles;
using Application.Features.Cities.Rules;
using Core.Test.Application.Repositories;
using Application.Services.Repositories;
using Domain.Entities;
using Application.Tests.Mocks.FakeData;
using System;

namespace Application.Tests.Mocks.Repositories;
public class CityMockRepository
    : BaseMockRepository<ICityRepository, City, Guid, MappingProfiles, CityBusinessRules, CityFakeData>
{
    public CityMockRepository(CityFakeData fakeData)
        : base(fakeData) { }
}
