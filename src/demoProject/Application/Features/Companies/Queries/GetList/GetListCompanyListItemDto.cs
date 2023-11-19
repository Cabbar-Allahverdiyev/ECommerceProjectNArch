using Application.Features.Companies.Dtos;
using Core.Application.Dtos;

namespace Application.Features.Companies.Queries.GetList;

public class GetListCompanyListItemDto : IDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? AddressLine1 { get; set; }
    public string? AddressLine2 { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public GetCityInCompanyDto? City { get; set; }
    public IList<GetSuppliersInCompanyQueryDto>? Suppliers { get; set; }
}