using Core.Application.Responses;
using Domain.Entities;

namespace Application.Features.Barcodes.Commands.Create;

public class CreatedBarcodeResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public string? BarcodeNumber { get; set; }
    public Product? Product { get; set; }
}