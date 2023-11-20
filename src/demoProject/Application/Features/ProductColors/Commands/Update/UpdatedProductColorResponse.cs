using Core.Application.Responses;

namespace Application.Features.ProductColors.Commands.Update;

public class UpdatedProductColorResponse : IResponse
{
    public Guid Id { get; set; }
    public int Red { get; set; }
    public int Green { get; set; }
    public int Blue { get; set; }
}