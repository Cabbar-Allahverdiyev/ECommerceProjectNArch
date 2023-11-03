using Core.Application.Responses;

namespace Application.Features.Products.Commands.Create;

public class CreatedProductResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid CategoryId { get; set; }
    public Guid BrandId { get; set; }
    public Guid SupplierId { get; set; }
    public Guid DiscountId { get; set; }
    public Guid InventorId { get; set; }
    public int UnitsOnOrder { get; set; }
    public int ReorderLevel { get; set; }
    public decimal PurchasePrice { get; set; }
    public decimal UnitPrice { get; set; }
    public string Name { get; set; }
    public string QuantityPerUnit { get; set; }
    public string SKU { get; set; }
    public string Description { get; set; }
    public bool IsDiscontinued { get; set; }
}