using Application.Features.Cities.Commands.Create;
using Application.Features.Cities.Commands.Update;
using Application.Tests.Mocks.FakeData;
using Application.Tests.Mocks.Repositories;
using Core.Test.Application.Constants;
using FluentValidation.Results;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Xunit;
using static Application.Features.Cities.Commands.Update.UpdateCityCommand;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using System;
using System.Collections;

namespace Application.Tests.Features.Cities.Commands;
public class UpdateCityTests : CityMockRepository
{
    private readonly UpdateCityCommandValidator _validator;
    private readonly UpdateCityCommand _command;
    private readonly UpdateCityCommandHandler _handler;

    public UpdateCityTests(CityFakeData fakeData,
                           UpdateCityCommandValidator validator,
                           UpdateCityCommand command
                           ) : base(fakeData)
    {
        _validator = validator;
        _command = command;
        _handler = new UpdateCityCommandHandler(Mapper,MockRepository.Object,BusinessRules);
    }

    [Theory]
    [InlineData("")]
    [InlineData("a")]
    public void CityNameEmptyShouldReturnError(string cityName)
    {
        _command.Name = cityName;
        ValidationFailure? result = _validator
           .Validate(_command)
           .Errors.Where(x => x.PropertyName == "Name" && x.ErrorCode == ValidationErrorCodes.MinimumLengthValidator)
           .FirstOrDefault();
        Assert.Equal(ValidationErrorCodes.MinimumLengthValidator, result?.ErrorCode);
    }

    [Fact]
    public async Task UpdateShouldSuccessfully()
    {
        var gotCity = await MockRepository.Object.GetListAsync();
        City createdCity=await MockRepository.Object.AddAsync(new(System.Guid.NewGuid(), gotCity.Items[0].CountryId,"Terter"));

        _command.Id = createdCity.Id;
        _command.Name = "Berde";
        UpdatedCityResponse result = await _handler.Handle(_command, CancellationToken.None);

        Assert.Equal(expected: "Berde", result.Name);
    }

    [Fact]
    public async Task DuplicatedCityNameShouldReturnError()
    {
        _command.Name = "Baku";
        await Assert.ThrowsAsync<BusinessException>(async () => await _handler.Handle(_command, CancellationToken.None));
    }
}
