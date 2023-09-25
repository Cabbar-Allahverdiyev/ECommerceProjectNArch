using Core.Application.Responses;

namespace Application.Features.Cities.Queries.GetByNameCity;

public class GetByNameCityResponse : IResponse
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
}
