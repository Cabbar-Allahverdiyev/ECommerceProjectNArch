using Core.Application.Dtos;

namespace Application.Features.Products.Dtos;
public class GetDiscountInProductQueryDto:IDto
{
    public Guid Id { get; set; }
    public decimal DiscountPercent { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
}
