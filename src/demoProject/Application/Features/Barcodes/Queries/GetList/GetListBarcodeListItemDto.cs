using Core.Application.Dtos;
using Domain.Entities;

namespace Application.Features.Barcodes.Queries.GetList;

public class GetListBarcodeListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public string? BarcodeNumber { get; set; }
    //public Product? Product { get; set; }
}