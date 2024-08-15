using Core.Persistence.Repositories;

namespace Domain.Entities;
public class ProductColor:Entity<Guid>
{
    public string? Name { get; set; }

    public virtual ICollection<Product>? Products { get; set; }

    public ProductColor()
    {
        Products = new HashSet<Product>();
    }

    public ProductColor(Guid id,string name):this()
    {
        Id = id;
        Name = name;
    }
}
