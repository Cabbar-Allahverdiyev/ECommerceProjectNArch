using Application.Features.ProductInventors.Dtos;
using Core.Application.Dtos;

namespace Application.Features.ProductInventors.Queries.GetList;

public class GetListProductInventorListItemDto : IDto
{
    public Guid Id { get; set; }
    public int Quantity { get; set; }
    public GetProductInInventorDto? Product { get; set; }
}