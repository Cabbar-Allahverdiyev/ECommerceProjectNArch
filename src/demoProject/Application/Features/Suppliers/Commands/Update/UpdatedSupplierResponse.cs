using Core.Application.Responses;

namespace Application.Features.Suppliers.Commands.Update;

public class UpdatedSupplierResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid CompanyId { get; set; }
    public int UserId { get; set; }
    public string? BarcodeCode { get; set; }
    public string? Description { get; set; }
}