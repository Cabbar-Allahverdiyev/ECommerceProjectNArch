using Core.Test.Application.FakeData;
using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Application.Tests.Mocks.FakeData;
public class ProductInventorFakeData : BaseFakeData<ProductInventor, Guid>
{
    public override List<ProductInventor> CreateFakeData() => new() {
                                                            new(Guid.NewGuid(),4),
                                                            new(Guid.NewGuid(),8),
                                                            new(Guid.NewGuid(),10),
                                                            };

}
