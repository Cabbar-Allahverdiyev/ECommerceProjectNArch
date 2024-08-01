using Application.Features.Companies.Dtos;
using Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Companies.Queries.GetListByDynamicCompany;
public class GetListByDynamicCompanyItemDto:IDto
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
