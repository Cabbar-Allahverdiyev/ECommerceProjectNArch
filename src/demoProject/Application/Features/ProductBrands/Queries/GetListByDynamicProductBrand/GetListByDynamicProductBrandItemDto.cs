using Application.Features.ProductBrands.Dtos;
using Core.Application.Dtos;

namespace Application.Features.ProductBrands.Queries.GetListByDynamicProductBrand;
public class GetListByDynamicProductBrandItemDto :IDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public ICollection<GetProductsInBrandDto>? Products { get; set; }
}
