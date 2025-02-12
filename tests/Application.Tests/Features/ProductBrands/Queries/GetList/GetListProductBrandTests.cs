using Application.Features.ProductBrands.Queries.GetList;
using Application.Tests.Mocks.FakeData;
using Application.Tests.Mocks.Repositories;
using Core.Application.Requests;
using Core.Application.Responses;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using static Application.Features.ProductBrands.Queries.GetList.GetListProductBrandQuery;

namespace Application.Tests.Features.ProductBrands.Queries.GetList;

public class GetListProductBrandTests : ProductBrandMockRepository
{
    private readonly GetListProductBrandQuery _query;
    private readonly GetListProductBrandQueryHandler _handler;

    public GetListProductBrandTests(ProductBrandFakeData fakeData, GetListProductBrandQuery query)
        : base(fakeData)
    {
        _query = query;
        _handler = new GetListProductBrandQueryHandler(MockRepository.Object, Mapper);
    }

    [Fact]
    public async Task GetAllCompaniesShouldSuccessfuly()
    {
        _query.PageRequest = new PageRequest { PageIndex = 0, PageSize = 2 };

        GetListResponse<GetListProductBrandListItemDto> result = await _handler.Handle(_query, CancellationToken.None);

        Assert.Equal(expected: 2, result.Items.Count);
    }
     
}