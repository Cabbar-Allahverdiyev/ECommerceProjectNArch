using Application.Features.Barcodes.Constants;
using Application.Features.Companies.Commands.Create;
using Application.Features.Companies.Constants;
using Application.Tests.Mocks.FakeData;
using Application.Tests.Mocks.Repositories;
using Core.Test.Application.Constants;
using FluentValidation.Results;
using System;
using System.Linq;
using Xunit;
using static Application.Features.Companies.Commands.Create.CreateCompanyCommand;

namespace Application.Tests.Features.Companies.Commands.Create;
public class CreateCompanyTests : CompanyMockRepository
{
    private readonly CreateCompanyCommand _command;
    private readonly CreateCompanyCommandValidator _validator;
    private readonly CreateCompanyCommandHandler _handler;
    public CreateCompanyTests(CompanyFakeData fakeData,
                              CreateCompanyCommandValidator validator,
                              CreateCompanyCommand command) : base(fakeData)
    {
        _command = command;
        _validator = validator;
        _handler = new CreateCompanyCommandHandler(Mapper, MockRepository.Object, BusinessRules);
    }

    [Theory]
    [InlineData(null)]
    public void CompanyNameEmptyShouldReturnError(string companyName)
    {
        _command.Name = companyName;
        ValidationFailure? result = _validator.Validate(_command)
            .Errors.Where(x => x.PropertyName == "Name" && x.ErrorCode == ValidationErrorCodes.NotEmptyValidator)
            .FirstOrDefault();
        Assert.Equal(ValidationErrorCodes.NotEmptyValidator, result?.ErrorCode);
    }

    [Theory]
    [InlineData("a")]
    [InlineData("aa")]
    [InlineData("")]
    public void TheLengthOfCompanyNameLessThanTwoShouldReturnError(string companyName)
    {
        _command.Name = companyName;
        ValidationFailure? result = _validator.Validate(_command)
            .Errors.Where(x => x.PropertyName == "Name" && x.ErrorCode == ValidationErrorCodes.MinimumLengthValidator)
            .FirstOrDefault();
        Assert.Equal(ValidationErrorCodes.MinimumLengthValidator, result?.ErrorCode);
    }

    [Theory]
    [InlineData("123456789012345678901234567890123456789012345678901")]
    [InlineData("1234567890123456789012345678901234567890123456789012")]
    [InlineData("1234567890123456789012345678901234567890123456789013")]
    [InlineData("1234567890123456789012345678901234567890123456789014")]
    public void TheLengthOfCompanyNameGreaterThanFiftyShouldReturnError(string companyName)
    {
        _command.Name = companyName;
        ValidationFailure? result = _validator.Validate(_command)
            .Errors.Where(x => x.PropertyName == "Name" && x.ErrorCode == ValidationErrorCodes.MaxLengthValidator)
            .FirstOrDefault();
        Assert.Equal(ValidationErrorCodes.MaxLengthValidator, result?.ErrorCode);
    }

    [Theory]
    [InlineData(null)]
    public void AddressLine1EmptyShouldReturnError(string addressLine1)
    {
        _command.AddressLine1 = addressLine1;
        ValidationFailure? result = _validator.Validate(_command)
            .Errors.Where(x => x.PropertyName == "AddressLine1" && x.ErrorCode == ValidationErrorCodes.NotEmptyValidator)
            .FirstOrDefault();
        Assert.Equal(ValidationErrorCodes.NotEmptyValidator, result?.ErrorCode);
    }
    
    [Theory]
    [InlineData("")]
    [InlineData("1")]
    [InlineData("12")]
    [InlineData("123")]
    [InlineData("asa")]
    public void TheLengthOfAddressLine1LessThanThreeShouldReturnError(string addressLine1)
    {
        _command.AddressLine1 = addressLine1;
        ValidationFailure? result = _validator.Validate(_command)
            .Errors.Where(x => x.PropertyName == "AddressLine1" && x.ErrorCode == ValidationErrorCodes.MinimumLengthValidator)
            .FirstOrDefault();
        Assert.Equal(ValidationErrorCodes.MinimumLengthValidator, result?.ErrorCode);
    }

