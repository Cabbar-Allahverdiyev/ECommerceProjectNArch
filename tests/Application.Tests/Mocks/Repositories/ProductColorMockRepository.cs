using Application.Features.ProductColors.Profiles;
using Application.Features.ProductColors.Rules;
using Application.Services.Repositories;
using Application.Tests.Mocks.FakeData;
using Core.Test.Application.Repositories;
using Domain.Entities;
using System;

namespace Application.Tests.Mocks.Repositories;
public class ProductColorMockRepository : BaseMockRepository<IProductColorRepository, ProductColor, Guid, MappingProfiles, ProductColorBusinessRules, ProductColorFakeData>
{
    public ProductColorMockRepository(ProductColorFakeData fakeData) : base(fakeData)
    {
    }
}
