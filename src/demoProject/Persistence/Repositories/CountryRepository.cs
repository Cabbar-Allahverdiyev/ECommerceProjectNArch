using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class CountryRepository : EfRepositoryBase<Country, Guid, BaseDbContext>, ICountryRepository
{
    public CountryRepository(BaseDbContext context) : base(context)
    {
    }
}