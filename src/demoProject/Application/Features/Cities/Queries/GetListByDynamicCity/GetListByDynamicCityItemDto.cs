using Application.Features.Cities.Dtos;
using Core.Application.Dtos;

namespace Application.Features.Cities.Queries.GetListByDynamicCity;
public class GetListByDynamicCityItemDto:IDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public GetCountryInCityQueryDto? Country { get; set; }
    public ICollection<GetCompanyInCityQueryDto>? Companies { get; set; }
}
