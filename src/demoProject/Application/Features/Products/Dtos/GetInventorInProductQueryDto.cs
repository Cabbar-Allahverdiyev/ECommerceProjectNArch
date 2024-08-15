using Core.Application.Dtos;

namespace Application.Features.Products.Dtos;
public class GetInventorInProductQueryDto:IDto
{
    public Guid Id { get; set; }
    public int Quantity { get; set; }
}
