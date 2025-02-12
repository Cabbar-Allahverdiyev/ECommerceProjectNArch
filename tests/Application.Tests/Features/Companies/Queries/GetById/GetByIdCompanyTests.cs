using Application.Features.Companies.Queries.GetById;
using Application.Tests.Mocks.FakeData;
using Application.Tests.Mocks.Repositories;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using static Application.Features.Companies.Queries.GetById.GetByIdCompanyQuery;

namespace Application.Tests.Features.Companies.Queries.GetById;

public class GetByIdCompanyTests : CompanyMockRepository
{
    private readonly GetByIdCompanyQuery _query;
    private readonly GetByIdCompanyQueryHandler _handler;

    public GetByIdCompanyTests(CompanyFakeData fakeData, GetByIdCompanyQuery query)
        : base(fakeData)
    {
        _query = query;
        _handler = new GetByIdCompanyQueryHandler( Mapper, MockRepository.Object, BusinessRules);
    }

    [Fact]
    public async Task GetByIdCompanyShouldSuccessfully()
    {
        _query.Id = Guid.NewGuid();
        Company createdCompany = await MockRepository.Object.AddAsync(new(_query.Id, CityFakeData.Seeds[0].Id, "sirketAdiGetById1Tests", "Yevlax", "cab@cabbarov.com", "0553216545"));

        GetByIdCompanyResponse result = await _handler.Handle(_query, CancellationToken.None);

        Assert.Equal(expected: "sirketAdiGetById1Tests", result.Name);
    }

    [Fact]
    public async Task CompanyIdNotExistsShouldReturnError()
    {
        _query.Id = Guid.NewGuid();

        async Task Action() => await _handler.Handle(_query, CancellationToken.None);

        await Assert.ThrowsAsync<BusinessException>(Action);
    }
}