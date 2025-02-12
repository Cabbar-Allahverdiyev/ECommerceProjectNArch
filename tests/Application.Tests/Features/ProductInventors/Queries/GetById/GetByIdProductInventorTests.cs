using Application.Features.ProductInventors.Queries.GetById;
using Application.Tests.Mocks.FakeData;
using Application.Tests.Mocks.Repositories;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using static Application.Features.ProductInventors.Queries.GetById.GetByIdProductInventorQuery;

namespace Application.Tests.Features.ProductInventors.Queries.GetById;

public class GetByIdProductInventorTests : ProductInventorMockRepository
{
    private readonly GetByIdProductInventorQuery _query;
    private readonly GetByIdProductInventorQueryHandler _handler;

    public GetByIdProductInventorTests(ProductInventorFakeData fakeData, GetByIdProductInventorQuery query)
        : base(fakeData)
    {
        _query = query;
        _handler = new GetByIdProductInventorQueryHandler(Mapper, MockRepository.Object, BusinessRules);
    }

    [Fact]
    public async Task GetByIdProductInventorShouldSuccessfully()
    {
        _query.Id = Guid.NewGuid();
        ProductInventor createdProductInventor = await MockRepository.Object.AddAsync(new(_query.Id, ProductFakeData.Seeds[3].Id, 3 ));

        GetByIdProductInventorResponse result = await _handler.Handle(_query, CancellationToken.None);

        Assert.Equal(expected: ProductFakeData.Seeds[3].Id, result.Product.Id);
    }

    [Fact]
    public async Task ProductInventorIdNotExistsShouldReturnError()
    {
        _query.Id = Guid.NewGuid();

        async Task Action() => await _handler.Handle(_query, CancellationToken.None);

        await Assert.ThrowsAsync<BusinessException>(Action);
    }
}