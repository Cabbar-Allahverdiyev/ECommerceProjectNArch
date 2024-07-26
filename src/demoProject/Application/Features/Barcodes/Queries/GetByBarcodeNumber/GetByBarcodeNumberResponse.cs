using Application.Features.Barcodes.Dtos;
using Core.Application.Responses;

namespace Application.Features.Barcodes.Queries.GetByBarcodeNumber;

public class GetByBarcodeNumberResponse : IResponse
{
    public Guid Id { get; set; }
    public string? BarcodeNumber { get; set; }
    public GetProductInBarcodeDto? Product { get; set; }
}
