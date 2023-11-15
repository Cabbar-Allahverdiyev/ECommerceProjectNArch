using Core.Application.Dtos;

namespace Application.Features.ProductCategories.Dtos;
public class GetParentCategoryInProductCategoryDto : IDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
}
