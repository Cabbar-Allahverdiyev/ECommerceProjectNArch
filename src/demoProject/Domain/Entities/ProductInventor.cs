using Core.Persistence.Repositories;

namespace Domain.Entities;
public class ProductInventor : Entity<Guid>
{
    public int Quantity { get; set; }
    public Guid ProductId { get; set; }

    public virtual Product? Product { get; set; }

    public ProductInventor()
    {
    }

    public ProductInventor(Guid id,
                           Guid productId,
                           int quantity) : this()
    {
        Id = id;
        Quantity = quantity;
        ProductId = productId;
    }

}
