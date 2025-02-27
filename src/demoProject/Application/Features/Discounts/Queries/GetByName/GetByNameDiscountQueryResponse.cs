﻿using Application.Features.Discounts.Dtos;
using Core.Application.Responses;

namespace Application.Features.Discounts.Queries.GetByName;
public class GetByNameDiscountQueryResponse:IResponse
{
    public Guid Id { get; set; }
    public decimal DiscountPercent { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<GetProductsInDiscountDto>? Products { get; set; }
}
