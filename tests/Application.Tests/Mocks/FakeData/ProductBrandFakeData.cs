using Core.Test.Application.FakeData;
using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Application.Tests.Mocks.FakeData;
public class ProductBrandFakeData : BaseFakeData<ProductBrand, Guid>
{
    public override List<ProductBrand> CreateFakeData()
    {
        List<ProductBrand> data= new() { 
        new(Guid.NewGuid(),"Samsung"),
        new(Guid.NewGuid(),"ETI")
        };

        return data;
    }
}
