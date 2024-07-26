using Application.Features.Barcodes.Dtos;
using Core.Application.Responses;


namespace Application.Features.Barcodes.Queries.GetById;

public class GetByIdBarcodeResponse : IResponse
{
    public Guid Id { get; set; }
    public string? BarcodeNumber { get; set; }
    public GetProductInBarcodeDto? Product { get; set; }
}