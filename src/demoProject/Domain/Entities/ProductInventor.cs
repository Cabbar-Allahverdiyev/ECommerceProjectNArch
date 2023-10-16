using Core.Persistence.Repositories;

namespace Domain.Entities;
public class ProductInventor : Entity<Guid>
{
    public int Quantity { get; set; }

    public ICollection<Product> Products { get; set; }

    public ProductInventor()
    {
        Products = new HashSet<Product>();
    }

    public ProductInventor(Guid id,
                           int quantity) : this()
    {
        Id = id;
        Quantity = quantity;
    }

}
