using Core.Application.Dtos;

namespace Application.Features.Countries.Dtos;
public class GetCityInCountryDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string BarcodeCode { get; set; }
}