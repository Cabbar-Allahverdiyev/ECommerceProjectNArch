using Application.Features.Products.Profiles;
using Application.Features.Products.Rules;
using Application.Services.Repositories;
using Application.Tests.Mocks.FakeData;
using Core.Test.Application.Repositories;
using Domain.Entities;
using System;

namespace Application.Tests.Mocks.Repositories;
public class ProductMockRepository : BaseMockRepository<IProductRepository, Product, Guid, MappingProfiles, ProductBusinessRules, ProductFakeData>
{
    public ProductMockRepository(ProductFakeData fakeData) : base(fakeData)
    {
    }
}
