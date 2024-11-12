using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IShopRepository : IAsyncRepository<Shop, Guid>, IRepository<Shop, Guid>
{
}