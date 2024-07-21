using Application.Features.Suppliers.Dtos;
using Core.Application.Dtos;

namespace Application.Features.Suppliers.Queries.GetList;

public class GetListSupplierListItemDto : IDto
{
    public Guid Id { get; set; }
    public string? BarcodeCode { get; set; }
    public string? Description { get; set; }
    public GetCompanyInSupplierQueryDto Company { get; set; }
    public GetUserInSupplierQueryDto User { get; set; }
    public IList<GetProductsInSupplierQueryDto>? Products { get; set; }
}