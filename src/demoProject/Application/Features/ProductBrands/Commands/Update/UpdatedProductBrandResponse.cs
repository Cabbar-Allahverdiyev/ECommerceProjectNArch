using Core.Application.Responses;

namespace Application.Features.ProductBrands.Commands.Update;

public class UpdatedProductBrandResponse : IResponse
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
}