using Core.Application.Dtos;

namespace Application.Features.Products.Dtos;
public class GetColorInProductQueryDto:IDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
}