    [Theory]
    [InlineData("123456789012345678901234567890123456789012345678901")]
    [InlineData("1234567890123456789012345678901234567890123456789012")]
    [InlineData("1234567890123456789012345678901234567890123456789013")]
    [InlineData("1234567890123456789012345678901234567890123456789014")]
    public void TheLengthOfAddressLine1GreaterThanFiftyShouldReturnError(string addressLine1)
    {
        _command.AddressLine1 = addressLine1;
        ValidationFailure? result = _validator.Validate(_command)
            .Errors.Where(x => x.PropertyName == "AddressLine1" && x.ErrorCode == ValidationErrorCodes.MaxLengthValidator)
            .FirstOrDefault();
        Assert.Equal(ValidationErrorCodes.MaxLengthValidator, result?.ErrorCode);
    }

    [Theory]
    [InlineData(null)]
    public void EmailEmptyShouldReturnError(string email)
    {
        _command.Email = email;
        ValidationFailure? result = _validator.Validate(_command)
            .Errors.Where(x => x.PropertyName == "Email" && x.ErrorCode == ValidationErrorCodes.NotEmptyValidator)
            .FirstOrDefault();
        Assert.Equal(ValidationErrorCodes.NotEmptyValidator, result?.ErrorCode);
    }
    
    [Theory]
    [InlineData("")]
    [InlineData("1")]
    [InlineData("12")]
    [InlineData("123")]
    [InlineData("asa")]
    [InlineData("asad")]
    [InlineData("asada")]
    [InlineData("asadaf")]
    [InlineData("asadafg")]
    public void TheLengthOfEmailLessThanSevenShouldReturnError(string email)
    {
        _command.Email = email;
        ValidationFailure? result = _validator.Validate(_command)
            .Errors.Where(x => x.PropertyName == "Email" && x.ErrorCode == ValidationErrorCodes.MinimumLengthValidator)
            .FirstOrDefault();
        Assert.Equal(ValidationErrorCodes.MinimumLengthValidator, result?.ErrorCode);
    }
    
    [Theory]
    [InlineData("123456789012345678901234567890123456789012345678901")]
    [InlineData("1234567890123456789012345678901234567890123456789012")]
    [InlineData("1234567890123456789012345678901234567890123456789013")]
    [InlineData("1234567890123456789012345678901234567890123456789014")]
    public void TheLengthOfEmailGreaterThanFiftyShouldReturnError(string email)
    {
        _command.Email = email;
        ValidationFailure? result = _validator.Validate(_command)
            .Errors.Where(x => x.PropertyName == "Email" && x.ErrorCode == ValidationErrorCodes.MaxLengthValidator)
            .FirstOrDefault();
        Assert.Equal(ValidationErrorCodes.MaxLengthValidator, result?.ErrorCode);
    }
    
    [Theory]
    [InlineData("a")]
    [InlineData("asdasa")]
    [InlineData("asdasa.asdas")]
    [InlineData("asdasa.asdas@as")]
    [InlineData("asdasa.asdas@as.")]
    [InlineData("123.123")]
    [InlineData("123.123@123")]
    [InlineData("123.123@123.12")]
    public void EmailWrongFormatShouldReturnError(string email)
    {
        _command.Email = email;
        ValidationFailure? result = _validator.Validate(_command)
            .Errors.Where(x => x.PropertyName == "Email" && x.ErrorCode == ValidationErrorCodes.EmailValidator)
            .FirstOrDefault();
        Assert.Equal(ValidationErrorCodes.EmailValidator, result?.ErrorCode);
    }

    [Theory]
    [InlineData("asd@asd.com")]
    [InlineData("as@asd.com")]
    [InlineData("cabbar@cgmail.com")]
    public void EmailCorrectFormatShouldReturnSuccess(string email)
    {
        _command.Email = email;
        _command.AddressLine1 = "sdadasda";
        _command.PhoneNumber = "0555555555";
        _command.CityId = Guid.NewGuid();
        _command.Name = "asaa";
        ValidationResult errors = _validator.Validate(_command);
        Assert.Equal(0, errors?.Errors.Count());
    }

