using Core.Persistence.Repositories;

namespace Domain.Entities;
public class ProductBrand : Entity<Guid>
{
    public string? Name { get; set; }
    public string? Description { get; set; }

    public virtual ICollection<Product> Products { get; set; }

    public ProductBrand()
    {
        Products = new HashSet<Product>();

    }

    public ProductBrand(Guid id,
                        string name,
                        string description) : this()
    {
        Id = id;
        Name = name;
        Description = description;
    }
    
    public ProductBrand(Guid id,
                        string name)
                        : this()
    {
        Id = id;
        Name = name;
    }
}
