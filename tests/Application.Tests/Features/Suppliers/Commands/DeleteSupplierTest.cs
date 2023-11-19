using Application.Features.Suppliers.Commands.Delete;
using Application.Tests.Mocks.FakeData;
using Application.Tests.Mocks.Repositories;
using Core.Security.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using static Application.Features.Suppliers.Commands.Delete.DeleteSupplierCommand;

namespace Application.Tests.Features.Suppliers.Commands;
public class DeleteSupplierTests:SupplierMockRepository
{
    private readonly DeleteSupplierCommand _command;
    private readonly DeleteSupplierCommandHandler _handler;

    public DeleteSupplierTests(SupplierFakeData fakeData,
                               DeleteSupplierCommand command) : base(fakeData)
    {
        _command = command;
        _handler = new(Mapper, MockRepository.Object, BusinessRules);
    }

    //[Fact]
    //public async Task DeleteShouldSuccessfully()
    //{
    //    Guid id = Guid.NewGuid();
    //    await MockRepository.Object.AddAsync(new(id, userId, companyId, description: "Qacirilmazdir"));

    //    _command.Id = id;

    //    DeletedSupplierResponse result = await _handler.Handle(_command, CancellationToken.None);
    //    Assert.Equal(expected: id, result.Id);
    //}
}
