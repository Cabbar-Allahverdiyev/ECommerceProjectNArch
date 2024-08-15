using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IProductInventorRepository : IAsyncRepository<ProductInventor, Guid>, IRepository<ProductInventor, Guid>
{
}