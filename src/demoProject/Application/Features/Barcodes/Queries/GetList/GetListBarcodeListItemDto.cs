using Application.Features.Barcodes.Dtos;
using Core.Application.Dtos;

namespace Application.Features.Barcodes.Queries.GetList;

public class GetListBarcodeListItemDto : IDto
{
    public Guid Id { get; set; }
    public string? BarcodeNumber { get; set; }
    public GetProductInBarcodeDto? Product { get; set; }
}