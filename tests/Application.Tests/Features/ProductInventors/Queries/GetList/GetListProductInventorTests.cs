using Application.Features.ProductInventors.Queries.GetList;
using Application.Tests.Mocks.FakeData;
using Application.Tests.Mocks.Repositories;
using Core.Application.Requests;
using Core.Application.Responses;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using static Application.Features.ProductInventors.Queries.GetList.GetListProductInventorQuery;

namespace Application.Tests.Features.Companies.Queries.GetList;

public class GetListProductInventorTests : ProductInventorMockRepository
{
    private readonly GetListProductInventorQuery _query;
    private readonly GetListProductInventorQueryHandler _handler;

    public GetListProductInventorTests(ProductInventorFakeData fakeData, GetListProductInventorQuery query)
        : base(fakeData)
    {
        _query = query;
        _handler = new GetListProductInventorQueryHandler(MockRepository.Object, Mapper);
    }

    [Fact]
    public async Task GetAllProductInventorsShouldSuccessfuly()
    {
        _query.PageRequest = new PageRequest { PageIndex = 0, PageSize = 2 };

        GetListResponse<GetListProductInventorListItemDto> result = await _handler.Handle(_query, CancellationToken.None);

        Assert.Equal(expected: 2, result.Items.Count);
    }
     
}