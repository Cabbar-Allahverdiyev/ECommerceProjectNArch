using Application.Features.Discounts.Queries.GetList;
using Application.Tests.Mocks.FakeData;
using Application.Tests.Mocks.Repositories;
using Core.Application.Requests;
using Core.Application.Responses;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using static Application.Features.Discounts.Queries.GetList.GetListDiscountQuery;

namespace Application.Tests.Features.Discounts.Queries.GetList;

public class GetListDiscountTests : DiscountMockRepository
{
    private readonly GetListDiscountQuery _query;
    private readonly GetListDiscountQueryHandler _handler;

    public GetListDiscountTests(DiscountFakeData fakeData, GetListDiscountQuery query)
        : base(fakeData)
    {
        _query = query;
        _handler = new GetListDiscountQueryHandler(MockRepository.Object, Mapper);
    }

    [Fact]
    public async Task GetAllCompaniesShouldSuccessfuly()
    {
        _query.PageRequest = new PageRequest { PageIndex = 0, PageSize = 2 };

        GetListResponse<GetListDiscountListItemDto> result = await _handler.Handle(_query, CancellationToken.None);

        Assert.Equal(expected: 2, result.Items.Count);
    }
     
}