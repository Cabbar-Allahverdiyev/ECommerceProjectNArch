using Application.Features.Suppliers.Profiles;
using Application.Features.Suppliers.Rules;
using Application.Services.Repositories;
using Application.Tests.Mocks.FakeData;
using Core.Test.Application.Repositories;
using Domain.Entities;
using System;

namespace Application.Tests.Mocks.Repositories;
public class SupplierMockRepository:BaseMockRepository<ISupplierRepository,
                                                        Supplier,
                                                        Guid,
                                                        MappingProfiles,
                                                        SupplierBusinessRules,
                                                        SupplierFakeData>
{
    public SupplierMockRepository(SupplierFakeData fakeData) : base(fakeData)
    {
    }
}
