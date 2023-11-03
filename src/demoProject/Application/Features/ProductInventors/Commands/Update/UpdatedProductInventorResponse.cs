using Core.Application.Responses;

namespace Application.Features.ProductInventors.Commands.Update;

public class UpdatedProductInventorResponse : IResponse
{
    public Guid Id { get; set; }
    public int Quantity { get; set; }
}