    [Theory]
    [InlineData(null)]
    public void PhoneNumberEmptyShouldReturnError(string phoneNumber)
    {
        _command.PhoneNumber = phoneNumber;
        ValidationFailure? result = _validator.Validate(_command)
            .Errors.Where(x => x.PropertyName == "PhoneNumber" && x.ErrorCode == ValidationErrorCodes.NotEmptyValidator)
            .FirstOrDefault();
        Assert.Equal(ValidationErrorCodes.NotEmptyValidator, result?.ErrorCode);
    }
    
    [Theory]
    [InlineData("")]
    [InlineData("1")]
    [InlineData("12")]
    [InlineData("123")]
    [InlineData("1234")]
    [InlineData("12345")]
    [InlineData("123456")]
    [InlineData("1234567")]
    [InlineData("12345678")]
    [InlineData("123456789")]
    [InlineData("1234567890")]
    public void TheLengthOfPhoneNumberLessThanTenShouldReturnError(string phoneNumber)
    {
        _command.PhoneNumber = phoneNumber;
        ValidationFailure? result = _validator.Validate(_command)
            .Errors.Where(x => x.PropertyName == "PhoneNumber" && x.ErrorCode == ValidationErrorCodes.MinimumLengthValidator)
            .FirstOrDefault();
        Assert.Equal(ValidationErrorCodes.MinimumLengthValidator, result?.ErrorCode);
    }
    
    [Theory]
    [InlineData("12345678901234")]
    [InlineData("123456789012345")]
    [InlineData("1234567890123456")]
    [InlineData("12345678901234567")]
    public void TheLengthOfPhoneNumberGreaterThanThirtTeenShouldReturnError(string phoneNumber)
    {
        _command.PhoneNumber = phoneNumber;
        ValidationFailure? result = _validator.Validate(_command)
            .Errors.Where(x => x.PropertyName == "PhoneNumber" && x.ErrorCode == ValidationErrorCodes.MaxLengthValidator)
            .FirstOrDefault();
        Assert.Equal(ValidationErrorCodes.MaxLengthValidator, result?.ErrorCode);
    }
    
    [Theory]
    [InlineData("a")]
    [InlineData("asdasa")]
    [InlineData("asdasa.asdas")]
    [InlineData("asdasa.asdas@as")]
    [InlineData("asdasa.asdas@as.")]
    [InlineData("123.123")]
    [InlineData("123.123@123")]
    [InlineData("123.123@123.12")]
    public void PhoneNumberWrongFormatShouldReturnError(string phoneNumber)
    {
        _command.PhoneNumber = phoneNumber;
        ValidationFailure? result = _validator.Validate(_command)
            .Errors.Where(x => x.PropertyName == "Email" && x.ErrorMessage == CompaniesValidationMessages.PhoneNumberNotValid)
            .FirstOrDefault();
        Assert.Equal(CompaniesValidationMessages.PhoneNumberNotValid, result?.ErrorMessage);
    } 

    [Theory]
    [InlineData("0555555555")]
    [InlineData("0999877445")]
    [InlineData("0514569878")]
    public void PhoneNumberCorrectFormatShouldReturnSuccess(string phoneNumber)
    {
        _command.PhoneNumber = phoneNumber;
        _command.Email = "cab@cab.com";
        _command.AddressLine1 = "sdadasda";
        _command.CityId = Guid.NewGuid();
        _command.Name = "asaa";
        ValidationResult errors = _validator.Validate(_command);
        Assert.Equal(0, errors?.Errors.Count());
    }

    //CompanyNameShouldNotExistWhenSelected dublicate
    //CompanyEmailShouldNotExistWhenSelected dublicate
    //CompanyPhoneNumberShouldNotExistWhenSelected dublicate

    //Company success
}
