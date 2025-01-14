using Core.Test.Application.FakeData;
using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Application.Tests.Mocks.FakeData;
public class ShopFakeData : BaseFakeData<Shop, Guid>
{
    public static readonly List<Shop> Seeds = new List<Shop>()
    {
        new(){Id=Guid.NewGuid(),UserId=UserFakeData.Seeds[0].Id,CompanyId=CompanyFakeData.Seeds[0].Id},
        new(){Id=Guid.NewGuid(),UserId=UserFakeData.Seeds[1].Id,CompanyId=CompanyFakeData.Seeds[1].Id}
    };
    public override List<Shop> CreateFakeData() => Seeds;
}
