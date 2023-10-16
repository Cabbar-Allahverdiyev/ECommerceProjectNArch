﻿using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Domain.Entities;
public class Supplier : Entity<Guid>
{
    public Guid CompanyId { get; set; }
    public int UserId { get; set; }//sales Representative
    public string? Description { get; set; }

    public virtual Company? Company { get; set; }
    public virtual User? User { get; set; }
    public ICollection<Product> Products { get; set; }

    public Supplier()
    {
        Products = new HashSet<Product>();
    }

    public Supplier(Guid id,
                    Guid companyId,
                    int userId,
                    string description) : this()
    {
        Id = id;
        CompanyId = companyId;
        UserId = userId;
        Description = description;
    }
}
