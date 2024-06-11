using Core.Persistence.Repositories;

namespace Domain.Entities;
public  class Country:Entity<Guid>
{
    public string? Name { get; set; }

    public virtual ICollection<City>? Cities { get; set; }

    public Country(Guid id,string name):this()
    {
        Id = id;
        Name = name;
    }

    public Country()
    {
        Cities=new HashSet<City>();
    }

}
