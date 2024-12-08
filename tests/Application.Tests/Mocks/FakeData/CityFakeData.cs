using System;
using System.Collections.Generic;
using Core.Test.Application.FakeData;
using Domain.Entities;

namespace Application.Tests.Mocks.FakeData;
public class CityFakeData : BaseFakeData<City, Guid>
{
    public static readonly List<City> Seeds = new List<City>
        {
            new () {Id = Guid.NewGuid(),CountryId=CountryFakeData.Seeds[0].Id,Name = "Baku" },
            new () { Id = Guid.NewGuid(),CountryId=CountryFakeData.Seeds[1].Id,Name = "Yevlakh" }
        };
    public override List<City> CreateFakeData() => Seeds;

}
