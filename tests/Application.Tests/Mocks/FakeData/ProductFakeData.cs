using Core.Test.Application.FakeData;
using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Application.Tests.Mocks.FakeData;
public class ProductFakeData : BaseFakeData<Product, Guid>
{
    public static readonly List<Product> Seeds = new List<Product>()
    {
        new(Guid.NewGuid(),
            ProductCategoryFakeData.Seeds[0].Id,
            ProductBrandFakeData.Seeds[0].Id,
            SupplierFakeData.Seeds[0].Id,
            DiscountFakeData.Seeds[0].Id,
            ProductColorFakeData.Seeds[0].Id,
            ShopFakeData.Seeds[0].Id,
            0,
            0,
            3,
            5,
            "Samsung A3",
            "1x",
            "asasss",
            "",
            true
          ),
          new(Guid.NewGuid(),
            ProductCategoryFakeData.Seeds[1].Id,
            ProductBrandFakeData.Seeds[1].Id,
            SupplierFakeData.Seeds[1].Id,
            DiscountFakeData.Seeds[1].Id,
            ProductColorFakeData.Seeds[1].Id,
            ShopFakeData.Seeds[1].Id,
            0,
            0,
            3.5m,
            6,
            "Samsung A5",
            "1x",
            "pasasasa",
            "",
            true
          ),
    };
    public override List<Product> CreateFakeData() => Seeds;
}
