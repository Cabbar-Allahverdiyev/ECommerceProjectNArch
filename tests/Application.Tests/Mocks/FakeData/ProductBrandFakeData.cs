using Core.Test.Application.FakeData;
using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Application.Tests.Mocks.FakeData;
public class ProductBrandFakeData : BaseFakeData<ProductBrand, Guid>
{
    public static readonly List<ProductBrand> Seeds = new List<ProductBrand>()
    {
        new(Guid.NewGuid(),"Samsung"),
        new(Guid.NewGuid(),"ETI")
    };

    public override List<ProductBrand> CreateFakeData() => Seeds;

}
