using Application.Features.Discounts.Commands.Create;
using Application.Features.Discounts.Commands.Update;
using Application.Tests.Mocks.FakeData;
using Application.Tests.Mocks.Repositories;
using Core.Test.Application.Constants;
using FluentValidation.Results;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Xunit;
using static Application.Features.Discounts.Commands.Update.UpdateDiscountCommand;
using System;
using Core.CrossCuttingConcerns.Exceptions.Types;

namespace Application.Tests.Features.Discounts.Commands;
public class UpdateDiscountTests:DiscountMockRepository
{
    private readonly UpdateDiscountCommandValidator _validator;
    private readonly UpdateDiscountCommand _command;
    private readonly UpdateDiscountCommandHandler _handler;

    public UpdateDiscountTests(DiscountFakeData fakeData,
                               UpdateDiscountCommandValidator validator,
                               UpdateDiscountCommand command)
        : base(fakeData)
    {
        _validator = validator;
        _command = command;
        _handler = new UpdateDiscountCommandHandler(Mapper, MockRepository.Object, BusinessRules);
    }


    [Theory]
    [InlineData("")]
    [InlineData("a")]
    [InlineData("ab")]
    public void DiscountNameLessThanThreeShouldReturnError(string name)
    {
        _command.Name = name;
        ValidationFailure? result = _validator.Validate(_command)
            .Errors.Where(x => x.PropertyName == "Name" && x.ErrorCode == ValidationErrorCodes.MinimumLengthValidator)
            .FirstOrDefault();
        Assert.Equal(ValidationErrorCodes.MinimumLengthValidator, result?.ErrorCode);
    }

    [Theory]
    [InlineData(null)]
    public void DiscountNameEmptyShouldReturnError(string name)
    {
        _command.Name = name;
        ValidationFailure? result = _validator.Validate(_command)
            .Errors.Where(x => x.PropertyName == "Name" && x.ErrorCode == ValidationErrorCodes.NotEmptyValidator)
            .FirstOrDefault();
        Assert.Equal(ValidationErrorCodes.NotEmptyValidator, result?.ErrorCode);
    }

    //[Theory]
    //[InlineData(null)]
    //public void DiscountIdEmptyShouldReturnError(string? id)
    //{
    //    _command.Id = Guid.Parse(id);
    //    ValidationFailure? result = _validator.Validate(_command)
    //        .Errors.Where(x => x.PropertyName == "Id" && x.ErrorCode == ValidationErrorCodes.NotEmptyValidator)
    //        .FirstOrDefault();
    //    Assert.Equal(ValidationErrorCodes.NotEmptyValidator, result?.ErrorCode);
    //}

    [Theory]
    [InlineData("00000000-0000-0000-0000-000000000000")]
    public void DiscountIdİsDefaultShouldReturnError(string id)
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
    public void DiscountNameLengthGreaterThanThreeShouldReturnSuccess(string name)
    {
        _command.Id = Guid.NewGuid();
        _command.Name = name;
        _command.DiscountPercent = 5;
        ValidationResult errors = _validator.Validate(_command);
        Assert.Equal(0, errors?.Errors.Count());
    }

    [Theory]
    [InlineData("abc")]
    [InlineData("abcdefgh")]
    [InlineData("Her shey eladi")]
    [InlineData("Hər şey əladı")]
    [InlineData("1234567890123456789212345678931234567894123456789")]
    public void DiscountNameLengthLessThanFiftyShouldReturnSuccess(string name)
    {
        _command.Id = Guid.NewGuid();
        _command.Name = name;
        _command.DiscountPercent = 5;
        ValidationResult errors = _validator.Validate(_command);
        Assert.Equal(0, errors?.Errors.Count());
    }

    [Theory]
    [InlineData("123456789012345678921234567893123456789412345678901")]
    [InlineData("1234567890123456789212345678931234567894123456789012")]
    [InlineData("12345678901234567892123456789312345678941234567890123456")]
    public void DiscountNameGreaterThanFiftyShouldReturnError(string name)
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
    public void DiscountDescriptionGreaterThanFiftyShouldReturnError(string description)
    {
        _command.Description = description;
        _command.Name = "aaaa";
        _command.DiscountPercent = 5;
        ValidationFailure? result = _validator.Validate(_command)
            .Errors.Where(x => x.PropertyName == "Description" && x.ErrorCode == ValidationErrorCodes.MaxLengthValidator)
            .FirstOrDefault();
        Assert.Equal(ValidationErrorCodes.MaxLengthValidator, result?.ErrorCode);
    }

    [Theory]
    [InlineData("0")]
    [InlineData("0,5")]
    [InlineData("1")]
    public void DiscountPercentLessThanOneShouldReturnError(string percent)
    {
        _command.DiscountPercent = decimal.Parse(percent);
        ValidationFailure? result = _validator.Validate(_command)
            .Errors.Where(x => x.PropertyName == "DiscountPercent" && x.ErrorCode == ValidationErrorCodes.GreaterThanValidator)
            .FirstOrDefault();
        Assert.Equal(ValidationErrorCodes.GreaterThanValidator, result?.ErrorCode);
    }

    [Fact]
    public async Task UpdateShouldSuccessfully()
    {
        Guid id = Guid.NewGuid();
        await MockRepository.Object.AddAsync(new(id,10,"Beyləqan endirimi",description:"Qacirilmazdir"));

        _command.Id = id;
        _command.Name = "Imişli endirimi";
        _command.Description = "Ela endirim";
        _command.DiscountPercent = 5;
        UpdatedDiscountResponse result = await _handler.Handle(_command, CancellationToken.None);
        Assert.Equal(expected: "Imişli endirimi", result.Name);
        Assert.Equal(expected: "Ela endirim", result.Description);
        Assert.Equal(expected: 5, result.DiscountPercent);
    }

    [Fact]
    public async Task DuplicatedDiscountNameShouldReturnError()
    {
        Guid id = Guid.NewGuid();
        await MockRepository.Object.AddAsync(new(id, 10, "cirdaxan endirimi", description: "Qacirilmazdir"));

        _command.Name = "Yaz-Yay endirimi";
        _command.Description = "Ela endirim";
        _command.DiscountPercent = 5;
        await MockRepository.Object.AddAsync(new(Guid.NewGuid(), _command.DiscountPercent, _command.Name, _command.Description));

        _command.Id = id;
        _command.Name = "Yaz-Yay endirimi";
        _command.DiscountPercent = 8;

        async Task Action() => await _handler.Handle(_command, CancellationToken.None);

        await Assert.ThrowsAsync<BusinessException>(Action);
    }
}
