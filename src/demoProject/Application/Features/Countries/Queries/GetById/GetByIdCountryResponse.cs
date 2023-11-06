using Application.Features.Countries.Dtos;
using Core.Application.Responses;

namespace Application.Features.Countries.Queries.GetById;

public class GetByIdCountryResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public ICollection<GetCityInCountryDto>? Cities { get; set; }
}

