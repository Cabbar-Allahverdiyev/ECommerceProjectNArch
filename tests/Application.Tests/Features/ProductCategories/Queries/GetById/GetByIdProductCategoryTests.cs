using Application.Features.ProductCategories.Queries.GetById;
using Application.Tests.Mocks.FakeData;
using Application.Tests.Mocks.Repositories;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using static Application.Features.ProductCategories.Queries.GetById.GetByIdProductCategoryQuery;

namespace Application.Tests.Features.ProductCategories.Queries.GetById;

public class GetByIdProductCategoryTests : ProductCategoryMockRepository
{
    private readonly GetByIdProductCategoryQuery _query;
    private readonly GetByIdProductCategoryQueryHandler _handler;

    public GetByIdProductCategoryTests(ProductCategoryFakeData fakeData, GetByIdProductCategoryQuery query)
        : base(fakeData)
    {
        _query = query;
        _handler = new GetByIdProductCategoryQueryHandler(Mapper,MockRepository.Object,  BusinessRules);
    }

     [Fact]
    public async Task GetByIdProductCategoryShouldSuccessfully()
    {
        _query.Id = Guid.NewGuid();
        ProductCategory createdProductCategory=await MockRepository.Object.AddAsync(new(_query.Id,"productCategoryGetById1Tests"));

        GetByIdProductCategoryResponse result = await _handler.Handle(_query, CancellationToken.None);

        Assert.Equal(expected: "productCategoryGetById1Tests", result.Name);
    }

    [Fact]
    public async Task ProductCategoryIdNotExistsShouldReturnError()
    {
        _query.Id = Guid.NewGuid();

        async Task Action() => await _handler.Handle(_query, CancellationToken.None);

        await Assert.ThrowsAsync<BusinessException>(Action);
    }
}