﻿using Application.Features.ProductCategories.Dtos;
using Core.Application.Dtos;

namespace Application.Features.ProductCategories.Queries.GetListByDynamicProductCategory;
public class GetListByDynamicProductCategoryItemDto:IDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public GetParentCategoryInProductCategoryDto? Parent { get; set; }
    public ICollection<GetProductsInProductCategoryDto>? Products { get; set; }
}
