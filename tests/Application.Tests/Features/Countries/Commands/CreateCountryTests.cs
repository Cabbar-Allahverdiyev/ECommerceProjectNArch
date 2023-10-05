using Application.Features.Countries.Commands.Create;
using Application.Tests.Mocks.FakeData;
using Application.Tests.Mocks.Repositories;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Test.Application.Constants;
using Domain.Entities;
using FluentValidation.Results;
using MongoDB.Driver.Linq;
using System;
using System.Linq;
using System.Threading;
using Xunit;
using static Application.Features.Countries.Commands.Create.CreateCountryCommand;

namespace Application.Tests.Features.Countries.Commands;
public class CreateCountryTests:CountryMockRepository
{
    private readonly CreateCountryCommandValidator _validator;
    private readonly CreateCountryCommand _command;
    private readonly CreateCountryCommandHandler _handler;

    public CreateCountryTests(CountryFakeData fakeData, CreateCountryCommandValidator validator, CreateCountryCommand command)
        : base(fakeData)
    {
        _validator = validator;
        _command = command;
        _handler = new CreateCountryCommandHandler(Mapper, MockRepository.Object, BusinessRules);
    }

    [Fact]
    public async void CreateShouldSuccessfully()
    {
        _command.Name = "Norway";
        CreatedCountryResponse result = await _handler.Handle(_command, CancellationToken.None);
        Assert.Equal(expected: "Norway", result.Name);
    }

    [Theory]
    [InlineData("")]
    [InlineData("a")]
    public   void CountryNameIsNotLongerShouldReturnError(string countryName)
    {
        _command.Name = countryName;
        ValidationFailure? result = _validator.Validate(_command)
            .Errors.Where(x=>x.PropertyName=="Name"&& ValidationErrorCodes.MinimumLengthValidator==x.ErrorCode)
            .FirstOrDefault();

        Assert.Equal(ValidationErrorCodes.MinimumLengthValidator, result?.ErrorCode);
    }

    [Theory]
    [InlineData("")]
    public void CountryNameEmptyShouldReturnError(string countryName)
    {
        ValidationFailure? result = _validator.Validate(_command)
            .Errors.Where(x => x.PropertyName == "Name" && ValidationErrorCodes.NotEmptyValidator == x.ErrorCode)
            .FirstOrDefault();

        Assert.Equal(ValidationErrorCodes.NotEmptyValidator, result?.ErrorCode);
    }

    [Fact]
    public async void DuplicatedCountryNameShouldReturnError()
    {
        _command.Name = "Iran";
        Country createdCountry = await MockRepository.Object.AddAsync(new(Guid.NewGuid(),_command.Name));

        await Assert.ThrowsAsync<BusinessException>(async () => await _handler.Handle(_command,CancellationToken.None));
    }

}
