using Core.Application.Dtos;

namespace Application.Features.Discounts.Queries.GetList;

public class GetListDiscountListItemDto : IDto
{
    public Guid Id { get; set; }
    public decimal DiscountPercent { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}