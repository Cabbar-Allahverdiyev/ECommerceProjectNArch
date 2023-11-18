using Core.Persistence.Repositories;

namespace Domain.Entities;
public class ProductInventor : Entity<Guid>
{
    public int Quantity { get; set; }

    public virtual Product Product { get; set; }

    public ProductInventor()
    {
        Product = new();
    }

    public ProductInventor(Guid id,
                           int quantity) : this()
    {
        Id = id;
        Quantity = quantity;
    }

}
