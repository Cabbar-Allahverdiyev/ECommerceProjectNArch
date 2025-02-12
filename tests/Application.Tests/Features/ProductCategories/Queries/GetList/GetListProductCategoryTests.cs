using Application.Features.ProductCategories.Queries.GetList;
using Application.Tests.Mocks.FakeData;
using Application.Tests.Mocks.Repositories;
using Core.Application.Requests;
using Core.Application.Responses;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using static Application.Features.ProductCategories.Queries.GetList.GetListProductCategoryQuery;

namespace Application.Tests.Features.ProductCategories.Queries.GetList;

public class GetListProductCategoryTests : ProductCategoryMockRepository
{
    private readonly GetListProductCategoryQuery _query;
    private readonly GetListProductCategoryQueryHandler _handler;

    public GetListProductCategoryTests(ProductCategoryFakeData fakeData, GetListProductCategoryQuery query)
        : base(fakeData)
    {
        _query = query;
        _handler = new GetListProductCategoryQueryHandler(MockRepository.Object, Mapper);
    }

    [Fact]
    public async Task GetAllCompaniesShouldSuccessfuly()
    {
        _query.PageRequest = new PageRequest { PageIndex = 0, PageSize = 2 };

        GetListResponse<GetListProductCategoryListItemDto> result = await _handler.Handle(_query, CancellationToken.None);

        Assert.Equal(expected: 2, result.Items.Count);
    }
     
}