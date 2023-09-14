using Core.Persistence.Repositories;

namespace Domain.Entities;
public class City:Entity<Guid>
{
    public string? Name { get; set; }

    public ICollection<Company>? Companies { get; set; }

    public City()
    {
        Companies = new HashSet<Company>();
    }
    public City(Guid id, string name) : this()
    {
        Id = id;
        Name = name;
       
    }
}
