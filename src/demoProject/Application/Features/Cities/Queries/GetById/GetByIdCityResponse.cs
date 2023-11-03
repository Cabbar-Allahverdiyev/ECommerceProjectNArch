using Core.Application.Responses;
using Domain.Entities;

namespace Application.Features.Cities.Queries.GetById;

public class GetByIdCityResponse : IResponse
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public ICollection<Country>? Countries { get; set; }
    public ICollection<Company>? Companies { get; set; }//bunu nece dovr etmeyerek include ede bilerem
}