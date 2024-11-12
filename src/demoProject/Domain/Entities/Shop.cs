using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Domain.Entities;
public class Shop:Entity<Guid>
{
    public int UserId { get; set; }
    public Guid CompanyId { get; set; }

    public virtual User? User { get; set; }
    public virtual Company? Company { get; set; }
    public virtual ICollection<Seller>? Sellers { get; set; } = null;

    public Shop()
    {
        Sellers= new HashSet<Seller>();
    }

    public Shop(Guid id, int userId,Guid companyId):this()
    {
        Id = id;
        UserId=userId;
        CompanyId = companyId;
    }

}
