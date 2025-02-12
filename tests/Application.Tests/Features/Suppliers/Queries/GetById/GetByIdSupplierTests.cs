using Application.Features.Suppliers.Queries.GetById;
using Application.Tests.Mocks.FakeData;
using Application.Tests.Mocks.Repositories;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using static Application.Features.Suppliers.Queries.GetById.GetByIdSupplierQuery;

namespace Application.Tests.Features.Companies.Queries.GetById;

public class GetByIdSupplierTests : SupplierMockRepository
{
    private readonly GetByIdSupplierQuery _query;
    private readonly GetByIdSupplierQueryHandler _handler;

    public GetByIdSupplierTests(SupplierFakeData fakeData, GetByIdSupplierQuery query)
        : base(fakeData)
    {
        _query = query;
        _handler = new GetByIdSupplierQueryHandler(Mapper,MockRepository.Object,  BusinessRules);
    }

     [Fact]
    public async Task GetByIdSupplierShouldSuccessfully()
    {
        _query.Id = Guid.NewGuid();
        Supplier createdSupplier = await MockRepository.Object.AddAsync(new(_query.Id, UserFakeData.Seeds[0].Id, CompanyFakeData.Seeds[0].Id,"2255","supplierGetByIdTest1"));

        GetByIdSupplierResponse result = await _handler.Handle(_query, CancellationToken.None);

        Assert.Equal(expected: "supplierGetByIdTest1", result.Description);
        Assert.Equal(expected: UserFakeData.Seeds[0].FirstName, result.User.FirstName);
        Assert.Equal(expected: CompanyFakeData.Seeds[0].Id, result.Company.Id);
    }

    [Fact]
    public async Task SupplierIdNotExistsShouldReturnError()
    {
        _query.Id = Guid.NewGuid();

        async Task Action() => await _handler.Handle(_query, CancellationToken.None);

        await Assert.ThrowsAsync<BusinessException>(Action);
    }
}