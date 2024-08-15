using Core.Application.Responses;

namespace Application.Features.Discounts.Commands.Update;

public class UpdatedDiscountResponse : IResponse
{
    public Guid Id { get; set; }
    public decimal DiscountPercent { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}