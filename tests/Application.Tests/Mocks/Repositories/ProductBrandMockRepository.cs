using Application.Features.ProductBrands.Profiles;
using Application.Features.ProductBrands.Rules;
using Application.Services.Repositories;
using Application.Tests.Mocks.FakeData;
using Core.Test.Application.Repositories;
using Domain.Entities;
using System;

namespace Application.Tests.Mocks.Repositories;
public class ProductBrandMockRepository : BaseMockRepository<IProductBrandRepository,
                                                        ProductBrand,
                                                        Guid,
                                                        MappingProfiles,
                                                        ProductBrandBusinessRules,
                                                        ProductBrandFakeData>
{
    public ProductBrandMockRepository(ProductBrandFakeData fakeData) : base(fakeData)
    {
    }
}
