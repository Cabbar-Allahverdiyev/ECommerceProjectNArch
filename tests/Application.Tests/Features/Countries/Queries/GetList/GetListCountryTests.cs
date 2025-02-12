using Application.Features.Countries.Queries.GetList;
using Application.Tests.Mocks.FakeData;
using Application.Tests.Mocks.Repositories;
using Core.Application.Requests;
using Core.Application.Responses;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using static Application.Features.Countries.Queries.GetList.GetListCountryQuery;

namespace Application.Tests.Features.Countries.Queries.GetList;

public class GetListCountryTests : CountryMockRepository
{
    private readonly GetListCountryQuery _query;
    private readonly GetListCountryQueryHandler _handler;

    public GetListCountryTests(CountryFakeData fakeData, GetListCountryQuery query)
        : base(fakeData)
    {
        _query = query;
        _handler = new GetListCountryQueryHandler(MockRepository.Object, Mapper);
    }

    [Fact]
    public async Task GetAllCountriesShouldSuccessfuly()
    {
        _query.PageRequest = new PageRequest { PageIndex = 0, PageSize = 2 };

        GetListResponse<GetListCountryListItemDto> result = await _handler.Handle(_query, CancellationToken.None);

        Assert.Equal(expected: 2, result.Items.Count);
    }
     
}