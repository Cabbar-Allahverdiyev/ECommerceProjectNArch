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
    public City(string? name):this()
    {
        Name = name;
    }
    public City(Guid id, string name) : this()
    {
        Id = id;
        Name = name;
       
    
    }public City(Guid id, string name,DateTime createdDate) : this()
    {
        Id = id;
        Name = name;
        CreatedDate = createdDate;
    }
}
