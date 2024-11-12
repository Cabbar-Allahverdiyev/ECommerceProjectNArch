using Core.Application.Responses;

namespace Application.Features.Sellers.Commands.Delete;

public class DeletedSellerResponse : IResponse
{
    public Guid Id { get; set; }
}