using Application.Features.Barcodes.Commands.Create;
using Application.Tests.Mocks.FakeData;
using Application.Tests.Mocks.Repositories;
using System.Threading.Tasks;
using System.Threading;
using Xunit;
using static Application.Features.Barcodes.Commands.Create.CreateBarcodeCommand;
using Core.CrossCuttingConcerns.Exceptions.Types;
using System;
using Core.Test.Application.Constants;
using FluentValidation.Results;
using System.Linq;
using Application.Features.Barcodes.Constants;

namespace Application.Tests.Features.Barcodes.Commands.Create;
public class CreateBarcodeTests : BarcodeMockRepository
{
    private readonly CreateBarcodeCommand _command;
    private readonly CreateBarcodeCommandValidator _validator;
    private readonly CreateBarcodeCommandHandler _handler;
    public CreateBarcodeTests(BarcodeFakeData fakeData,
                              CreateBarcodeCommandValidator validator,
                              CreateBarcodeCommand command) : base(fakeData)
    {
        _command = command;
        _validator = validator;
        _handler = new CreateBarcodeCommandHandler(Mapper, MockRepository.Object, BusinessRules);
    }

    [Theory]
    [InlineData(null)]
    public void BarcodeNumberEmptyShouldReturnError(string barcodeNumber)
    {
        _command.BarcodeNumber = barcodeNumber;
        ValidationFailure? result = _validator.Validate(_command)
            .Errors.Where(x => x.PropertyName == "BarcodeNumber" && x.ErrorCode == ValidationErrorCodes.NotEmptyValidator)
            .FirstOrDefault();
        Assert.Equal(ValidationErrorCodes.NotEmptyValidator, result?.ErrorCode);
    }

    //[Fact]
    //public async Task BarcodeNumberNotAlreadyExistShouldReturnSuccess()
    //{
    //    _command.ProductId = ProductFakeData.Seeds[5].Id;
    //    _command.BarcodeNumber = "9169000589869";
    //    CreatedBarcodeResponse result = await _handler.Handle(_command, CancellationToken.None);
    //    Assert.Equal(expected: ProductFakeData.Seeds[2].Id, result.ProductId);
    //    Assert.Equal(expected: "5416434520017", result.BarcodeNumber);
    //}


    [Fact]
    public async Task ProductIdExistWhenBarcodeNumberCreatedShouldReturnSuccess()
    {
        _command.BarcodeNumber = "3156280776672";
        _command.ProductId = ProductFakeData.Seeds[5].Id;
        var query = await MockRepository.Object.GetAsync(
            predicate: p => p.Id == _command.ProductId,
            enableTracking: false);

        CreatedBarcodeResponse result = await _handler.Handle(_command, CancellationToken.None);
        Assert.Equal(expected: query.ProductId, _command.ProductId);
        Assert.Equal(expected: ProductFakeData.Seeds[5].Id, result.ProductId);
        Assert.Equal(expected: "3156280776672", result.BarcodeNumber);
    }

    [Fact]
    public async Task ProductIdNotBeUsedForAnotherBarcodeNumberShouldReturnError()
    {
        _command.BarcodeNumber = "3156280776672";
        _command.ProductId = ProductFakeData.Seeds[6].Id;
        await MockRepository.Object.AddAsync(new(Guid.NewGuid(), _command.ProductId, _command.BarcodeNumber));

        _command.BarcodeNumber = "4290939792114";
        async Task Action() => await _handler.Handle(_command, CancellationToken.None);

        BusinessException exception = await Assert.ThrowsAsync<BusinessException>(Action);
        Assert.Equal(BarcodesBusinessMessages.TheProductAlreadyHasABarcode, exception.Message);


    }

    [Theory]
    [InlineData("11111456f")]
    [InlineData("bvfbdbv")]
    [InlineData("1!231")]
    [InlineData("!1446644")]
    [InlineData("1-446644")]
    public void BarcodeNumberIsDigitShouldReturnSuccess(string barcodeNumber)
    {
        _command.BarcodeNumber = barcodeNumber;
        _command.ProductId = Guid.NewGuid();
        ValidationResult errors = _validator.Validate(_command);
        Assert.Equal(0, errors?.Errors.Count());
    }

