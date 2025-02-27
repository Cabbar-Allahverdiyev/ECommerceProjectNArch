﻿using Core.Persistence.Repositories;

namespace Domain.Entities;
public class ProductCategory : Entity<Guid>
{
    public string? Name { get; set; }
    public Guid? ParentId { get; set; }
    public string? Description { get; set; }

    public virtual ProductCategory? Parent { get; set; }
    public virtual ICollection<Product> Products { get; set; }

    public ProductCategory()
    {
        Products = new HashSet<Product>();
    }

    public ProductCategory(Guid id,
                           Guid parentId,
                           string name,
                           string description) : this()
    {
        Id = id;
        Name = name;
        ParentId = parentId;
        Description = description;
    }

    public ProductCategory(Guid id,
                              string name,
                              string description) : this()
    {
        Id = id;
        Name = name;
        Description = description;
    }

    public ProductCategory(Guid id,
                          string name) : this()
    {
        Id = id;
        Name = name;
    }
}
