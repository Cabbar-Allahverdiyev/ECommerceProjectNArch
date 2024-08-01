using Application.Features.Barcodes.Dtos;
using Core.Application.Dtos;

namespace Application.Features.Barcodes.Queries.GetListByDynamicBarcode;
public class GetListByDynamicBarcodeItemDto:IDto
{
    public Guid Id { get; set; }
    public string? BarcodeNumber { get; set; }
    public GetProductInBarcodeDto? Product { get; set; }
}
