using Core.Application.Dtos;

namespace Application.Features.Cities.Dtos;
public class GetCountryInCityQueryDto:IDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
}