using Core.Application.Dtos;

namespace Application.Features.Shops.Queries.GetList;

public class GetListShopListItemDto : IDto
{
    public Guid Id { get; set; }
    public int UserId { get; set; }
    public Guid CompanyId { get; set; }
}