using Core.Application.Responses;

namespace Application.Features.Suppliers.Commands.Create;

public class CreatedSupplierResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid CompanyId { get; set; }
    public int UserId { get; set; }
    public string? Description { get; set; }
}