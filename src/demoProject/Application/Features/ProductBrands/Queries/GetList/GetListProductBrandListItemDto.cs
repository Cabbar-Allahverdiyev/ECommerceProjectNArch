using Core.Application.Dtos;

namespace Application.Features.ProductBrands.Queries.GetList;

public class GetListProductBrandListItemDto : IDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
}