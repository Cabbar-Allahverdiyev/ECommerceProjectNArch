using Application.Features.ProductBrands.Dtos;
using Core.Application.Responses;

namespace Application.Features.ProductBrands.Queries.GetById;

public class GetByIdProductBrandResponse : IResponse
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public ICollection<GetProductsInBrandDto>? Products { get; set; }
}