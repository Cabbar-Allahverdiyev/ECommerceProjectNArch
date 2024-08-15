using Application.Features.ProductInventors.Profiles;
using Application.Features.ProductInventors.Rules;
using Application.Services.Repositories;
using Application.Tests.Mocks.FakeData;
using Core.Test.Application.Repositories;
using Domain.Entities;
using System;

namespace Application.Tests.Mocks.Repositories;
public class ProductInventorMockRepository : BaseMockRepository<IProductInventorRepository,
                                                        ProductInventor,
                                                        Guid,
                                                        MappingProfiles,
                                                        ProductInventorBusinessRules,
                                                        ProductInventorFakeData>
{
    public ProductInventorMockRepository(ProductInventorFakeData fakeData) : base(fakeData)
    {
    }
}
