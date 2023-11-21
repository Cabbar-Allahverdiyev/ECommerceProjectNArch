using Core.Application.Responses;

namespace Application.Features.ProductColors.Commands.Create;

public class CreatedProductColorResponse : IResponse
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
}