    [Theory]
    [InlineData("1234567890123")]
    [InlineData("9765304414021")]
    public void BarcodeNumberIsNotDigitShouldReturnError(string barcodeNumber)
    {
        _command.BarcodeNumber = barcodeNumber;
        ValidationFailure? result = _validator.Validate(_command)
            .Errors.Where(x => x.PropertyName == "BarcodeNumber" && x.ErrorCode == ValidationErrorCodes.MaxLengthValidator)
            .FirstOrDefault();
        Assert.Equal(BarcodesBusinessMessages.BarcodeNumberMustContainOnlyDigits, result?.ErrorMessage);
    }
    [Theory]
    [InlineData("1234567890123456789012345678901234567890123456789")]
    [InlineData("123456789012345678901234567890123456789012345678")]
    [InlineData("12345678901234567890123456789012345678901234567")]
    [InlineData("1234567890123456789012345678901234567890123456")]
    public void BarcodeNumberLengtLessThanFiftyShouldReturnSuccess(string barcodeNumber)
    {
        _command.BarcodeNumber = barcodeNumber;
        _command.ProductId = Guid.NewGuid();
        ValidationResult errors = _validator.Validate(_command);
        Assert.Equal(0, errors?.Errors.Count());
    }

    [Theory]
    [InlineData("123456789012345678901234567890123456789012345678901")]
    [InlineData("1234567890123456789012345678901234567890123456789012")]
    [InlineData("1234567890123456789012345678901234567890123456789013")]
    [InlineData("1234567890123456789012345678901234567890123456789014")]
    public void BarcodeNumberLengtGreaterThanFiftyShouldReturnError(string barcodeNumber)
    {
        _command.BarcodeNumber = barcodeNumber;
        ValidationFailure? result = _validator.Validate(_command)
            .Errors.Where(x => x.PropertyName == "BarcodeNumber" && x.ErrorCode == ValidationErrorCodes.MaxLengthValidator)
            .FirstOrDefault();
        Assert.Equal(ValidationErrorCodes.MaxLengthValidator, result?.ErrorCode);
    }

    [Fact]
    public async Task DuplicatedBarcodeNumberShouldReturnError()
    {

        _command.BarcodeNumber = "3851574730988";
        await MockRepository.Object.AddAsync(new(Guid.NewGuid(), ProductFakeData.Seeds[3].Id, _command.BarcodeNumber));
        _command.ProductId = ProductFakeData.Seeds[4].Id;

        async Task Action() => await _handler.Handle(_command, CancellationToken.None);

        await Assert.ThrowsAsync<BusinessException>(Action);
    }
    
    [Theory]
    [InlineData("3745062482919")]
    [InlineData("3469594289937")]
    [InlineData("5474760004434")]
    [InlineData("6520612327332")]
    [InlineData("7378226642308")]
    [InlineData("5000178753222")]
    [InlineData("2579862231443")]
    public async Task CheksumMustCorrectShouldReturnSuccess(string barcodeNumber)
    {

        BusinessException exception =
            await Assert.ThrowsAsync<BusinessException>(async () => await BusinessRules.ChekSumMustCorrect(barcodeNumber));
        Assert.Null(exception);
    }

    [Theory]
    [InlineData("3745062482910")]
    [InlineData("3469594289936")]
    [InlineData("5474760004435")]
    [InlineData("6520612327338")]
    [InlineData("7378226642300")]
    [InlineData("5000178753229")]
    [InlineData("2579862231442")]
    public async Task CheksumMustCorrectShouldReturnError(string barcodeNumber)
    {
        BusinessException exception = 
            await Assert.ThrowsAsync<BusinessException>(async () =>await BusinessRules.ChekSumMustCorrect(barcodeNumber));
        Assert.Equal(BarcodesBusinessMessages.BarcodeNumberNotInCorrectFormat, exception.Message);
    }//Record.ExceptionAsync bunlada yoxla
    [Fact]
    public async Task CreateShouldSuccessfully()
    {
        _command.ProductId = ProductFakeData.Seeds[2].Id;
        _command.BarcodeNumber = "5416434520017";
        CreatedBarcodeResponse result = await _handler.Handle(_command, CancellationToken.None);
        Assert.Equal(expected: ProductFakeData.Seeds[2].Id, result.ProductId);
        Assert.Equal(expected: "5416434520017", result.BarcodeNumber);
    }

}
