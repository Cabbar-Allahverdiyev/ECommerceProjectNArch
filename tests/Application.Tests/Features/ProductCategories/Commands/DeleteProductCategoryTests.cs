using Application.Features.ProductCategories.Commands.Delete;
using Application.Tests.Mocks.FakeData;
using Application.Tests.Mocks.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using static Application.Features.ProductCategories.Commands.Delete.DeleteProductCategoryCommand;

namespace Application.Tests.Features.ProductCategories.Commands;
public class DeleteProductCategoryTests:ProductCategoryMockRepository
{
    
    private readonly DeleteProductCategoryCommand _command;
    private readonly DeleteProductCategoryCommandHandler _handler;

    public DeleteProductCategoryTests(ProductCategoryFakeData fakeData,
                                      DeleteProductCategoryCommand command) : base(fakeData)
    {
        _command = command;
        _handler = new(Mapper, MockRepository.Object, BusinessRules);
    }

    [Fact]
    public async Task DeleteShouldSuccessfully()
    {
        Guid id = Guid.NewGuid();
        await MockRepository.Object.AddAsync(new(id, "Cherez", description: "Qacirilmazdir"));

        _command.Id = id;

        DeletedProductCategoryResponse result = await _handler.Handle(_command, CancellationToken.None);
        Assert.Equal(expected: id, result.Id);
    }

    [Fact]
    public async Task DeleteShouldSuccessfullyWhenParentIdSeted()
    {
        Guid id = Guid.NewGuid();
        Guid testedId = Guid.NewGuid();

        await MockRepository.Object.AddAsync(new(id, "Cherez", description: "Qacirilmazdir"));
        await MockRepository.Object.AddAsync(new(testedId, id, "Lepeler", description: "Qacirilmazdir"));

        _command.Id = testedId;

        DeletedProductCategoryResponse result = await _handler.Handle(_command, CancellationToken.None);
        Assert.Equal(expected: testedId, result.Id);
    }
}
