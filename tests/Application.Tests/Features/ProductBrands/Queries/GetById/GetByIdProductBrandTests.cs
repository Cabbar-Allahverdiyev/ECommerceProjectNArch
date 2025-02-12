using Application.Features.ProductBrands.Queries.GetById;
using Application.Tests.Mocks.FakeData;
using Application.Tests.Mocks.Repositories;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using static Application.Features.ProductBrands.Queries.GetById.GetByIdProductBrandQuery;

namespace Application.Tests.Features.ProductBrands.Queries.GetById;

public class GetByIdProductBrandTests : ProductBrandMockRepository
{
    private readonly GetByIdProductBrandQuery _query;
    private readonly GetByIdProductBrandQueryHandler _handler;

    public GetByIdProductBrandTests(ProductBrandFakeData fakeData, GetByIdProductBrandQuery query)
        : base(fakeData)
    {
        _query = query;
        _handler = new GetByIdProductBrandQueryHandler(Mapper,MockRepository.Object,  BusinessRules);
    }

     [Fact]
    public async Task GetByIdProductBrandShouldSuccessfully()
    {
        _query.Id = Guid.NewGuid();
        ProductBrand createdProductBrand=await MockRepository.Object.AddAsync(new(_query.Id,"productBrandNameGetById1Tests"));

        GetByIdProductBrandResponse result = await _handler.Handle(_query, CancellationToken.None);

        Assert.Equal(expected: "productBrandNameGetById1Tests", result.Name);
    }

    [Fact]
    public async Task ProductBrandIdNotExistsShouldReturnError()
    {
        _query.Id = Guid.NewGuid();

        async Task Action() => await _handler.Handle(_query, CancellationToken.None);

        await Assert.ThrowsAsync<BusinessException>(Action);
    }
}