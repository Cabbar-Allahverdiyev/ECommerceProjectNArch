using Core.Persistence.Repositories;

namespace Domain.Entities;
public  class Country:Entity<Guid>
{
    public string? Name { get; set; }

    public ICollection<City>? Cities { get; set; }

    public Country(Guid Id,string name)
    {
        Id = Id;
        Name = name;
    }

    public Country()
    {
        Cities=new HashSet<City>();
    }

}
