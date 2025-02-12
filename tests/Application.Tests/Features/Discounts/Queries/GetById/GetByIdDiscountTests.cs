using Application.Features.Discounts.Queries.GetById;
using Application.Tests.Mocks.FakeData;
using Application.Tests.Mocks.Repositories;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using static Application.Features.Discounts.Queries.GetById.GetByIdDiscountQuery;

namespace Application.Tests.Features.Discounts.Queries.GetById;

public class GetByIdDiscountTests : DiscountMockRepository
{
    private readonly GetByIdDiscountQuery _query;
    private readonly GetByIdDiscountQueryHandler _handler;

    public GetByIdDiscountTests(DiscountFakeData fakeData, GetByIdDiscountQuery query)
        : base(fakeData)
    {
        _query = query;
        _handler = new GetByIdDiscountQueryHandler(Mapper, MockRepository.Object, BusinessRules);
    }

     [Fact]
    public async Task GetByIdDiscountShouldSuccessfully()
    {
        _query.Id = Guid.NewGuid();
        Discount createdDiscount=await MockRepository.Object.AddAsync(new(_query.Id,5,"endrimAdiGetById1Tests"));

        GetByIdDiscountResponse result = await _handler.Handle(_query, CancellationToken.None);

        Assert.Equal(expected: "endrimAdiGetById1Tests", result.Name);
    }

    [Fact]
    public async Task DiscountIdNotExistsShouldReturnError()
    {
        _query.Id = Guid.NewGuid();

        async Task Action() => await _handler.Handle(_query, CancellationToken.None);

        await Assert.ThrowsAsync<BusinessException>(Action);
    }
}