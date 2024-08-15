using Core.Application.Dtos;

namespace Application.Features.Suppliers.Dtos;
public class GetUserInSupplierQueryDto : IDto
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
}
