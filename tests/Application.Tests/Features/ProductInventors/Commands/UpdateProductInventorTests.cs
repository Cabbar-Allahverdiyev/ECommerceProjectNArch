using Application.Features.ProductInventors.Commands.Update;
using Application.Tests.Mocks.FakeData;
using Application.Tests.Mocks.Repositories;
using Core.Test.Application.Constants;
using FluentValidation.Results;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using static Application.Features.ProductInventors.Commands.Update.UpdateProductInventorCommand;

namespace Application.Tests.Features.ProductInventors.Commands;
public class UpdateProductInventorTests: ProductInventorMockRepository
{
    private readonly UpdateProductInventorCommandValidator _validator;
    private readonly UpdateProductInventorCommand _command;
    private readonly UpdateProductInventorCommandHandler _handler;

    public UpdateProductInventorTests(ProductInventorFakeData fakeData,
                                      UpdateProductInventorCommandValidator validator,
                                      UpdateProductInventorCommand command) : base(fakeData)
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
    public async Task UpdateShouldSuccessfully()
    {
        Guid id = Guid.NewGuid();
        //await MockRepository.Object.AddAsync(new(id, 10));

        _command.Id = id;
        _command.Quantity = 5;
        UpdatedProductInventorResponse result = await _handler.Handle(_command, CancellationToken.None);
        Assert.Equal(expected: 5, result.Quantity);
    }

}
