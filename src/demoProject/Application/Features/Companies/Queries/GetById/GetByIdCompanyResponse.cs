using Core.Application.Responses;

namespace Application.Features.Companies.Queries.GetById;

public class GetByIdCompanyResponse : IResponse
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? AddressLine1 { get; set; }
    public string? AddressLine2 { get; set; }
    public int CityId { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
}