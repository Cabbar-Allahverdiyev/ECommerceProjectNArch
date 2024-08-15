using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IProductBrandRepository : IAsyncRepository<ProductBrand, Guid>, IRepository<ProductBrand, Guid>
{
}