using Application.Features.ProductColors.Dtos;
using Core.Application.Responses;

namespace Application.Features.ProductColors.Queries.GetById;

public class GetByIdProductColorResponse : IResponse
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public ICollection<GetProductsInProductColorDto>? Products { get; set; }
}