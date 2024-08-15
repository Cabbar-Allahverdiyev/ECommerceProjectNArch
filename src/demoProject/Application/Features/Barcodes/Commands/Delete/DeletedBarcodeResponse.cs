using Core.Application.Responses;

namespace Application.Features.Barcodes.Commands.Delete;

public class DeletedBarcodeResponse : IResponse
{
    public Guid Id { get; set; }
}