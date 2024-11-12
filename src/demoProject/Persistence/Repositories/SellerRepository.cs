using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class SellerRepository : EfRepositoryBase<Seller, Guid, BaseDbContext>, ISellerRepository
{
    public SellerRepository(BaseDbContext context) : base(context)
    {
    }
}