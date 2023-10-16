using Core.Application.Responses;

namespace Application.Features.Discounts.Queries.GetById;

public class GetByIdDiscountResponse : IResponse
{
    public Guid Id { get; set; }
    public decimal DiscountPercent { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}