using Application.Features.Products.Dtos;
using Core.Application.Dtos;

namespace Application.Features.Products.Queries.GetList;

public class GetListProductListItemDto : IDto
{
    public Guid Id { get; set; }
    public GetCategoryInProductQueryDto? Category { get; set; }
    public GetBrandInProductQueryDto Brand { get; set; }
    public GetSupplierInProductQueryDto Supplier { get; set; }
    public GetDiscountInProductQueryDto Discount { get; set; }
    public GetInventorInProductQueryDto Inventor { get; set; }
    public int UnitsOnOrder { get; set; }
    public int ReorderLevel { get; set; }
    public decimal PurchasePrice { get; set; }
    public decimal UnitPrice { get; set; }
    public string? Name { get; set; }
    public string? QuantityPerUnit { get; set; }
    public string? SKU { get; set; }
    public string? Description { get; set; }
    public bool IsDiscontinued { get; set; }
}