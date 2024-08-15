using Core.Application.Dtos;

namespace Application.Features.Products.Dtos;
public class GetBarcodeInProductQueryDto:IDto
{
    public Guid Id { get; set; }
    public string? BarcodeNumber { get; set; }
}
