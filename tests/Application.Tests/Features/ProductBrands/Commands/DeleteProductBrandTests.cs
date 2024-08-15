using Application.Features.ProductBrands.Commands.Delete;
using Application.Tests.Mocks.FakeData;
using Application.Tests.Mocks.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using static Application.Features.ProductBrands.Commands.Delete.DeleteProductBrandCommand;

namespace Application.Tests.Features.ProductBrands.Commands;
public class DeleteProductBrandTests:ProductBrandMockRepository
{
    private readonly DeleteProductBrandCommandValidator _validator;
    private readonly DeleteProductBrandCommand _command;
    private readonly DeleteProductBrandCommandHandler _handler;

    public DeleteProductBrandTests(ProductBrandFakeData fakeData,
                                   DeleteProductBrandCommandValidator validator,
                                   DeleteProductBrandCommand command) : base(fakeData)
    {
        _validator = validator;
        _command = command;
        _handler = new DeleteProductBrandCommandHandler(Mapper, MockRepository.Object, BusinessRules); ;
    }

    [Fact]
    public async Task DeleteShouldSuccessfully()
    {
        Guid id = Guid.NewGuid();
        await MockRepository.Object.AddAsync(new(id, "Beko","Qacirilmazdir"));

        _command.Id = id;

        DeletedProductBrandResponse result = await _handler.Handle(_command, CancellationToken.None);
        Assert.Equal(expected: id, result.Id);
    }


}
