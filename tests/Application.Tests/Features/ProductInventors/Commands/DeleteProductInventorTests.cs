using Application.Features.ProductInventors.Commands.Delete;
using Application.Tests.Mocks.FakeData;
using Application.Tests.Mocks.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using static Application.Features.ProductInventors.Commands.Delete.DeleteProductInventorCommand;

namespace Application.Tests.Features.ProductInventors.Commands;
public class DeleteProductInventorTests: ProductInventorMockRepository
{
    private readonly DeleteProductInventorCommandValidator _validator;
    private readonly DeleteProductInventorCommand _command;
    private readonly DeleteProductInventorCommandHandler _handler;

    public DeleteProductInventorTests(ProductInventorFakeData fakeData,
                                      DeleteProductInventorCommandValidator validator,
                                      DeleteProductInventorCommand command) : base(fakeData)
    {
        _validator = validator;
        _command = command;
        _handler = new(Mapper, MockRepository.Object, BusinessRules);
    }

    [Fact]
    public async Task DeleteShouldSuccessfully()
    {
        Guid id = Guid.NewGuid();
        //await MockRepository.Object.AddAsync(new(id, 10));

        _command.Id = id;

        DeletedProductInventorResponse result = await _handler.Handle(_command, CancellationToken.None);
        Assert.Equal(expected: id, result.Id);
    }
}
