using Application.Features.Suppliers.Commands.Create;
using Application.Tests.Mocks.FakeData;
using Application.Tests.Mocks.Repositories;
using Core.Test.Application.Constants;
using Domain.Entities;
using FluentValidation.Results;
using Nest;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using static Application.Features.Suppliers.Commands.Create.CreateSupplierCommand;

namespace Application.Tests.Features.Suppliers.Commands;
public class CreateSupplierTests : SupplierMockRepository
{
    private readonly CreateSupplierCommandValidator _validator;
    private readonly CreateSupplierCommand _command;
    private readonly CreateSupplierCommandHandler _handler;

    public CreateSupplierTests(SupplierFakeData fakeData,
                               CreateSupplierCommandValidator validator,
                               CreateSupplierCommand command) : base(fakeData)
    {
        _validator = validator;
        _command = command;
        _handler = new(Mapper, MockRepository.Object, BusinessRules);
    }

    [Theory]
    [InlineData("12345678901234567892123456789312345678941234567890123456789012345678921234567893123456789412345678901")]
    [InlineData("1234567890123456789212345678931234567894123456789012345678901234567892123456789312345678941234567890123456789")]
    public void SupplierDescriptionGreaterThanFiftyShouldReturnError(string description)
    {
        _command.Description = description;
        ValidationFailure? result = _validator.Validate(_command)
            .Errors.Where(x => x.PropertyName == "Description" && x.ErrorCode == ValidationErrorCodes.MaxLengthValidator)
            .FirstOrDefault();
        Assert.Equal(ValidationErrorCodes.MaxLengthValidator, result?.ErrorCode);
    }

    //[Fact]
    //public async Task CreateShouldSuccessfully()//istifade olunmayan userid ve comppanyid-ni nece elde edererem bu repositorylere el vurmadan
    //{
    //    Supplier findedSupplier =  MockRepository.Object.GetListAsync().Result.Items[0];
    //    _command.Name = "Huawei";
    //    _command.Description = "Ela endirim";
    //    CreatedSupplierResponse result = await _handler.Handle(_command, CancellationToken.None);
    //    Assert.Equal(expected: "Huawei", result.Name);
    //    Assert.Equal(expected: "Ela endirim", result.Description);
    //}

}
