using Core.Test.Application.FakeData;
using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Application.Tests.Mocks.FakeData;
public class ProductCategoryFakeData : BaseFakeData<ProductCategory, Guid>
{
    public override List<ProductCategory> CreateFakeData()
    {
        Guid id=Guid.NewGuid();
        List<ProductCategory> data = new()
        {
            new(id,"Elektronika","rahat dasimaq"),
            new(Guid.NewGuid(),"Telefon","asan əlaqə"),
            new(Guid.NewGuid(),"Telefon",id,"asan əlaqə"),
        };
        return data;
    }
}
