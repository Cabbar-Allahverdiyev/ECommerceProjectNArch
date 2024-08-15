using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ProductInventorRepository : EfRepositoryBase<ProductInventor, Guid, BaseDbContext>, IProductInventorRepository
{
    public ProductInventorRepository(BaseDbContext context) : base(context)
    {
    }
}