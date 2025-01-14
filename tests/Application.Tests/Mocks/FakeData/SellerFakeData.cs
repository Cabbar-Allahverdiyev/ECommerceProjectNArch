using Core.Test.Application.FakeData;
using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Application.Tests.Mocks.FakeData;
public class SellerFakeData : BaseFakeData<Seller, Guid>
{
    public static readonly List<Seller> Seeds = new List<Seller>()
    {
        new(){Id=Guid.NewGuid(),UserId=UserFakeData.Seeds[0].Id,ShopId=ShopFakeData.Seeds[0].Id},
        new(){Id=Guid.NewGuid(),UserId=UserFakeData.Seeds[1].Id,ShopId=ShopFakeData.Seeds[2].Id},
    };
    public override List<Seller> CreateFakeData()
    {
        throw new NotImplementedException();
    }
}
