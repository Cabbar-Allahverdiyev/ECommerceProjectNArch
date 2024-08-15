using Application.Features.ProductInventors.Commands.Create;
using Application.Tests.Mocks.FakeData;
using Application.Tests.Mocks.Repositories;
using Core.Test.Application.Constants;
using FluentValidation.Results;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using static Application.Features.ProductInventors.Commands.Create.CreateProductInventorCommand;

namespace Application.Tests.Features.ProductInventors.Commands;
public class CreateProductInventorTests:ProductInventorMockRepository
{
    private readonly CreateProductInventorCommandValidator _validator;
    private readonly CreateProductInventorCommand _command;
    private readonly CreateProductInventorCommandHandler _handler;

    public CreateProductInventorTests(ProductInventorFakeData fakeData,
                                      CreateProductInventorCommandValidator validator,
                                      CreateProductInventorCommand command) : base(fakeData)
    {
        _validator = validator;
        _command = command;
        _handler = new(Mapper, MockRepository.Object, BusinessRules);
    }

     [Theory]
    [InlineData("0")]
    public void InventorQuantityLessThanOneShouldReturnError(string percent)
    {
        _command.Quantity = int.Parse(percent);
        ValidationFailure? result = _validator.Validate(_command)
            .Errors.Where(x => x.PropertyName == "Quantity" && x.ErrorCode == ValidationErrorCodes.NotEmptyValidator)
            .FirstOrDefault();
        Assert.Equal(ValidationErrorCodes.NotEmptyValidator, result?.ErrorCode);
    }

    [Fact]
    public async Task CreateShouldSuccessfully()
    {
        _command.Quantity = 5;
        CreatedProductInventorResponse result = await _handler.Handle(_command, CancellationToken.None);
        Assert.Equal(expected: 5, result.Quantity);
    }
}
