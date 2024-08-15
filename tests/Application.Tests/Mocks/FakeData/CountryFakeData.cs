using Core.Test.Application.FakeData;
using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Application.Tests.Mocks.FakeData;
public class CountryFakeData : BaseFakeData<Country, Guid>
{
    public override List<Country> CreateFakeData()
    {
        var data = new List<Country>
        {
            new() { Id = Guid.NewGuid(), Name = "Azerbaijan" },
            new() { Id = Guid.NewGuid(), Name = "Turkey" }
        };
        return data;
    }

}
