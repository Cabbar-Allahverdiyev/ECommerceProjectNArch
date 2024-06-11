using Core.Application.Responses;
using Domain.Entities;

namespace Application.Features.Barcodes.Commands.Update;

public class UpdatedBarcodeResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public string? BarcodeNumber { get; set; }
    public Product? Product { get; set; }
}