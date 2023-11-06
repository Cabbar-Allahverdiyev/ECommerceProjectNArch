using Application.Features.Countries.Dtos;
using Core.Application.Responses;

namespace Application.Features.Countries.Queries.GetByName;

public class GetByNameCountryResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public ICollection<GetCityInCountryDto>? Cities { get; set; }
}
