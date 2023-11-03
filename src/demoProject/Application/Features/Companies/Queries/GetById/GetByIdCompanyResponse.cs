using Core.Application.Responses;
using Domain.Entities;

namespace Application.Features.Companies.Queries.GetById;

public class GetByIdCompanyResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid CityId { get; set; }
    public string? Name { get; set; }
    public string? AddressLine1 { get; set; }
    public string? AddressLine2 { get; set; }
    public string?  CityName { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
}