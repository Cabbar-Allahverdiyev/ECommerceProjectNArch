using Application.Features.Sellers.Profiles;
using Application.Features.Sellers.Rules;
using Application.Services.Repositories;
using Application.Tests.Mocks.FakeData;
using Core.Test.Application.Repositories;
using Domain.Entities;
using System;

namespace Application.Tests.Mocks.Repositories;
public class SellerMockRepository : BaseMockRepository<ISellerRepository, Seller, Guid, MappingProfiles, SellerBusinessRules, SellerFakeData>
{
    public SellerMockRepository(SellerFakeData fakeData) : base(fakeData)
    {
    }
}
