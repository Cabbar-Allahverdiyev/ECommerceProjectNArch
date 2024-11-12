using Core.Application.Responses;

namespace Application.Features.Sellers.Queries.GetById;

public class GetByIdSellerResponse : IResponse
{
    public Guid Id { get; set; }
    public int UserId { get; set; }
    public Guid ShopId { get; set; }
}