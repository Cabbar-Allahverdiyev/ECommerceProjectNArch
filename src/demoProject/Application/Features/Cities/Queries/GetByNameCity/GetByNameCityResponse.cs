using Application.Features.Cities.Dtos;
using Core.Application.Responses;

namespace Application.Features.Cities.Queries.GetByNameCity;

public class GetByNameCityResponse : IResponse
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public GetCountryInCityQueryDto? Country { get; set; }
    public ICollection<GetCompanyInCityQueryDto>? Companies { get; set; }
}
