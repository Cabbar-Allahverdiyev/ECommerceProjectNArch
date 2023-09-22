using System;
using System.Collections.Generic;
using Core.Test.Application.FakeData;
using Domain.Entities;

namespace Application.Tests.Mocks.FakeData;
public class CityFakeData:BaseFakeData<City,Guid>
{
    public override List<City> CreateFakeData()
    {
        var data = new List<City>
        {
            new() { Id = Guid.NewGuid(), Name = "Baku" },
            new() { Id = Guid.NewGuid(), Name = "Yevlakh" }
        };
        return data;
    }
}
