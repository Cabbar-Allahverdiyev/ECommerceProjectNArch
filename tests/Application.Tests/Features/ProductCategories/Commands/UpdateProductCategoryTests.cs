using Application.Features.ProductCategories.Commands.Update;
using Application.Tests.Mocks.FakeData;
using Application.Tests.Mocks.Repositories;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Test.Application.Constants;
using FluentValidation.Results;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using static Application.Features.ProductCategories.Commands.Update.UpdateProductCategoryCommand;

namespace Application.Tests.Features.ProductCategories.Commands;
public  class UpdateProductCategoryTests:ProductCategoryMockRepository
{
    private readonly UpdateProductCategoryCommandValidator _validator;
    private readonly UpdateProductCategoryCommand _command;
    private readonly UpdateProductCategoryCommandHandler _handler;

    public UpdateProductCategoryTests(ProductCategoryFakeData fakeData,
                                      UpdateProductCategoryCommandValidator validator,
                                      UpdateProductCategoryCommand command) : base(fakeData)
    {
        _validator = validator;
        _command = command;
        _handler = new(Mapper, MockRepository.Object, BusinessRules);
    }


    [Theory]
    [InlineData("")]
    [InlineData("a")]
    [InlineData("ab")]
    public void CategoryNameLessThanThreeShouldReturnError(string name)
    {
        _command.Name = name;
        ValidationFailure? result = _validator.Validate(_command)
            .Errors.Where(x => x.PropertyName == "Name" && x.ErrorCode == ValidationErrorCodes.MinimumLengthValidator)
            .FirstOrDefault();
        Assert.Equal(ValidationErrorCodes.MinimumLengthValidator, result?.ErrorCode);
    }

    [Theory]
    [InlineData(null)]
    public void CategoryNameEmptyShouldReturnError(string name)
    {
        _command.Name = name;
        ValidationFailure? result = _validator.Validate(_command)
            .Errors.Where(x => x.PropertyName == "Name" && x.ErrorCode == ValidationErrorCodes.NotEmptyValidator)
            .FirstOrDefault();
        Assert.Equal(ValidationErrorCodes.NotEmptyValidator, result?.ErrorCode);
    }

   
    [Theory]
    [InlineData("00000000-0000-0000-0000-000000000000")]
    public void CategoryIdİsDefaultShouldReturnError(string id)
    {
        _command.Id = Guid.Parse(id);
        ValidationFailure? result = _validator.Validate(_command)
            .Errors.Where(x => x.PropertyName == "Id" && x.ErrorCode == ValidationErrorCodes.NotEmptyValidator)
            .FirstOrDefault();
        Assert.Equal(ValidationErrorCodes.NotEmptyValidator, result?.ErrorCode);
    }

    [Theory]
    [InlineData("abc")]
    [InlineData("abcdefgh")]
    [InlineData("Her shey eladi")]
    [InlineData("Hər şey əladı")]
    public void CategoryNameLengthGreaterThanThreeShouldReturnSuccess(string name)
    {
        _command.Id = Guid.NewGuid();
        _command.Name = name;
        ValidationResult errors = _validator.Validate(_command);
        Assert.Equal(0, errors?.Errors.Count());
    }

    [Theory]
    [InlineData("abc")]
    [InlineData("abcdefgh")]
    [InlineData("Her shey eladi")]
    [InlineData("Hər şey əladı")]
    [InlineData("1234567890123456789212345678931234567894123456789")]
    public void CategoryNameLengthLessThanFiftyShouldReturnSuccess(string name)
    {
        _command.Id = Guid.NewGuid();
        _command.Name = name;
        ValidationResult errors = _validator.Validate(_command);
        Assert.Equal(0, errors?.Errors.Count());
    }

    [Theory]
    [InlineData("123456789012345678921234567893123456789412345678901")]
    [InlineData("1234567890123456789212345678931234567894123456789012")]
    [InlineData("12345678901234567892123456789312345678941234567890123456")]
    public void CategoryNameGreaterThanFiftyShouldReturnError(string name)
    {
        _command.Name = name;
        ValidationFailure? result = _validator.Validate(_command)
            .Errors.Where(x => x.PropertyName == "Name" && x.ErrorCode == ValidationErrorCodes.MaxLengthValidator)
            .FirstOrDefault();
        Assert.Equal(ValidationErrorCodes.MaxLengthValidator, result?.ErrorCode);
    }

    [Theory]
    [InlineData("1234567890123456789212345678931234567894123456789012")]
    [InlineData("123456789012345678921234567893123456789412345678901")]
    [InlineData("12345678901234567892123456789312345678941234567890123456wefwefregergwefgergegerg")]
    public void CategoryDescriptionGreaterThanFiftyShouldReturnError(string description)
    {
        _command.Description = description;
        _command.Name = "aaaa";
        ValidationFailure? result = _validator.Validate(_command)
            .Errors.Where(x => x.PropertyName == "Description" && x.ErrorCode == ValidationErrorCodes.MaxLengthValidator)
            .FirstOrDefault();
        Assert.Equal(ValidationErrorCodes.MaxLengthValidator, result?.ErrorCode);
    }

   
    [Fact]
    public async Task UpdateShouldSuccessfully()
    {
        Guid id = Guid.NewGuid();
        await MockRepository.Object.AddAsync(new(id, "Cips", description: "Qacirilmazdir"));

        _command.Id = id;
        _command.Name = "Lepe";
        _command.Description = "Ela endirim";
        UpdatedProductCategoryResponse result = await _handler.Handle(_command, CancellationToken.None);
        Assert.Equal(expected: "Lepe", result.Name);
        Assert.Equal(expected: "Ela endirim", result.Description);
    }

    [Fact]
    public async Task DuplicatedCategoryNameShouldReturnError()
    {
        Guid id = Guid.NewGuid();
        await MockRepository.Object.AddAsync(new(id, "Icki", description: "Qacirilmazdir"));

        _command.Name = "Shirniyyat";
        _command.Description = "Ela endirim";
        await MockRepository.Object.AddAsync(new(Guid.NewGuid(), _command.Name, _command.Description));

        _command.Id = id;
        _command.Name = "Shirniyyat";

        async Task Action() => await _handler.Handle(_command, CancellationToken.None);

        await Assert.ThrowsAsync<BusinessException>(Action);
    }

}
