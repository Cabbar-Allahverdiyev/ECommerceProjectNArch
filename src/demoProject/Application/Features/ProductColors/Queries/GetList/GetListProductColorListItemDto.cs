using Core.Application.Dtos;

namespace Application.Features.ProductColors.Queries.GetList;

public class GetListProductColorListItemDto : IDto
{
    public Guid Id { get; set; }
    public int Red { get; set; }
    public int Green { get; set; }
    public int Blue { get; set; }
}