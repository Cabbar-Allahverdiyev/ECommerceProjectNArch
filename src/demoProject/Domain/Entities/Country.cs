using Core.Persistence.Repositories;

namespace Domain.Entities;
public  class Country:Entity<Guid>
{
    public string? Name { get; set; }
    public string? BarcodeCode { get; set; }

    public virtual ICollection<City>? Cities { get; set; }

    public Country(Guid id, string name, string? barcodeCode) : this()
    {
        Id = id;
        Name = name;
        BarcodeCode = barcodeCode;
    }

    public Country()
    {
        Cities=new HashSet<City>();
    }

}
