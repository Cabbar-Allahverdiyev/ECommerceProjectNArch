using Application.Features.Cities.Commands.Create;
using Application.Tests.Mocks.FakeData;
using Application.Tests.Mocks.Repositories;
using Core.Test.Application.Constants;
using FluentValidation.Results;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Xunit;
using static Application.Features.Cities.Commands.Create.CreateCityCommand;
using Core.CrossCuttingConcerns.Exceptions.Types;

namespace Application.Tests.Features.Cities.Commands;
public class CreateCityTests:CityMockRepository
{
    private readonly CreateCityCommandValidator _validator;
    private readonly CreateCityCommand _command;
    private readonly CreateCityCommandHandler _handler;

    public CreateCityTests(CityFakeData fakeData,CreateCityCommandValidator validator, CreateCityCommand command)
        :base(fakeData)
    {
        _validator = validator;
        _command = command;
        _handler = new CreateCityCommandHandler(Mapper, MockRepository.Object, BusinessRules);
    }

    [Fact]
    public void CityNameEmptyShouldReturnError()
    {
        _command.Name = "a";
        ValidationFailure? result = _validator
           .Validate(_command)
           .Errors.Where(x => x.PropertyName == "Name" && x.ErrorCode == ValidationErrorCodes.MinimumLengthValidator)
           .FirstOrDefault();
        Assert.Equal(ValidationErrorCodes.MinimumLengthValidator, result?.ErrorCode);
    }


    [Fact]
    public async Task CreateShouldSuccessfully()
    {
        _command.Name = "Berde";
        CreatedCityResponse result = await _handler.Handle(_command, CancellationToken.None);
        Assert.Equal(expected: "Berde", result.Name);
    }

    [Fact]
    public async Task DuplicatedCityNameShouldReturnError()
    {
        _command.Name = "Baku";
        await Assert.ThrowsAsync<BusinessException>(async () => await _handler.Handle(_command, CancellationToken.None));
    }
}
