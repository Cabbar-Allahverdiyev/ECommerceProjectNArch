using Application.Features.Companies.Commands.Delete;
using Application.Tests.Mocks.FakeData;
using Application.Tests.Mocks.Repositories;
using Core.Test.Application.Constants;
using FluentValidation.Results;
using System;
using System.Linq;
using System.Threading;
using Xunit;
using static Application.Features.Companies.Commands.Delete.DeleteCompanyCommand;

namespace Application.Tests.Features.Companies.Commands;
public class DeleteCityTests : CompanyMockRepository
{
    private readonly DeleteCompanyCommandValidator _validator;
    private readonly DeleteCompanyCommand _command;
    private readonly DeleteCompanyCommandHandler _handler;

    public DeleteCityTests(CompanyFakeData fakeData,
                           DeleteCompanyCommandValidator validator,
                           DeleteCompanyCommand command
                           ) : base(fakeData)
    {
        _validator = validator;
        _command = command;
        _handler = new DeleteCompanyCommandHandler(Mapper, MockRepository.Object, BusinessRules);
    }

    [Fact]
    public  void CompanyIdEmptyShouldReturnError( )
    {
        _command.Id = Guid.Empty;
        ValidationFailure? result = _validator.Validate(_command)
            .Errors.Where(x=>x.PropertyName=="Id" && x.ErrorCode == ValidationErrorCodes.NotEmptyValidator)
            .FirstOrDefault();

        Assert.Equal(ValidationErrorCodes.NotEmptyValidator, result?.ErrorCode);
    }

    [Fact]
    public async void DeleteShouldSuccessfuly()
    {
       var createdCompany = await MockRepository.Object.AddAsync(new(Guid.NewGuid(), CityFakeData.Seeds[0].Id,"sirketAdi1DeleteTests","Yevlax","","cab@cabbar.com","0553216545"));

        _command.Id = createdCompany.Id;

        DeletedCompanyResponse result = await _handler.Handle(_command, CancellationToken.None);
        Assert.Equal(expected: createdCompany.Id.ToString(),actual: result.Id.ToString());
    }
    
}
