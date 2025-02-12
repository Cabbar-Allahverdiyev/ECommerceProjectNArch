using Application.Features.Companies.Queries.GetList;
using Application.Tests.Mocks.FakeData;
using Application.Tests.Mocks.Repositories;
using Core.Application.Requests;
using Core.Application.Responses;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using static Application.Features.Companies.Queries.GetList.GetListCompanyQuery;

namespace Application.Tests.Features.Companies.Queries.GetList;

public class GetListCompanyTests : CompanyMockRepository
{
    private readonly GetListCompanyQuery _query;
    private readonly GetListCompanyQueryHandler _handler;

    public GetListCompanyTests(CompanyFakeData fakeData, GetListCompanyQuery query)
        : base(fakeData)
    {
        _query = query;
        _handler = new GetListCompanyQueryHandler(MockRepository.Object, Mapper);
    }

    [Fact]
    public async Task GetAllCompaniesShouldSuccessfuly()
    {
        _query.PageRequest = new PageRequest { PageIndex = 0, PageSize = 2 };

        GetListResponse<GetListCompanyListItemDto> result = await _handler.Handle(_query, CancellationToken.None);

        Assert.Equal(expected: 2, result.Items.Count);
    }
     
}