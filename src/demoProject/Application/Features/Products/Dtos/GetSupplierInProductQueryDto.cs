using Core.Application.Dtos;

namespace Application.Features.Products.Dtos;
public class GetSupplierInProductQueryDto:IDto
{
    public Guid Id { get; set; }
    public Guid CompanyId { get; set; }
    public int UserId { get; set; }
    public string? Description { get; set; }
}
