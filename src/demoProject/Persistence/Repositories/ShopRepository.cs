using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ShopRepository : EfRepositoryBase<Shop, Guid, BaseDbContext>, IShopRepository
{
    public ShopRepository(BaseDbContext context) : base(context)
    {
    }
}