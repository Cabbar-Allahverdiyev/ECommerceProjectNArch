using Core.Application.Responses;

namespace Application.Features.Discounts.Commands.Create;

public class CreatedDiscountResponse : IResponse
{
    public Guid Id { get; set; }
    public decimal DiscountPercent { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}