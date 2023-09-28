using Application.Features.Cities.Commands.Update;
using Application.Tests.Mocks.FakeData;
using Application.Tests.Mocks.Repositories;
using Core.Test.Application.Constants;
using FluentValidation.Results;
using System.Linq;
using Xunit;
using static Application.Features.Cities.Commands.Update.UpdateCityCommand;

namespace Application.Tests.Features.Cities.Commands;
public class UpdateCityTests : CityMockRepository
{
    private readonly UpdateCityCommandValidator _validator;
    private readonly UpdateCityCommand _command;
    private readonly UpdateCityCommandHandler _handler;

    public UpdateCityTests(CityFakeData fakeData,
                           UpdateCityCommandValidator validator,
                           UpdateCityCommand command,
                           UpdateCityCommandHandler handler) : base(fakeData)
    {
        _validator = validator;
        _command = command;
        _handler = handler;
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
}
