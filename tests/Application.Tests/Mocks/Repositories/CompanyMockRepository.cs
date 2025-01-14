using Application.Features.Companies.Profiles;
using Application.Features.Companies.Rules;
using Application.Services.Repositories;
using Application.Tests.Mocks.FakeData;
using Core.Test.Application.Repositories;
using Domain.Entities;
using System;

namespace Application.Tests.Mocks.Repositories;
public class CompanyMockRepository : BaseMockRepository<ICompanyRepository, Company, Guid, MappingProfiles, CompanyBusinessRules, CompanyFakeData>
{
    public CompanyMockRepository(CompanyFakeData fakeData) : base(fakeData)
    {
    }
}
