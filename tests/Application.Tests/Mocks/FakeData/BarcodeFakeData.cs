using Core.Test.Application.FakeData;
using Domain.Entities;
using System;
using System.Collections.Generic;
namespace Application.Tests.Mocks.FakeData;
public class BarcodeFakeData : BaseFakeData<Barcode, Guid>
{
    public static readonly List<Barcode> Seeds = new List<Barcode>()
    {
        new(){Id=Guid.NewGuid(),BarcodeNumber="1911224131267",ProductId=ProductFakeData.Seeds[0].Id},
        new(){Id=Guid.NewGuid(),BarcodeNumber="6461647241722",ProductId=ProductFakeData.Seeds[1].Id}
    };
    public override List<Barcode> CreateFakeData() => Seeds;
}
