using Core.Application.Responses;

namespace Application.Features.ProductColors.Queries.GetById;

public class GetByIdProductColorResponse : IResponse
{
    public Guid Id { get; set; }
    public int Red { get; set; }
    public int Green { get; set; }
    public int Blue { get; set; }
}