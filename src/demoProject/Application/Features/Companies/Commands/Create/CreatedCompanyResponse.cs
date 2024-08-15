using Core.Application.Responses;

namespace Application.Features.Companies.Commands.Create;

public class CreatedCompanyResponse : IResponse
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? AddressLine1 { get; set; }
    public string? AddressLine2 { get; set; }
    public Guid CityId { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
}