using Application.Features.Countries.Dtos;
using Core.Application.Dtos;

namespace Application.Features.Countries.Queries.GetListByDynamicCountry;
public class GetListByDynamicCountryItemDto:IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string BarcodeCode { get; set; }
    public ICollection<GetCityInCountryDto>? Cities { get; set; }
}
