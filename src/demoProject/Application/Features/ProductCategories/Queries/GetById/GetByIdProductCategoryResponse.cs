using Core.Application.Responses;
using Domain.Entities;

namespace Application.Features.ProductCategories.Queries.GetById;

public class GetByIdProductCategoryResponse : IResponse
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public Guid? ParentId { get; set; }
    public ProductCategory? Parent { get; set; }
    public string? Description { get; set; }
}