using Core.Application.Responses;

namespace Application.Features.ProductInventors.Commands.Delete;

public class DeletedProductInventorResponse : IResponse
{
    public Guid Id { get; set; }
}