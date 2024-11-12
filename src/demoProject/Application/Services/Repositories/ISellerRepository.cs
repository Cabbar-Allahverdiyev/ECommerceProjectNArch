using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ISellerRepository : IAsyncRepository<Seller, Guid>, IRepository<Seller, Guid>
{
}