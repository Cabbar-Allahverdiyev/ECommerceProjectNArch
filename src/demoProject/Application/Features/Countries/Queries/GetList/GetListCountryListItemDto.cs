using Application.Features.Countries.Dtos;
using Core.Application.Dtos;

namespace Application.Features.Countries.Queries.GetList;

public class GetListCountryListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string BarcodeCode { get; set; }
    public ICollection<GetCityInCountryDto>? Cities { get; set; }
}