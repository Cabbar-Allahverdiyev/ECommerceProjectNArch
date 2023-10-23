using Application.Features.Discounts.Commands.Delete;
using Application.Tests.Mocks.FakeData;
using Application.Tests.Mocks.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using static Application.Features.Discounts.Commands.Delete.DeleteDiscountCommand;

namespace Application.Tests.Features.Discounts.Commands;
public  class DeleteDiscountTests:DiscountMockRepository
{
    private readonly DeleteDiscountCommandValidator _validator;
    private readonly DeleteDiscountCommand _command;
    private readonly DeleteDiscountCommandHandler _handler;

    public DeleteDiscountTests(DiscountFakeData fakeData,
                               DeleteDiscountCommandValidator validator,
                               DeleteDiscountCommand command)
        : base(fakeData)
    {
        _validator = validator;
        _command = command;
        _handler = new DeleteDiscountCommandHandler(Mapper, MockRepository.Object, BusinessRules);
    }

    [Fact]
    public async Task DeleteShouldSuccessfully()
    {
        Guid id = Guid.NewGuid();
        await MockRepository.Object.AddAsync(new(id, 10, "Beyləqan endirimi", description: "Qacirilmazdir"));

        _command.Id = id;
       
        DeletedDiscountResponse result = await _handler.Handle(_command, CancellationToken.None);
        Assert.Equal(expected: id, result.Id);
    }
}
