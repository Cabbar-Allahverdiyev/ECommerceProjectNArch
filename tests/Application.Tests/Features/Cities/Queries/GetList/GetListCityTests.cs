using Application.Features.Cities.Queries.GetList;
using Application.Tests.Mocks.FakeData;
using Application.Tests.Mocks.Repositories;
using Core.Application.Requests;
using Core.Application.Responses;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using static Application.Features.Cities.Queries.GetList.GetListCityQuery;

namespace Application.Tests.Features.Cities.Queries.GetList;

public class GetListCityTests : CityMockRepository
{
    private readonly GetListCityQuery _query;
    private readonly GetListCityQueryHandler _handler;

    public GetListCityTests(CityFakeData fakeData, GetListCityQuery query)
        : base(fakeData)
    {
        _query = query;
        _handler = new GetListCityQueryHandler(MockRepository.Object, Mapper);
    }

    [Fact]
    public async Task GetAllCitiesShouldSuccessfuly()
    {
        _query.PageRequest = new PageRequest { PageIndex = 0, PageSize = 2 };

        GetListResponse<GetListCityListItemDto> result = await _handler.Handle(_query, CancellationToken.None);

        Assert.Equal(expected: 2, result.Items.Count);
    }
     
}