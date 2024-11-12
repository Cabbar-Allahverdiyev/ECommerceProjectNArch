using Core.Application.Responses;

namespace Application.Features.Shops.Queries.GetById;

public class GetByIdShopResponse : IResponse
{
    public Guid Id { get; set; }
    public int UserId { get; set; }
    public Guid CompanyId { get; set; }
}