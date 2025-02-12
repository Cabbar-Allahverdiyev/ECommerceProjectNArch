using Application.Features.Countries.Queries.GetById;
using Application.Tests.Mocks.FakeData;
using Application.Tests.Mocks.Repositories;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using static Application.Features.Countries.Queries.GetById.GetByIdCountryQuery;

namespace Application.Tests.Features.Countries.Queries.GetById;

public class GetByIdCountryTests : CountryMockRepository
{
    private readonly GetByIdCountryQuery _query;
    private readonly GetByIdCountryQueryHandler _handler;

    public GetByIdCountryTests(CountryFakeData fakeData, GetByIdCountryQuery query)
        : base(fakeData)
    {
        _query = query;
        _handler = new GetByIdCountryQueryHandler(Mapper, MockRepository.Object,  BusinessRules);
    }

    [Fact]
    public async Task GetByIdCountryShouldSuccessfully()
    {
        _query.Id = Guid.NewGuid();
        Country createdCountry =await MockRepository.Object.AddAsync(new(_query.Id,"olkeAdiGetById1Tests","123"));

        GetByIdCountryResponse result = await _handler.Handle(_query, CancellationToken.None);

        Assert.Equal(expected: "olkeAdiGetById1Tests", result.Name);
    }

    [Fact]
    public async Task CountryIdNotExistsShouldReturnError()
    {
        _query.Id = Guid.NewGuid();

        async Task Action() => await _handler.Handle(_query, CancellationToken.None);

        await Assert.ThrowsAsync<BusinessException>(Action);
    }
}