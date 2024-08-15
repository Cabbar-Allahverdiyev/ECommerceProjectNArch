using Core.Application.Responses;

namespace Application.Features.ProductInventors.Commands.Create;

public class CreatedProductInventorResponse : IResponse
{
    public Guid Id { get; set; }
    public int Quantity { get; set; }
}