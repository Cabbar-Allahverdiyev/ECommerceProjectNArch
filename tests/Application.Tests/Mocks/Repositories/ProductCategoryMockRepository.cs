using Application.Features.ProductCategories.Profiles;
using Application.Features.ProductCategories.Rules;
using Application.Services.Repositories;
using Application.Tests.Mocks.FakeData;
using Core.Test.Application.Repositories;
using Domain.Entities;
using System;

namespace Application.Tests.Mocks.Repositories;
public class ProductCategoryMockRepository : BaseMockRepository<IProductCategoryRepository,
                                                        ProductCategory,
                                                        Guid,
                                                        MappingProfiles,
                                                        ProductCategoryBusinessRules,
                                                        ProductCategoryFakeData>
{
    public ProductCategoryMockRepository(ProductCategoryFakeData fakeData) : base(fakeData)
    {
    }
}
