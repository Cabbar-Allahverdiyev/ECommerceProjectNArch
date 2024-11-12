using Core.Application.Responses;

namespace Application.Features.Shops.Commands.Update;

public class UpdatedShopResponse : IResponse
{
    public Guid Id { get; set; }
    public int UserId { get; set; }
    public Guid CompanyId { get; set; }
}