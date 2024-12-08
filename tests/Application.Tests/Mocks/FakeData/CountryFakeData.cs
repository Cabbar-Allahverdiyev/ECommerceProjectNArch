using Core.Test.Application.FakeData;
using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Application.Tests.Mocks.FakeData;
public class CountryFakeData : BaseFakeData<Country, Guid>
{
    public static readonly List<Country> Seeds= new List<Country>
        {
            new() { Id = Guid.NewGuid(), Name = "Azerbaijan" },
            new() { Id = Guid.NewGuid(), Name = "Turkey" }
        };
    public override List<Country> CreateFakeData() => Seeds;

}
