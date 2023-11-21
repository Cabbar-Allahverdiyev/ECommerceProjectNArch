using Core.Application.Dtos;

namespace Application.Features.ProductColors.Queries.GetList;

public class GetListProductColorListItemDto : IDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
}