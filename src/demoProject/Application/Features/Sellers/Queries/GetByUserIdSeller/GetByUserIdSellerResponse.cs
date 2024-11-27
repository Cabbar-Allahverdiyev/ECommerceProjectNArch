using Core.Application.Responses;

namespace Application.Features.Sellers.Queries.GetByUserIdSeller;

public class GetByUserIdSellerResponse : IResponse {
    public Guid Id { get; set; }
    public int UserId { get; set; }
    public Guid CompanyId { get; set; }
    public string? UserFirstName { get; set; }
    public string? UserLastName { get; set; }
    public string? CompanyName { get; set; }
}
