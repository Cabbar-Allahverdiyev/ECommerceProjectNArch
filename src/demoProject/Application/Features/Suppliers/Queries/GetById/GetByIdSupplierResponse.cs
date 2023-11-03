using Core.Application.Responses;

namespace Application.Features.Suppliers.Queries.GetById;

public class GetByIdSupplierResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid CompanyId { get; set; }
    public int UserId { get; set; }
    public string? Description { get; set; }
}