using Core.Application.Dtos;

namespace Application.Features.Sellers.Queries.GetList;

public class GetListSellerListItemDto : IDto
{
    public Guid Id { get; set; }
    public int UserId { get; set; }
    public Guid CompanyId { get; set; }
    public string? UserFirstName { get; set; }
    public string? UserLastName { get; set; }
    public string? CompanyName { get; set; }
}