using Application.Features.ProductCategories.Dtos;
using Core.Application.Responses;

namespace Application.Features.ProductCategories.Queries.GetByName;

public class GetByNameProductCategoryResponse : IResponse
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public GetParentCategoryInProductCategoryDto? Parent { get; set; }
    public ICollection<GetProductsInProductCategoryDto>? Products { get; set; }
}
