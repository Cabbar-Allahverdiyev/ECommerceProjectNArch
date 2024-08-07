using Application.Features.Cities.Commands.Update;
using Application.Features.Countries.Commands.Update;
using Application.Tests.Mocks.FakeData;
using Application.Tests.Mocks.Repositories;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Test.Application.Constants;
using FluentValidation.Results;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Xunit;
using static Application.Features.Countries.Commands.Update.UpdateCountryCommand;

namespace Application.Tests.Features.Countries.Commands;
public class UpdateCountryTests:CountryMockRepository
{
    private readonly UpdateCountryCommandValidator _validator;
    private readonly UpdateCountryCommand _command;
    private readonly UpdateCountryCommandHandler _handler;

    public UpdateCountryTests(CountryFakeData fakeData, UpdateCountryCommandValidator validator, UpdateCountryCommand command)
        : base(fakeData)
    {
        _validator = validator;
        _command = command;
        _handler = new UpdateCountryCommandHandler(Mapper, MockRepository.Object, BusinessRules);
    }

    [Theory]
    [InlineData("")]
    [InlineData("a")]
    [InlineData("aa")]
    [InlineData("aaa")]
    public void CountryNameIsNotLongerShouldReturnError(string countryName)
    {
        _command.Name = countryName;
        ValidationFailure? result=_validator.Validate(_command)
            .Errors.Where(x=>x.PropertyName=="Name"&& x.ErrorCode==ValidationErrorCodes.MinimumLengthValidator)
            .SingleOrDefault();
        Assert.Equal(expected: ValidationErrorCodes.MinimumLengthValidator, result?.ErrorCode);
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void CountryNameEmptyShouldReturnError(string countryName)
    {
        _command.Name = countryName;
        ValidationFailure? result = _validator.Validate(_command)
            .Errors.Where(x => x.PropertyName == "Name" && x.ErrorCode == ValidationErrorCodes.NotEmptyValidator)
            .SingleOrDefault();
        Assert.Equal(expected: ValidationErrorCodes.NotEmptyValidator, result?.ErrorCode);
    }

    [Fact]
    public async Task UpdateShouldSuccessfully()
    {
        var createdCity = await MockRepository.Object.AddAsync(new(System.Guid.NewGuid(), "Italy","333"));

        _command.Id = createdCity.Id;
        _command.Name = "Ispany";
        UpdatedCountryResponse result = await _handler.Handle(_command, CancellationToken.None);

        Assert.Equal(expected: "Ispany", result.Name);
    }

    [Fact]
    public async Task DuplicatedCountryNameShouldReturnError()
    {
        _command.Name = "Katar";
        await Assert.ThrowsAsync<BusinessException>(async () => await _handler.Handle(_command, CancellationToken.None));
    }

}
