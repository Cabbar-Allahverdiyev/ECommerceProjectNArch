﻿using Core.Persistence.Repositories;

namespace Domain.Entities;
public class Company : Entity<Guid>
{
    public string? Name { get; set; }
    public string? AddressLine1 { get; set; }
    public string? AddressLine2 { get; set; }
    public Guid CityId { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }

    public virtual City? City { get; set; }
    public virtual ICollection<Supplier>? Suppliers { get; set; }
    public Company()
    {
        Suppliers = new HashSet<Supplier>();
    }

    public Company(Guid id,
                   Guid cityId,
                   string name,
                   string addressLine1,
                   string? addressLine2,
                   string email,
                   string phoneNumber
                   ) : this()
    {
        Id = id;
        Name = name;
        AddressLine1 = addressLine1;
        AddressLine2 = addressLine2;
        CityId = cityId;
        Email = email;
        PhoneNumber = phoneNumber;
    }
}
