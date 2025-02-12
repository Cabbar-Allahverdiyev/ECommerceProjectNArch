using Application.Features.Cities.Queries.GetById;
using Application.Tests.Mocks.FakeData;
using Application.Tests.Mocks.Repositories;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using static Application.Features.Cities.Queries.GetById.GetByIdCityQuery;

namespace Application.Tests.Features.Cities.Queries.GetById;

public class GetByIdCityTests : CityMockRepository
{
    private readonly GetByIdCityQuery _query;
    private readonly GetByIdCityQueryHandler _handler;

    public GetByIdCityTests(CityFakeData fakeData, GetByIdCityQuery query)
        : base(fakeData)
    {
        _query = query;
        _handler = new GetByIdCityQueryHandler(Mapper, MockRepository.Object, BusinessRules);
    }

    [Fact]
    public async Task GetByIdCityShouldSuccessfully()
    {
        _query.Id = Guid.NewGuid();
        City createdCity = await MockRepository.Object.AddAsync(new(_query.Id, CountryFakeData.Seeds[1].Id, "sheherAdiGetById1Tests"));

        GetByIdCityResponse result = await _handler.Handle(_query, CancellationToken.None);

        Assert.Equal(expected: "sheherAdiGetById1Tests", result.Name);
    }

    [Fact]
    public async Task CityIdNotExistsShouldReturnError()
    {
        _query.Id = Guid.NewGuid();

        async Task Action() => await _handler.Handle(_query, CancellationToken.None);

        await Assert.ThrowsAsync<BusinessException>(Action);
    }
}