using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Domain.Entities;
public class Seller:Entity<Guid>
{
    public int UserId { get; set; }
    public Guid ShopId { get; set; }
  
    public virtual User? User { get; set; }
    public virtual Shop? Shop { get; set; }

    public Seller()
    {
        
    }

    public Seller(Guid id, int userId,Guid shopId):this()
    {
        Id = id;
        UserId= userId;
        ShopId = shopId;
    }
}
