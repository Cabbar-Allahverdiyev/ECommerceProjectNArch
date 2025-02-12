using Application.Features.Suppliers.Queries.GetList;
using Application.Tests.Mocks.FakeData;
using Application.Tests.Mocks.Repositories;
using Core.Application.Requests;
using Core.Application.Responses;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using static Application.Features.Suppliers.Queries.GetList.GetListSupplierQuery;

namespace Application.Tests.Features.Companies.Queries.GetList;

public class GetListSupplierTests : SupplierMockRepository
{
    private readonly GetListSupplierQuery _query;
    private readonly GetListSupplierQueryHandler _handler;

    public GetListSupplierTests(SupplierFakeData fakeData, GetListSupplierQuery query)
        : base(fakeData)
    {
        _query = query;
        _handler = new GetListSupplierQueryHandler(MockRepository.Object, Mapper);
    }

    [Fact]
    public async Task GetAllCompaniesShouldSuccessfuly()
    {
        _query.PageRequest = new PageRequest { PageIndex = 0, PageSize = 2 };

        GetListResponse<GetListSupplierListItemDto> result = await _handler.Handle(_query, CancellationToken.None);

        Assert.Equal(expected: 2, result.Items.Count);
    }
     
}