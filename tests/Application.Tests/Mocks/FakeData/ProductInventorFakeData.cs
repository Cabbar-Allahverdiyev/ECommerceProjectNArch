using Core.Test.Application.FakeData;
using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Application.Tests.Mocks.FakeData;
public class ProductInventorFakeData : BaseFakeData<ProductInventor, Guid>
{
    public static readonly List<ProductInventor> Seeds = new List<ProductInventor>()
    {
        new(){Id=Guid.NewGuid(),ProductId=ProductFakeData.Seeds[0].Id},
        new(){Id=Guid.NewGuid(),ProductId= ProductFakeData.Seeds[1].Id},
    };
    public override List<ProductInventor> CreateFakeData() => Seeds;

}
