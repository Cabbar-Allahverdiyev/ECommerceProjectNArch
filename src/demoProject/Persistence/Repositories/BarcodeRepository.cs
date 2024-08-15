using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class BarcodeRepository : EfRepositoryBase<Barcode, Guid, BaseDbContext>, IBarcodeRepository
{
    public BarcodeRepository(BaseDbContext context) : base(context)
    {
    }
}