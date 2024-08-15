using Application.Features.ProductColors.Dtos;
using Core.Application.Dtos;

namespace Application.Features.ProductColors.Queries.GetListByDynamicProductColor;
public class GetListByDynamicProductColorItemDto:IDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public ICollection<GetProductsInProductColorDto>? Products { get; set; }
}
