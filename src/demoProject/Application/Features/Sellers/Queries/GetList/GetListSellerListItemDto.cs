using Core.Application.Dtos;

namespace Application.Features.Sellers.Queries.GetList;

public class GetListSellerListItemDto : IDto
{
    public Guid Id { get; set; }
    public int UserId { get; set; }
    public Guid ShopId { get; set; }
}