using Core.Test.Application.FakeData;
using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Application.Tests.Mocks.FakeData;
public class SupplierFakeData : BaseFakeData<Supplier, Guid>
{
    public override List<Supplier> CreateFakeData() => new()
    {
        new(){Id=Guid.NewGuid(),UserId=1,CompanyId=Guid.NewGuid()},
    };
}
