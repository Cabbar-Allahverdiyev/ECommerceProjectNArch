using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ProductBrandRepository : EfRepositoryBase<ProductBrand, Guid, BaseDbContext>, IProductBrandRepository
{
    public ProductBrandRepository(BaseDbContext context) : base(context)
    {
    }
}