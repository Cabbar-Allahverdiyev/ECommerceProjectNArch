using Core.Persistence.Repositories;

namespace Domain.Entities;
public class City : Entity<Guid>
{
    public string Name { get; set; }
    public Guid CountryId { get; set; }

    public ICollection<Company>? Companies { get; set; }
    public Country? Country { get; set; }

    public City()
    {
        Companies = new HashSet<Company>();
    }
    public City(Guid countryId,string name) : this()
    {
        Name = name;
        CountryId = countryId;
    }
    public City(Guid id, Guid countryId, string name) : this()
    {
        Id = id;
        Name = name;
        CountryId = countryId;

    }
    public City(Guid id, Guid countryId, string name, DateTime createdDate) : this()
    {
        Id = id;
        Name = name;
        CreatedDate = createdDate;
        CountryId = countryId;
    }
}
