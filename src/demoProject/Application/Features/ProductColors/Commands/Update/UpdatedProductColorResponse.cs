using Core.Application.Responses;

namespace Application.Features.ProductColors.Commands.Update;

public class UpdatedProductColorResponse : IResponse
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
}