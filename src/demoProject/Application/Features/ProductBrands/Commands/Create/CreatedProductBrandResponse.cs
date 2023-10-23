using Core.Application.Responses;

namespace Application.Features.ProductBrands.Commands.Create;

public class CreatedProductBrandResponse : IResponse
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
}