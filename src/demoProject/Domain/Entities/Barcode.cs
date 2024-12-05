using Core.Persistence.Repositories;

namespace Domain.Entities;
public class Barcode : Entity<Guid>
{
    public Guid ProductId { get; set; }
    public string? BarcodeNumber { get; set; }

    public virtual Product? Product { get; set; }

    public Barcode()
    {
        
    }
    public Barcode(Guid id,Guid productId, string? barcodeNumber):this()
    {
        Id = id;
        ProductId = productId;
        BarcodeNumber = barcodeNumber;
    }
    public Barcode( Guid productId, string? barcodeNumber) : this()
    {
        Id = Guid.NewGuid();
        ProductId = productId;
        BarcodeNumber = barcodeNumber;
    }
}
