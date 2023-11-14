using Application.Features.ProductBrands.Dtos;
using Core.Application.Responses;
using Domain.Entities;

namespace Application.Features.ProductBrands.Queries.GetByName;

public class GetByNameProductBrandResponse : IResponse
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public ICollection<GetProductsInBrandDto>? Products { get; set; }
}
