using Core.Application.Responses;

namespace Application.Features.ProductBrands.Commands.Delete;

public class DeletedProductBrandResponse : IResponse
{
    public Guid Id { get; set; }
}