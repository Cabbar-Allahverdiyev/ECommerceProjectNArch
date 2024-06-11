using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IBarcodeRepository : IAsyncRepository<Barcode, Guid>, IRepository<Barcode, Guid>
{
}