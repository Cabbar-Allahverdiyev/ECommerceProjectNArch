using Core.Test.Application.FakeData;
using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Application.Tests.Mocks.FakeData;
public class CompanyFakeData : BaseFakeData<Company, Guid>
{
    public static readonly List<Company> Seeds = new List<Company>()
    {
        new(){Id=Guid.NewGuid(),Name="teknoTelekom",AddressLine1="Yevlax",CityId=CityFakeData.Seeds[0].Id,Email="tekno@gmail.com",PhoneNumber="0552581478"},
        new(){Id=Guid.NewGuid(),Name="Qediroglu",AddressLine1="Mingecevir",CityId=CityFakeData.Seeds[1].Id,Email="Qediroglu@gmail.com",PhoneNumber="0505698774"}
    };
    public override List<Company> CreateFakeData()=>Seeds;
}
