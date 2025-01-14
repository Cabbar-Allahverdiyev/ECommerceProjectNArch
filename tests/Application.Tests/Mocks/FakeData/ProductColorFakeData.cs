using Core.Test.Application.FakeData;
using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Application.Tests.Mocks.FakeData;
public class ProductColorFakeData : BaseFakeData<ProductColor, Guid>
{
    public static readonly List<ProductColor> Seeds=new List<ProductColor>()
    {
        new(){Id=Guid.NewGuid(),Name="Red"},
        new(){Id=Guid.NewGuid(),Name="Blue"},
    };
    public override List<ProductColor> CreateFakeData() => Seeds;
}
