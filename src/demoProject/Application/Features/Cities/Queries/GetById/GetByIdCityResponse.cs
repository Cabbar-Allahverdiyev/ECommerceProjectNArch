using Application.Features.Cities.Dtos;
using Core.Application.Responses;

namespace Application.Features.Cities.Queries.GetById;

public class GetByIdCityResponse : IResponse
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public GetCountryInCityQueryDto? Country { get; set; }
    public ICollection<GetCompanyInCityQueryDto>? Companies { get; set; }    
}

