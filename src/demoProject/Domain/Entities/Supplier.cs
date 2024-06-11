using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Domain.Entities;
public class Supplier : Entity<Guid>
{
    public Guid CompanyId { get; set; }
    public int UserId { get; set; }//sales Representative
    public string? Description { get; set; }//ehtiyyac olarsa isRequired-i configirationdan cixart

    public virtual Company? Company { get; set; }
    public virtual User? User { get; set; }
    public virtual ICollection<Product> Products { get; set; }

    public Supplier()
    {
        Products = new HashSet<Product>();
    }

    public Supplier(Guid id,
                    int userId,
                    Guid companyId,
                    string description) : this()
    {
        Id = id;
        CompanyId = companyId;
        UserId = userId;
        Description = description;
    }
}
