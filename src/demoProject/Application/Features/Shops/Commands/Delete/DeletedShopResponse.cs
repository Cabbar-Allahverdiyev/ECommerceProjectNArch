using Core.Application.Responses;

namespace Application.Features.Shops.Commands.Delete;

public class DeletedShopResponse : IResponse
{
    public Guid Id { get; set; }
}