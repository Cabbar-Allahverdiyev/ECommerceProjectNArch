using Application.Features.Cities.Commands.Delete;
using Application.Tests.Mocks.FakeData;
using Application.Tests.Mocks.Repositories;
using Core.Test.Application.Constants;
using FluentValidation.Results;
using MongoDB.Driver.Linq;
using System;
using System.Linq;
using System.Threading;
using Xunit;
using static Application.Features.Cities.Commands.Delete.DeleteCityCommand;

namespace Application.Tests.Features.Cities.Commands;
public class DeleteCityTests : CityMockRepository
{
    private readonly DeleteCityCommandValidator _validator;
    private readonly DeleteCityCommand _command;
    private readonly DeleteCityCommandHandler _handler;

    public DeleteCityTests(CityFakeData fakeData,
                           DeleteCityCommandValidator validator,
                           DeleteCityCommand command
                           ) : base(fakeData)
    {
        _validator = validator;
        _command = command;
        _handler = new DeleteCityCommandHandler(Mapper, MockRepository.Object, BusinessRules);
    }

    [Fact]
    public  void CityNameEmptyShouldReturnError( )
    {
        _command.Id = Guid.Empty;
        ValidationFailure? result = _validator.Validate(_command)
            .Errors.Where(x=>x.PropertyName=="Name" && x.ErrorCode == ValidationErrorCodes.NotEmptyValidator)
            .FirstOrDefault();

        Assert.Equal(ValidationErrorCodes.NotEmptyValidator, result?.ErrorCode);
    }

    [Fact]
    public async void DeleteShouldSuccessfuly()
    {
       var createdCity = await MockRepository.Object.AddAsync(new(Guid.NewGuid(), "Beyleqan"));

        _command.Id = createdCity.Id;

        DeletedCityResponse result = await _handler.Handle(_command, CancellationToken.None);
        Assert.Equal(expected: createdCity.Id.ToString(),actual: result.Id.ToString());
    }
    
}
