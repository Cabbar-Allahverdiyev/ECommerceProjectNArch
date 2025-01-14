using Application.Features.Shops.Profiles;
using Application.Features.Shops.Rules;
using Application.Services.Repositories;
using Application.Tests.Mocks.FakeData;
using Core.Test.Application.Repositories;
using Domain.Entities;
using System;

namespace Application.Tests.Mocks.Repositories;
public class ShopMockRepository : BaseMockRepository<IShopRepository, Shop, Guid, MappingProfiles, ShopBusinessRules, ShopFakeData>
{
    public ShopMockRepository(ShopFakeData fakeData) : base(fakeData)
    {
    }
}
