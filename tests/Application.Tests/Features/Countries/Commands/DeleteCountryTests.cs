using Application.Features.Countries.Commands.Delete;
using Application.Tests.Mocks.FakeData;
using Application.Tests.Mocks.Repositories;
using Domain.Entities;
using System;
using System.Threading;
using Xunit;
using static Application.Features.Countries.Commands.Delete.DeleteCountryCommand;

namespace Application.Tests.Features.Countries.Commands;
public class DeleteCountryTests:CountryMockRepository
{
    private readonly DeleteCountryCommandValidator _validator;
    private readonly DeleteCountryCommand _command;
    private readonly DeleteCountryCommandHandler _handler;

    public DeleteCountryTests(CountryFakeData fakeData, DeleteCountryCommandValidator validator, DeleteCountryCommand command)
        : base(fakeData)
    {
        _validator = validator;
        _command = command;
        _handler = new DeleteCountryCommandHandler(Mapper, MockRepository.Object, BusinessRules);
    }

    [Fact]
    public async void DeleteShouldSuccessfuly()
    {
        Country createdCountry = await MockRepository.Object.AddAsync(new (Guid.NewGuid(),"Germany","444"));

        _command.Id = createdCountry.Id;
        DeletedCountryResponse result = await _handler.Handle(_command, CancellationToken.None);

        Assert.Equal(createdCountry.Id.ToString(), result.Id.ToString());
    }
}
