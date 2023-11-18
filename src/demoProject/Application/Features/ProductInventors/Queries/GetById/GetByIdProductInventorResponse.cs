using Application.Features.ProductInventors.Dtos;
using Core.Application.Responses;

namespace Application.Features.ProductInventors.Queries.GetById;

public class GetByIdProductInventorResponse : IResponse
{
    public Guid Id { get; set; }
    public int Quantity { get; set; }
    public GetProductInInventorDto? Product { get; set; }
}