using Core.Test.Application.FakeData;
using Domain.Entities;
using Nest;
using System;
using System.Collections.Generic;

namespace Application.Tests.Mocks.FakeData;
public class ProductCategoryFakeData : BaseFakeData<ProductCategory, Guid>
{
    public static readonly List<ProductCategory> Seeds=new List<ProductCategory>()
    {
            new(Guid.NewGuid(),"Elektronika","rahat dasimaq"),
            new(Guid.NewGuid(),"Telefon","asan əlaqə"),
            new(Guid.NewGuid(),"Meiset mallari","komfortlu istifade"),
    };

    public override List<ProductCategory> CreateFakeData() => Seeds;
}
