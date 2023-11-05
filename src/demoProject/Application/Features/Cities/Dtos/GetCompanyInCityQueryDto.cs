using Core.Application.Dtos;

namespace Application.Features.Cities.Dtos;
public class GetCompanyInCityQueryDto : IDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? AddressLine1 { get; set; }
    public string? AddressLine2 { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
}

