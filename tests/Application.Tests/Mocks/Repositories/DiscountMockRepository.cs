using Application.Features.Discounts.Profiles;
using Application.Features.Discounts.Rules;
using Application.Services.Repositories;
using Application.Tests.Mocks.FakeData;
using Core.Test.Application.Repositories;
using Domain.Entities;
using System;

namespace Application.Tests.Mocks.Repositories;
public class DiscountMockRepository : BaseMockRepository<IDiscountRepository,
                                                        Discount, 
                                                        Guid,
                                                        MappingProfiles, 
                                                        DiscountBusinessRules, 
                                                        DiscountFakeData>
                                                    {
    public DiscountMockRepository(DiscountFakeData fakeData) : base(fakeData)
    {
    }
}
