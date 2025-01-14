using Core.Test.Application.FakeData;
using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Application.Tests.Mocks.FakeData;
public class SupplierFakeData : BaseFakeData<Supplier, Guid>
{
    public static readonly List<Supplier> Seeds = new List<Supplier>()
    {
        new(){Id=Guid.NewGuid(),UserId=UserFakeData.Seeds[0].Id,CompanyId=CompanyFakeData.Seeds[0].Id },
        new(){Id=Guid.NewGuid(),UserId=UserFakeData.Seeds[1].Id,CompanyId=CompanyFakeData.Seeds[1].Id },
        new(){Id=Guid.NewGuid(),UserId=UserFakeData.Seeds[2].Id,CompanyId=CompanyFakeData.Seeds[2].Id },
    };
    public override List<Supplier> CreateFakeData() => Seeds;
}
