using Core.Application.Dtos;

namespace Application.Features.ProductCategories.Queries.GetList;

public class GetListProductCategoryListItemDto : IDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public Guid? ParentId { get; set; }
    public string? Description { get; set; }
}