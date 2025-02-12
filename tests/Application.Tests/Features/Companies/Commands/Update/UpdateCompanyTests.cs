using Application.Features.Companies.Commands.Update;
using Application.Tests.Mocks.FakeData;
using Application.Tests.Mocks.Repositories;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Test.Application.Constants;
using Domain.Entities;
using FluentValidation.Results;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using static Application.Features.Companies.Commands.Update.UpdateCompanyCommand;

namespace Application.Tests.Features.Companies.Commands;
public class UpdateCompanyTests : CompanyMockRepository
{
    private readonly UpdateCompanyCommandValidator _validator;
    private readonly UpdateCompanyCommand _command;
    private readonly UpdateCompanyCommandHandler _handler;

    public UpdateCompanyTests(CompanyFakeData fakeData,
                           UpdateCompanyCommandValidator validator,
                           UpdateCompanyCommand command
                           ) : base(fakeData)
    {
        _validator = validator;
        _command = command;
        _handler = new UpdateCompanyCommandHandler(Mapper,MockRepository.Object,BusinessRules);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("a")]
    public void CompanyIdEmptyShouldReturnError(string companyName)
    {
        _command.Id = Guid.NewGuid();
        ValidationFailure? result = _validator
           .Validate(_command)
           .Errors.Where(x => x.PropertyName == "Name" && x.ErrorCode == ValidationErrorCodes.MinimumLengthValidator)
           .FirstOrDefault();
        Assert.Equal(ValidationErrorCodes.MinimumLengthValidator, result?.ErrorCode);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("a")]
    public void CompanyNameEmptyShouldReturnError(string companyName)
    {
        _command.Name = companyName;
        ValidationFailure? result = _validator
           .Validate(_command)
           .Errors.Where(x => x.PropertyName == "Name" && x.ErrorCode == ValidationErrorCodes.MinimumLengthValidator)
           .FirstOrDefault();
        Assert.Equal(ValidationErrorCodes.MinimumLengthValidator, result?.ErrorCode);
    }

    [Fact]
    public async Task UpdateShouldSuccessfully()
    {
        Company createdCompany=await MockRepository.Object.AddAsync(new(Guid.NewGuid(), CityFakeData.Seeds[0].Id, "sirketAdi1UpdateTests","Yevlax","cab@cabbarasasas.com","0553216545"));

        _command.Id = createdCompany.Id;
        _command.Name = "sirketAdi1UpdateTestsDeyistirilenDeyer";
        UpdatedCompanyResponse result = await _handler.Handle(_command, CancellationToken.None);

        Assert.Equal(expected: "sirketAdi1UpdateTestsDeyistirilenDeyer", result.Name);
    }

    [Fact]
    public async Task DuplicatedCompanyNameShouldReturnError()
    { 
        Company createdCompany1=await MockRepository.Object.AddAsync(new(Guid.NewGuid(), CityFakeData.Seeds[0].Id, "sirketAdi1DupicateUpdateTests",  "Yevlax","cab@cabbarasasas123.com","0553216545"));
        Company createdCompany2=await MockRepository.Object.AddAsync(new(Guid.NewGuid(),CityFakeData.Seeds[0].Id, "sirketAdi2DupicateUpdateTests", "Yevlax","cab@cabbarasasas1234.com","0553216545"));
       
        _command.Id=createdCompany1.Id;
        _command.Name = "sirketAdi2DupicateUpdateTests";
        await Assert.ThrowsAsync<BusinessException>(async () => await _handler.Handle(_command, CancellationToken.None));
    }
}