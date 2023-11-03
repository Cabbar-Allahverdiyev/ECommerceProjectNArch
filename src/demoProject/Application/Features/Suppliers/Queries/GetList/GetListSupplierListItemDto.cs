using Core.Application.Dtos;

namespace Application.Features.Suppliers.Queries.GetList;

public class GetListSupplierListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid CompanyId { get; set; }
    public int UserId { get; set; }
    public string? Description { get; set; }
}