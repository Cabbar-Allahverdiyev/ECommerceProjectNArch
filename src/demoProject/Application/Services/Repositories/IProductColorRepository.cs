using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IProductColorRepository : IAsyncRepository<ProductColor, Guid>, IRepository<ProductColor, Guid>
{
}