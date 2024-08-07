using Application.Features.Discounts.Dtos;
using Core.Application.Dtos;

namespace Application.Features.Discounts.Queries.GetListByDynamicDiscount;
public class GetListByDynamicDiscountItemDto:IDto
{
    public Guid Id { get; set; }
    public decimal DiscountPercent { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public ICollection<GetProductsInDiscountDto>? Products { get; set; }
}
