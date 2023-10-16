using Core.Persistence.Repositories;

namespace Domain.Entities;
public class Discount : Entity<Guid>
{
    public decimal DiscountPercent { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public ICollection<Product>? Products { get; set; }

    public Discount()
    {
        Products = new HashSet<Product>();
    }

    public Discount(Guid id,
                    decimal discountPercent,
                    string name,
                    string description
                   ) : this()
    {
        Id = id;
        DiscountPercent = discountPercent;
        Name = name;
        Description = description;
    }
}
