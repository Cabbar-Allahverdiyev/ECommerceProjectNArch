using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ISupplierRepository : IAsyncRepository<Supplier, Guid>, IRepository<Supplier, Guid>
{
}