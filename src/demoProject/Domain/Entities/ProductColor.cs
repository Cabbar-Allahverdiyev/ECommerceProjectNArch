using Core.Persistence.Repositories;

namespace Domain.Entities;
public class ProductColor:Entity<Guid>
{
    public int Red { get; set; }
    public int Green { get; set; }
    public int Blue { get; set; }

    public ICollection<Product> Products { get; set; }

    public ProductColor()
    {
        Products = new HashSet<Product>();
    }

    public ProductColor(Guid id,int red, int green, int blue)
    {
        Id = id;
        Red = red;
        Green = green;
        Blue = blue;
    }
}
