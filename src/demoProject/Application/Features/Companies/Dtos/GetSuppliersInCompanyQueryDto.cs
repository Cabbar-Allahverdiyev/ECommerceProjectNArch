using Core.Application.Dtos;

namespace Application.Features.Companies.Dtos;
public class GetSuppliersInCompanyQueryDto:IDto
{
    public Guid Id { get; set; }
    public Guid CompanyId { get; set; }
    public int UserId { get; set; }
    public string? Description { get; set; }

}
